using Newtonsoft.Json;
using System.Collections.Generic;

namespace Clean.WinF.Shared.DTOs.Permission
{
    public class PermissionGroupResponse
    {
        [JsonProperty("permissionCategoryId", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty("permissionCategoryName", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("permissionCategoryDescription", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }
        [JsonProperty("permissionCategoryCode", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
        [JsonProperty("permissions", NullValueHandling = NullValueHandling.Ignore)]
        public ICollection<PermissionResponse> Permissions { get; set; }
    }
}
