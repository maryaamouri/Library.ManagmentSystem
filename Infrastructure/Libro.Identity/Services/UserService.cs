using AutoMapper;
using Libro.Application.Identity.Services.UserInfo;
using Libro.Identity.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Libro.Identity.Services
{
    internal class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole<Guid>> _roleManager;
        private readonly IMapper _mapper;

        public UserService(
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            RoleManager<IdentityRole<Guid>> roleManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _roleManager = roleManager;
        }

        public async Task<User> AssignRole(Guid userId, Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role != null)
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user != null)
                {
                    await _userManager.AddToRoleAsync(user, role.Name);
                }
                return _mapper.Map<User>(user);
            }
            return null;
        }

        public async Task<IList<Role>> GetRoles()
        {
            var roles = await _roleManager.Roles.ToListAsync();
            return _mapper.Map<IList<Role>>(roles);
        }

        public async Task<User> GetUserById(Guid userId)
        {
            var user =  await _userManager.FindByIdAsync(userId.ToString());
            return _mapper.Map<User>(user);
        }

        public async Task<IList<Role>> GetUserRoles(Guid userId)
        {
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user != null)
            {
                var roles = await _userManager.GetRolesAsync(user);
               return _mapper.Map<IList<Role>>(roles);
            }
            return null;
        }

        public async Task<IList<User>> GetUsers()
        {
            var users = await _userManager.Users.ToListAsync();
            return _mapper.Map<IList<User>>(users); 
        }

        public async Task<User> RemoveRole(Guid userId, Guid roleId)
        {
            var role = await _roleManager.FindByIdAsync(roleId.ToString());
            if (role != null)
            {
                var user = await _userManager.FindByIdAsync(userId.ToString());
                if (user != null)
                {
                    await _userManager.RemoveFromRoleAsync(user, role.Name);
                }
                return _mapper.Map<User>(user);
            }
            return null;
        }

    }
}
