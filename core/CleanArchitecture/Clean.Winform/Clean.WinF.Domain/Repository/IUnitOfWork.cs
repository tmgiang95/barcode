using Clean.WinF.Domain.Entities.Users;
using System;

namespace Clean.WinF.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IAsyncRepository<User> UserRepository { get; }
        IAsyncRepository<Group> GroupRepository { get; }
        IAsyncRepository<Role> RoleRepository { get; }
        IAsyncRepository<UserGroup> UserGroupRepository { get; }
        IAsyncRepository<RoleGroup> RoleGroupRepository { get; }
        IAsyncRepository<RolePermission> RolePermissionRepository { get; }
        IAsyncRepository<Permission> PermissionRepository { get; }
        string DatabaseName { get; set; }
        int Complete();
    }
}
