using _3TierWebApi.Models;
using Business.UserLogic;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _3TierWebApi.Controllers
{
    [Route("api/user/")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserLogic userLogic = new();

        //get all users
        [Route("getAll")]
        [HttpGet]
        public async Task<List<UserViewModel>> GetAllUsers()
        {
            List<UserViewModel> usersList = new();

            var users = await userLogic.GetAllUsersAsync();

            foreach (var user in users)
            {
                UserViewModel userModel = new()
                {
                    Id = user.Id,
                    Name = user.Username,
                    PositionId = user.PositionRefId
                };
                usersList.Add(userModel);
            }

            return usersList;
        }

        //get user by id
        [Route("getByid")]
        [HttpGet]
        public async Task<ActionResult<UserViewModel>> GetUser(int id)
        {
            var user = await userLogic.GetUserByIdAsync(id);

            if (user == null)
            {
                return NotFound("User not found!");
            }
            else
            {
                UserViewModel userModel = new()
                {
                    Id = user.Id,
                    Name = user.Username,
                    PositionId = user.PositionRefId
                };

                return Ok(userModel);
            }
        }

        //add user
        [Route("add")]
        [HttpPost]
        public async Task<IActionResult> AddUserAsync([FromBody] UserCreateModel userCreateModel)
        {
            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            bool result = await userLogic.CreateUserAsync(userCreateModel.Name, userCreateModel.PositionId);

            return result == true ? Ok("User created") : UnprocessableEntity();
        }


        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserUpdateModel userUpdateModel)
        {

            if (!ModelState.IsValid)
                return UnprocessableEntity(ModelState);

            bool result = await userLogic.UpdateUserAsync(id, userUpdateModel.Name, userUpdateModel.PositionId);

            return result == true ? Ok("User updated") : UnprocessableEntity();
        }

        //delete user
        [Route("delete")]
        [HttpDelete]
        public async Task<bool> DeleteUser(int id)
        {
            return await userLogic.DeleteUserAsync(id);
        }
    }
}
