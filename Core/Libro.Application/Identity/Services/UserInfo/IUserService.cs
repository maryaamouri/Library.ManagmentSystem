namespace Libro.Application.Identity.Services.UserInfo
{
    public interface IUserService
    {
        Task<User> AssignRole(Guid userId, Guid roleId);
        Task<User> GetUserById(Guid userId);
        Task <IList<User>> GetUsers();
        Task<User> RemoveRole(Guid userId, Guid roleId);
        Task<IList<Role>> GetRoles();
        Task<IList<Role>> GetUserRoles(Guid userId);
    }
}
