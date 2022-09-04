using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using WebApi.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public ActionResult AddUser(User u)
        {
            bool added = _userService.AddUser(u);
            if (added)
            {
                return Ok(true);
            }
            else
            {
                return StatusCode(500, "Failed to create user");
            }
        }

        [HttpGet]
        public ActionResult AllUsers()
        {
            List<User> users = _userService.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public ActionResult GetUser(int id)
        {
            User user = _userService.GetUserById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateUser(int id, User u)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest("request body not valid");

                u.Id = id;
                User toUpdate = _userService.GetUserById(id);
                if (toUpdate != null)
                {
                    User updated = _userService.UpdateUser(u);
                    return Ok(updated);
                }
                else
                {
                    return NotFound($"Failed To Updated User With Id {id}");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpDelete]
        public ActionResult DeleteUser(int id)
        {
            bool deleted = _userService.DeleteUserById(id);
            if (deleted)
            {
                return Ok(deleted);
            }
            else
            {
                return BadRequest($"Failed To Delete User With Id {id}");
            }
        }

    }
}
