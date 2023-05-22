using MessengerBack.Entities.DbContext;
using MessengerBack.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MessengerBack.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    #region Create

    [HttpPost]
    public ActionResult<Guid> CreateUser([FromBody]UserViewModel user)
    {
        return Ok(DbContextHelper.AddUser(user));
    }

    #endregion
    
    #region Read

    [HttpGet]
    public ActionResult<List<UserViewModel>> GetUsers()
    {
        return Ok(DbContextHelper.GetUsersViewModel());
    }
    [HttpPost]
    [Route("{id}")]
    public ActionResult<UserViewModel> GetUsersById(Guid id)
    {
        var user = DbContextHelper.GetUserViewModelById(id);
        if (user == null) return BadRequest(new { Error = "Invalid user id" });
        return Ok(user);
    }
    
    #endregion
    
    #region Update
    // TODO: Add patch method
    [HttpPut]
    [Route("{id}")]
    public ActionResult<UserViewModel> UpdateUser([FromRoute] Guid id, [FromBody] UserViewModel userView)
    {
        var user = DbContextHelper.UpdateUser(id, userView);
        if (user == null) return BadRequest("Something went wrong during updating user");
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