namespace MessengerBack.Models.User;

public class UserView
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Login { get; set; }

    public Entities.User GetNewUserFromViewModel()      // todo: move to NewUser class
    {
        return new Entities.User()
        {
            Id = Guid.NewGuid(),
            Login = this.Login,
            Name = this.Name
        };
    }
    public Entities.User GetUserFromViewModel(Guid id)
    {
        return new Entities.User()
        {
            Id = id,
            Login = this.Login,
            Name = this.Name
        };
    }
}