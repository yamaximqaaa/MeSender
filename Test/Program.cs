// See https://aka.ms/new-console-template for more information

using MessengerBack.Entities;

Console.WriteLine("sdf");

var user = new User()
{
    Name = "name"
};

var fields = user.GetType().GetFields();

Console.WriteLine();
class User
{
    public string Name { get; set; }
    public string _name;
}