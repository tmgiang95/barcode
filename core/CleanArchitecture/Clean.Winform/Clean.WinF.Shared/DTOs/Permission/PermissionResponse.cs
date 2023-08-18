using Newtonsoft.Json;

namespace Clean.WinF.Shared.DTOs.Permission
{
    public class PermissionResponse
    {
        [JsonProperty("permissionId", NullValueHandling = NullValueHandling.Ignore)]
        public int Id { get; set; }
        [JsonProperty("permissionName", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
        [JsonProperty("permissionCode", NullValueHandling = NullValueHandling.Ignore)]
        public string Code { get; set; }
        [JsonProperty("belongsToRole", NullValueHandling = NullValueHandling.Ignore)]
        public bool BelongsToRole { get; set; }

        [JsonIgnore]
        [JsonProperty("parentId", NullValueHandling = NullValueHandling.Ignore)]
        public int ParentId { get; set; }
    }
}
