using MessengerBack.Models.User;

namespace MessengerBack.Entities.DbContext.User;

public interface IDbContextUserHelper
{
    public List<UserView> GetUsersViewModel();
    public UserView? GetUserViewModelById(Guid id);
    public Guid AddUser(UserView userView);
    public UserView? UpdateUser(Guid id, UserView userView);
    public bool DeleteUser(Guid id);
    public UserView? UpdateUserProp(Guid id, string propName, string propValue);

}