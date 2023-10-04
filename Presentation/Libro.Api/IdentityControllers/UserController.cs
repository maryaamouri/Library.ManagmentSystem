using Libro.Application.Identity.Services.UserInfo;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Libro.Api.Identity
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IList<User>>> GetAllUsers()
        {
            var users = await _userService.GetUsers();
            return Ok(users);
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<User>> GetUserById(Guid userId)
        {
            var user = await _userService.GetUserById(userId);
            return Ok(user);
        }

        [HttpGet("GetAllRoles")]
        public async Task<ActionResult<IList<Role>>> GetAllRoles()
        {
            var roles = await _userService.GetRoles();
            return Ok(roles);
        }

        [HttpGet("GetUserRoles")]
        public async Task<ActionResult<IList<Role>>> GetUserRoles(Guid userId)
        {
            var roles = await _userService.GetUserRoles(userId);
            return Ok(roles);
        }

        [HttpPost("AssignRoleToUser")]
        public async Task<ActionResult<User>> AssignRoleToUser(Guid userId, Guid roleId)
        {
            var user = await _userService.AssignRole(userId, roleId);
            return Ok(user);
        }

        [HttpPost("RemoveRoleFromUser")]
        public async Task<ActionResult<User>> RemoveRoleFromUser(Guid userId, Guid roleId)
        {
            var user = await _userService.RemoveRole(userId, roleId);
            return Ok(user);
        }
    }
}
