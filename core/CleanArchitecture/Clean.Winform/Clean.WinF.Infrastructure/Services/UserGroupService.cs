using Clean.WinF.Domain.Entities.Users;
using Clean.WinF.Domain.IServices;
using Clean.WinF.Domain.Repository;
using Clean.WinF.Shared.DTOs.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Clean.WinF.Infrastructure.Services
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IConfiguration _config;
        private readonly ILogger<UserGroupService> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public UserGroupService(ILogger<UserGroupService> logger,
                           IConfiguration config, IUnitOfWork unitOfWork)

        {
            _config = config;
            _logger = logger;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserGroupDto> DeleteteGroup(UserGroupDto removedGroup)
        {

            var removedUser = new UserGroup()
            {
                GroupId = removedGroup.GroupId,
                UserId = removedGroup.UserId
            };
            var removedResult = _unitOfWork.UserGroupRepository.DeleteAsync(removedUser);
            _unitOfWork.Complete();
            return removedGroup;
        }
    }
}
