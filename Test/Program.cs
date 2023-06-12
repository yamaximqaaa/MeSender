// See https://aka.ms/new-console-template for more information

using MessengerBack.Entities;
using MessengerBack.Helpers;

Console.WriteLine("sdf");

var user = new User()
{
    Name = "nameVal",
    LastName = "LastNameVal"
};
string userStr = CustomSerializer.SerializeObj(user, typeof(User));
User newUser = (User)CustomSerializer.DeserializeObj(userStr, typeof(User));
User newUser2 = CustomSerializer.DeserializeObj<User>(userStr);
Console.WriteLine(userStr);
class User
{
    public string Name { get; set; }
    public string LastName { get; set; }
}