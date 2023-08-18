
namespace Clean.WinF.Shared.Enums
{
    public enum UserStatus
    {
        InActive,
        Active,
        Removed
    }

    public enum UserRequest
    {
        RequestAccess,
        CreateNew,
        Update,
        Delete
    }

    public enum UserType
    {
        Normal,
        LDAP
    }
}
