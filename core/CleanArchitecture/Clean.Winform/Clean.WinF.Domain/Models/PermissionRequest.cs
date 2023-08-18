using System.ComponentModel.DataAnnotations;

namespace Clean.WinF.Domain.Models
{
    public class PermissionAddNewRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string ApiUrl { get; set; }

        public string Description { get; set; }
        [Required]
        public int PermissionGroupId { get; set; }
        public string Status { get; set; }
    }

    public class PermissionUpdateRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Code { get; set; }
        [Required]
        public string ApiUrl { get; set; }

        public string Description { get; set; }
        [Required]
        public int PermissionGroupId { get; set; }
        public string Status { get; set; }
    }

    public class DeletedPermissionRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
