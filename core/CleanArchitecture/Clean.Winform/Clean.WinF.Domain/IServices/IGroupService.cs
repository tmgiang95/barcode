using Clean.WinF.Domain.Models;
using Clean.WinF.Shared.DTOs.Users;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Clean.WinF.Domain.IServices
{
    public interface IGroupService
    {
        Task<GroupDto> CreateNewGroup(GroupDto addGroup);
        Task<GroupDto> AddSelectedUsersToGroup(GroupDto group, AddUsersDistributionListGroupRequest addUserDistributionList);
        Task<GroupDto> AddSelectedRolesToGroup(GroupDto group, IList<string> selectedRoles);
        Task<GroupDto> GetGroupById(int groupId);
        Task<IList<GroupDto>> SearchGroupByCondition(string searchGroup);
        Task<IEnumerable<GroupDto>> ListAllGroupsAsync();
        Task<GroupDto> UpdateGroup(GroupDto updatedGroup);
        Task<GroupDto> DeleteGroup(GroupDto deletedGroup);
        Task<GroupDto> RemoveUserToGroup(int groupID, int userID, string UserType);
        Task<GroupDto> RemoveRoleToGroup(int groupID, int roleId);
        Task<GroupDto> RemoveDistributionListsToGroup(int groupID, int distribuitionListId);
        Task<IList<UserDto>> SearchUserInGroup(int groupId, string userName);
    }
}
