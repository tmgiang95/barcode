namespace Clean.WinF.Shared.Enums
{
    public enum GroupRequest
    {
        CreateNew,
        Update,
        Remove
    }

    public enum GroupStatus
    {
        Active,
        InActive,
        Removed
    }

    public enum UserGroupAction
    {
        Add,
        Remove
    }

    public enum RoleGroupAction
    {
        Add,
        Remove
    }

    public enum RemovedUserType
    {
        User,
        DistributionList
    }
}
