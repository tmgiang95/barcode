using Clean.WinF.Domain.Entities.Users;
using Clean.WinF.Domain.IServices;
using Clean.WinF.Domain.Models;
using Clean.WinF.Shared.DTOs.LDAP;
using Clean.WinF.Shared.DTOs.Users;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Clean.WinF.Domain.SeedData
{
    public class Seed
    {
        private readonly IAccountService _userManager;
        private readonly IRoleService _roleService;
        private readonly IGroupService _groupService;
        private readonly IPermissionService _permissionService;

        public Seed(IAccountService userManager, IRoleService roleService, IGroupService groupService, IPermissionService permissionService)
        {
            _userManager = userManager;
            _roleService = roleService;
            _groupService = groupService;
            _permissionService = permissionService;
        }

        public void InitialSeedData(bool isRunningTest)
        {
            if (!_userManager.GetAllUsers().Any())
            {
                var jsonData = LoadDataFromJson(isRunningTest);
                var roles = new List<string>();
                var permissions = new List<string>();
                foreach (var item in jsonData.PermissionCategory)
                {
                    item.CreatedBy = "Admin";
                    item.CreatedDate = DateTime.UtcNow;
                    var permissionCategory = (PermissionDto)_permissionService.AddNew(item).Result.Data;
                    if (permissions.FirstOrDefault(x => x.Equals(permissionCategory.Id.ToString())) == null)
                    {
                        permissions.Add(permissionCategory.Id.ToString());
                    }
                    if (permissionCategory != null)
                    {
                        foreach (var perDto in jsonData.Permissions)
                        {
                            perDto.CreatedBy = "Admin";
                            perDto.CreatedDate = DateTime.UtcNow;
                            perDto.ParentId = permissionCategory.Id;
                            var per = (PermissionDto)_permissionService.AddNew(perDto).Result.Data;

                            if (permissions.FirstOrDefault(x => x.Equals(per.Id.ToString())) == null)
                            {
                                permissions.Add(per.Id.ToString());
                            }
                        }
                    }
                }

                foreach (var item in jsonData.Roles)
                {
                    item.CreatedBy = "Admin";
                    item.CreatedDate = DateTime.UtcNow;
                    item.Permissions = new List<string>();
                    var role = _roleService.CreateNewRole(item).Result;

                    if (roles.FirstOrDefault(x => x.Equals(role.RoleId.ToString())) == null)
                    {
                        roles.Add(role.RoleId.ToString());
                    }

                    if (item.RoleName.Equals("admin"))
                    {
                        var updatedRole = _roleService.UpdateRole(role).Result;
                    }
                }

                foreach (var item in jsonData.Groups)
                {
                    item.CreatedBy = "Admin";
                    item.CreatedDate = DateTime.UtcNow;
                    item.Users = new List<ShortUserDto>();
                    var addUsersDistributionListGroupRequest = new AddUsersDistributionListGroupRequest
                    {
                        LDAPUsers = new List<LdapDto>()
                    };
                    foreach (var user in jsonData.Users)
                    {
                        var ldapDto = new LdapDto
                        {
                            UserId = user.UserName,
                            DisplayName = user.DisplayName,
                            Email = user.Email
                        };
                        addUsersDistributionListGroupRequest.LDAPUsers.Add(ldapDto);
                    }

                    var group = _groupService.CreateNewGroup(item).Result;
                    _ = _groupService.AddSelectedRolesToGroup(group, roles).Result;
                    _ = _groupService.AddSelectedUsersToGroup(group, addUsersDistributionListGroupRequest).Result;
                }
            }
        }

        private SeedModel LoadDataFromJson(bool isRunningTest)
        {
            var seedModel = new SeedModel();
            string assemblyPath = Assembly.GetExecutingAssembly().Location;
            string assemblyDirectory = Path.GetDirectoryName(assemblyPath);

            if (File.ReadAllText(Path.Combine(assemblyDirectory, @"SeedData\Users.json")) != null
                && File.ReadAllText(Path.Combine(assemblyDirectory, @"SeedData\Users.json")).Any())
            {
                seedModel.Users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(Path.Combine(assemblyDirectory, @"SeedData\Users.json")));
            }

            var roleFilePath = Path.Combine(assemblyDirectory, @"SeedData\Roles.json");
            if (isRunningTest) roleFilePath = Path.Combine(assemblyDirectory, @"SeedData\Roles_Test_Data.json");
            if (File.ReadAllText(roleFilePath) != null
                && File.ReadAllText(roleFilePath).Any())
            {
                seedModel.Roles = JsonConvert.DeserializeObject<List<RoleDto>>(File.ReadAllText(roleFilePath));
            }


            string groupFilePath = Path.Combine(assemblyDirectory, @"SeedData\Groups.json");
            if(isRunningTest) groupFilePath = Path.Combine(assemblyDirectory, @"SeedData\Groups_Test_Data.json");
            if (File.ReadAllText(groupFilePath) != null
                && File.ReadAllText(groupFilePath).Any())
            {
                seedModel.Groups = JsonConvert.DeserializeObject<List<GroupDto>>(File.ReadAllText(groupFilePath));
            }

            if (File.ReadAllText(Path.Combine(assemblyDirectory, @"SeedData\PermissionCategory.json")) != null
                && File.ReadAllText(Path.Combine(assemblyDirectory, @"SeedData\PermissionCategory.json")).Any())
            {
                seedModel.PermissionCategory = JsonConvert.DeserializeObject<List<PermissionDto>>(File.ReadAllText(Path.Combine(assemblyDirectory, @"SeedData\PermissionCategory.json")));
            }

            if (File.ReadAllText(Path.Combine(assemblyDirectory, @"SeedData\Permissions.json")) != null
                && File.ReadAllText(Path.Combine(assemblyDirectory, @"SeedData\Permissions.json")).Any())
            {
                seedModel.Permissions = JsonConvert.DeserializeObject<List<PermissionDto>>(File.ReadAllText(Path.Combine(assemblyDirectory, @"SeedData\Permissions.json")));
            }

            return seedModel;
        }
    }

    public class SeedModel
    {
        public List<User> Users { get; set; } = new List<User>();
        public List<RoleDto> Roles { get; set; } = new List<RoleDto>();
        public List<GroupDto> Groups { get; set; } = new List<GroupDto>();
        public List<PermissionDto> PermissionCategory { get; set; } = new List<PermissionDto>();
        public List<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();
    }
}
