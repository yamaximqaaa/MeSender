using MessengerBack.Models.User;

namespace MessengerBack.Entities;

public class User
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Login { get; set; }
    private string _password;

    public User UpdateUser(UserView userView)
    {
        Name = userView.Name;
        Login = userView.Login;
        return this;
    }

    public User UpdateUserProp(string propName, string propValue)
    {
        var prop = GetType().GetProperty(propName);
        prop!.SetValue(this, propValue);
        return this;
    }

    public static implicit operator UserView(User user) => new UserView()
    {
        Id = user.Id,
        Login = user.Login,
        Name = user.Name
    };
}