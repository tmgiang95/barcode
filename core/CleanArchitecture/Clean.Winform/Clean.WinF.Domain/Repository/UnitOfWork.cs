using Clean.WinF.Domain.DbContexts;
using Clean.WinF.Domain.Entities.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Clean.WinF.Domain.Repository
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        public string DatabaseName { get; set; }
        private readonly BlueprintContext _blueprintContext;
        private readonly ILogger _logger;

        public IAsyncRepository<User> UserRepository { get; private set; }

        public IAsyncRepository<Group> GroupRepository { get; private set; }

        public IAsyncRepository<Role> RoleRepository { get; private set; }

        public IAsyncRepository<UserGroup> UserGroupRepository { get; private set; }

        public IAsyncRepository<RoleGroup> RoleGroupRepository { get; private set; }

        public IAsyncRepository<Permission> PermissionRepository { get; private set; }

        public IAsyncRepository<RolePermission> RolePermissionRepository { get; private set; }

        public UnitOfWork(BlueprintContext context, ILoggerFactory loggerFactory)
        {
            _blueprintContext = context;
            DatabaseName = context.Database.GetDbConnection().Database;

            _logger = loggerFactory.CreateLogger("logs");
            UserRepository = new EfRepository<User>(_blueprintContext);
            GroupRepository = new EfRepository<Group>(_blueprintContext);
            RoleRepository = new EfRepository<Role>(_blueprintContext);
            UserGroupRepository = new EfRepository<UserGroup>(_blueprintContext);
            RoleGroupRepository = new EfRepository<RoleGroup>(_blueprintContext);
            RolePermissionRepository = new EfRepository<RolePermission>(_blueprintContext);
            PermissionRepository = new EfRepository<Permission>(_blueprintContext);
        }

        public int Complete()
        {
            return _blueprintContext.SaveChanges();
        }

        public void Dispose()
        {
            _blueprintContext.Dispose();
        }
    }
}
