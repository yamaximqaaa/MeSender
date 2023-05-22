using MessengerBack.Entities;

namespace MessengerBack.ViewModels;

public class UserViewModel
{
    // I need id in view model or not?
    // If not how to return viewModel with id for example in update?
    // Otherwise how to create new user with id generated on back
        // if i get viewModel with id from front? 
    public string Name { get; set; }
    public string Login { get; set; }

    public User GetNewUserFromViewModel()
    {
        return new User()
        {
            Id = Guid.NewGuid(),
            Login = this.Login,
            Name = this.Name
        };
    }
    public User GetUserFromViewModel(Guid id)
    {
        return new User()
        {
            Id = id,
            Login = this.Login,
            Name = this.Name
        };
    }
}