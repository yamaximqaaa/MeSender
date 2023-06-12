using MessengerBack.Entities.DbContext;
using MessengerBack.Models.User;
using Microsoft.AspNetCore.Mvc;

namespace MessengerBack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    #region Create

    [HttpPost]
    public ActionResult<Guid> CreateUser([FromBody]UserView user)
    {
        return Ok(DbContextHelper.AddUser(user));
    }

    #endregion
    
    #region Read

    [HttpGet]
    public ActionResult<List<UserView>> GetUsers()
    {
        return Ok(DbContextHelper.GetUsersViewModel());
    }
    [HttpPost]
    [Route("{id}")]
    public ActionResult<UserView> GetUsersById(Guid id)
    {
        var user = DbContextHelper.GetUserViewModelById(id);
        if (user == null) return BadRequest(new { Error = "Invalid user id" });
        return Ok(user);
    }

    [HttpPost]
    [Route("{id}/{propName}")]
    public ActionResult<string> GetUserProp(Guid id, string propName)
    {
        var user = DbContextHelper.GetUserViewModelById(id);
        if (user == null) return BadRequest("No such user");
        var userProp = user.GetType().GetProperty(propName);
        if (userProp == null) return BadRequest("Prop not found");
        var propValue = userProp.GetValue(user);
        return Ok(propValue);
    }

    #endregion
    
    #region Update
    // TODO: Add patch method
    [HttpPut]
    [Route("{id}")]
    public ActionResult<UserView> UpdateUser([FromRoute] Guid id, [FromBody] UserView userView)
    {
        var user = DbContextHelper.UpdateUser(id, userView);
        if (user == null) return BadRequest("Something went wrong during updating user");
        return Ok(user);
    }

    [HttpPatch]
    [Route("{id}")]
    public ActionResult<UserView> UpdateUserProp(Guid id, [FromQuery] string propName, [FromQuery] string propValue)
    {
        var user = DbContextHelper.UpdateUserProp(id, propName, propValue);
        if (user == null) return BadRequest("Something went wrong during updating user property");   // TODO: Dif exceptions to incorrect id, prop name and prop value
        return Ok(user);
    }

    #endregion
    
    #region Delete

    [HttpDelete]
    [Route("{id}")]
    public ActionResult<bool> DeleteUsersById(Guid id)
    {
        var result = DbContextHelper.DeleteUser(id);
        if(result) return Ok(result);
        return BadRequest(result);
    }

    #endregion
}