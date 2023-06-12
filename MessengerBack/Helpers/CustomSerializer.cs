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
            result.Append($"{prop.Name}:{prop.GetValue(obj)};");
        }

        return result.ToString();
    }
    public static object DeserializeObj(string str, Type type)
    {
        var result = Activator.CreateInstance(type);
        var resultType = result.GetType();
        var regex = new Regex("([a-z0-9A-Z]+):([a-z0-9A-Z]+)");
        var props = str.Split(';');
        foreach (var prop in props)
        {
            if (!String.IsNullOrWhiteSpace(prop))
            {   
                var mach = regex.Match(prop);
                resultType.GetProperty(mach.Groups[1].Value)
                    .SetValue(result, mach.Groups[2].Value);
            }
        }
        return result;
    }

    public static T DeserializeObj<T>(string str)
    {
        return (T)DeserializeObj(str, typeof(T));
    }
}