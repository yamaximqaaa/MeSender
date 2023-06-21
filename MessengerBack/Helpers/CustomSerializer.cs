using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MessengerBack.Helpers;

public static class CustomSerializer
{
    public static string SerializeObj(object obj, Type type)
    {
        var result = new StringBuilder();
        var props = type.GetProperties();
        foreach (var prop in props)
        {
            // --- Можно ли это написать красивее? 
            var attribute = Attribute
                .GetCustomAttribute(prop, typeof(CustomSerializerAttribute)) 
                as CustomSerializerAttribute;
            if (attribute is not null)
            {
                result.Append($"{attribute.CustomName ?? prop.Name}:{prop.GetValue(obj)};");
            }
            else
            {
                result.Append($"{prop.Name}:{prop.GetValue(obj)};");
            }
            // ---
        }

        return result.ToString();
    }
    public static object DeserializeObj(string str, Type type)
    {
        var result = Activator.CreateInstance(type);
        var resultType = result.GetType();
        var regex = new Regex(@"(\w+):(\w+)");         // (\w+):(\w+) ([a-z0-9A-Z]+):([a-z0-9A-Z]+)
        var matches = regex.Matches(str);
        //var props = str.Split(';');

        foreach (var prop in resultType.GetProperties())
        {
            var attr = prop.GetCustomAttribute<CustomSerializerAttribute>();
            if (attr is not null)
            {
                var propVal = matches
                    .Select(x => x.Groups).FirstOrDefault(x => x[1].Value == attr.CustomName);
                if (propVal is not null)
                {
                    prop.SetValue(result, propVal[2].Value);
                }
                else
                {
                    propVal = matches
                        .Select(x => x.Groups).FirstOrDefault(x => x[1].Value == prop.Name);
                    prop.SetValue(result, propVal[2].Value);
                }
            }
            else
            {
                var propVal = matches
                    .Select(x => x.Groups).FirstOrDefault(x => x[1].Value == prop.Name);
                prop.SetValue(result, propVal[2].Value);
            }
            
        }
        
        // foreach (var prop in props)
        // {
        //     if (!String.IsNullOrWhiteSpace(prop))
        //     {   
        //         var mach = regex.Match(prop);
        //         resultType.GetProperty(mach.Groups[1].Value)
        //             .SetValue(result, mach.Groups[2].Value);
        //     }
        // }
        return result;
    }

    public static T DeserializeObj<T>(string str)
    {
        return (T)DeserializeObj(str, typeof(T));
    }
}

public class CustomSerializerAttribute : Attribute
{
    public string? CustomName { get; set; }
    public CustomSerializerAttribute(string? name)
    {
        CustomName = name;
    }
}