using MessengerBack.ViewModels;

namespace MessengerBack.Entities;

public class User
{
    public Guid Id { get; init; }
    public string Name { get; set; }
    public string Login { get; set; }
    private string _password;

    public User UpdateUser(UserViewModel userViewModel)
    {
        Name = userViewModel.Name;
        Login = userViewModel.Login;
        return this;
    }

    public static implicit operator UserViewModel(User user) => new UserViewModel()
    {
        Login = user.Login,
        Name = user.Name
    };
}