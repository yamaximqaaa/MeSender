using MessengerBack.ViewModels;

namespace MessengerBack.Entities.DbContext;

public static class DbContextHelper
{
    #region Lists

    private static List<User> _users = new List<User>()
    {
        new User()
        {
            Id = Guid.NewGuid(),
            Login = "user1",
            Name = "User1"
        },
        new User()
        {
            Id = Guid.NewGuid(),
            Login = "user2",
            Name = "User2"
        },
    };

    private static List<Conversation> _conversations = new List<Conversation>();
    private static List<UserConversation> _userConversations = new List<UserConversation>();
    private static List<Message> _messages = new List<Message>();

    #endregion
    

    #region userMethods

    public static List<UserViewModel> GetUsersViewModel()
    {
        return _users.Select(x => new UserViewModel()
        {
            Name = x.Name,
            Login = x.Login
        }).ToList();

    }

    public static UserViewModel? GetUserViewModelById(Guid id)
    {
        return _users.FirstOrDefault((x) => x.Id == id);
    }

    public static Guid AddUser(UserViewModel userView)
    {
        var user = userView.GetNewUserFromViewModel();
        _users.Add(user);
        return user.Id;
    }

    public static UserViewModel? UpdateUser(Guid id, UserViewModel userView)
    {
        var userToUpdateIndex = _users
            .Select(((x, i) => new {user = x, index = i}))
            .FirstOrDefault(x => x.user.Id == id);
        if (userToUpdateIndex == null) return null;
        return _users[userToUpdateIndex.index].UpdateUser(userView);
    }

    public static bool DeleteUser(Guid id)
    {
        return _users.Remove(_users.FirstOrDefault(x => x.Id == id)!);
    }

    #endregion
    
}