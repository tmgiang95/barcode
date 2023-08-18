namespace Clean.WinF.Shared.ErrorMessage
{
    public static class CustomErrorMessage
    {
        //Account controller
        public const string BP_INVALID_LDAP_CHECKED = "Verified by LDAP service - Invalid credentials! Please check again.";

        public const string BP_USER_NOT_FOUND = "User {0} is not found in the system.";

        public const string BP_USER_HAS_NO_PERMISSION = "User {0} has no permission.";

        public const string BP_USER_EXISTED_ALREADY = "User {0} is existed in the system already.";

        public const string BP_USER_WAITED_TO_APPROVAL = "User {0} is waitting for approval from admin.";

        public const string BP_INTERNAL_USER_UPDATED_FAIL = "Updating user {0} is failure. Please check the log file for more detail information.";

        public const string BP_INTERNAL_USER_CREATE_FAIL = "Creating user {0} is failure. Please check the log file for more detail information.";

        public const string BP_LDAP_USER_CREATE_FAIL = "Creating LDAP user {0} is failure. Please check the log file for more detail information.";

        public const string BP_INTERNAL_USER_REMOVED_FAIL = "Removing user {0} is failure. Please check the log file for more detail information.";

        public const string BP_INVALID_USER_STATUS = "Invalid user status! It should be one of (Active, InActive and Removed) user status.";

        public const string BP_USER_FULL_NAME_EMPTY = "Full name is not empty.";

        public const string BP_USER_NAME_EMPTY = "User name is not empty.";

        public const string BP_USER_EMAIL_EMPTY = "Email of {0} should be not empty.";

        public const string BP_USER_EMAIL_INVALID = "Email of {0} is invalid.";

        public const string BP_USER_INVALID_NAME = "Has the special character in the name of user.";

        public const string BP_WAM_INVALID_IV_USER_EMPTY = "Verified by WAM server - Can't detect user on WAM server or not.";

        public const string BP_WAM_EMPTY_X_FOWARDED_FOR = "Verified by WAM server - Can't detect request from empty WAM server";

        public const string BP_WAM_INVALID_X_FOWARDED_FOR = "Verified by WAM server - Can't detect request from valid WAM server";

        public const string BP_WAM_EMPTY_SERVER_IP = "Verified by WAM server - Can't detect ip from backend server";

        public const string BP_WAM_INVALID_SERVER_IP = "Verified by WAM server - Invalid ip from backend server";

        public const string BP_DISTRIBUTION_LIST_NAME_EMPTY = "Display name of distribution list should not be empty.";

        public const string BP_DISTRIBUTION_LIST_NOT_FOUND = "Distribution list is not found in the system.";

        public const string BP_DISTRIBUTION_LIST_EXISTED_ALREADY = "Distribution list {0} is existed in this group already.";

        public const string BP_DISTRIBUTION_LIST_EMAIL_EMPTY = "The email of distribution list {0} should be not empty.";

        public const string BP_DISTRIBUTION_LIST_EMAIL_INVALID = "The email of distribution list {0} is invalid.";

        public const string BP_DISTRIBUTION_LIST_GROUP_EMPTY = "Selected LDAP distribution list into group should not be empty.";

        public const string BP_DISTRIBUTION_LIST_ADD_FAIL = "Unable to add the distribution list {0} in to this group. Please check the log file for detail.";

        //Group controller
        public const string BP_GROUP_NOT_FOUND = "Group {0} is not found in the system.";

        public const string BP_GROUP_EXISTED_ALREADY = "Group {0} is existed in the system already.";

        public const string BP_GROUP_UPDATED_FAIL = "Updating group {0} is failure. Please check the log file for more detail information.";

        public const string BP_GROUP_CREATE_FAIL = "Creating group {0} is failure. Please check the log file for more detail information.";

        public const string BP_GROUP_REMOVED_FAIL = "Removing group {0} is failure. Please check the log file for more detail information.";

        public const string BP_INVALID_GROUP_STATUS = "Invalid group status! It should be one of (Active, InActive and Removed) group status";

        public const string BP_GROUP_STATUS_ACTIVE_ONLY = "Group status should be Active for this case.";

        public const string BP_USER_GROUP_EMPTY = "Selected users into group should not be empty.";

        public const string BP_USER_GROUP_EXISTED_ALREADY = "User {0} is existed in this group already.";

        public const string BP_ROLE_GROUP_EMPTY = "Selected roles into group should not be empty.";

        public const string BP_GROUP_INVALID_NAME = "Group name is invalid due to contain the special characters. Please try another.";

        public const string BP_GROUP_NAME_EMPTY = "Group name can not be empty. Please try another.";

        public const string BP_GROUP_INVALID_VALUE = "Group value should be a number value.";

        public const string BP_USER_GROUP_ID_VALUE = "Selected users should be number values.";

        public const string BP_GROUP_EXIST_SPECIAL_CHARS_NAME = "Group name {0} cannot contain special characters";

        public const string BP_GROUP_EXIST_SPECIAL_CHARS_DESCRIPTION = "Group description cannot contain special characters";

        //Role controller
        public const string BP_ROLE_NOT_FOUND = "Role {0} is not found in the system.";

        public const string BP_ROLE_EXISTED_ALREADY = "Role {0} is existed in the system already.";

        public const string BP_ROLE_UPDATED_FAIL = "Updating role {0} is failure. Please check the log file for more detail information.";

        public const string BP_ROLE_CREATE_FAIL = "Creating role {0} is failure. Please check the log file for more detail information.";

        public const string BP_ROLE_REMOVED_FAIL = "Removing role {0} is failure. Please check the log file for more detail information.";

        public const string BP_ROLE_ADD_PERMISSION_FAIL = "Add permissions to role {0} is failure. Please check the log file for more detail information.";

        public const string BP_ROLE_INVALID_NAME = "Role name is invalid.";

        public const string BP_ROLE_NAME_EMPTY = "Role name can not be empty. Please try another.";

        public const string BP_ROLE_REMOVED_FAIL_GROUP_ACTIVE = "Removing role {0} is failure. Some groups relate to this role are Active";

        public const string BP_ROLE_EXIST_SPECIAL_CHARS_NAME = "Role name {0} cannot contain special characters";

        public const string BP_ROLE_EXIST_SPECIAL_CHARS_DESCRIPTION = "Role description cannot contain special characters";


        //Permission controller
        public const string BP_PERMISSION_NOT_FOUND = "Permission {0} is not found in the system.";
        //Permission Group controller
        public const string BP_PERMISSION_GROUP_NOT_FOUND = "Permission Group {0} is not found in the system.";

        public const string BP_PERMISSION_GROUP_EXISTED_ALREADY = "Permission Group {0} is existed in the system already.";

        public const string BP_PERMISSION_GROUP_UPDATED_FAIL = "Updating Permission group {0} is failure. Please check the log file for more detail information.";

        public const string BP_PERMISSION_GROUP_CREATE_FAIL = "Creating Permission group {0} is failure. Please check the log file for more detail information.";

        public const string BP_PERMISSION_GROUP_REMOVED_FAIL = "Removing Permission group {0} is failure. Please check the log file for more detail information.";

        public const string BP_INVALID_PERMISSION_GROUP_STATUS = "Invalid Permission group status! It should be one of (Active, InActive and Removed) group status";

        public const string BP_PERMISSION_GROUP_STATUS_ACTIVE_ONLY = "Permission Group status should be Active for this case.";

        public const string BP_PERMISSION_GROUP_INVALID_NAME = "Permission Group name is invalid due to contain the special characters. Please try another.";

        public const string BP_PERMISSION_GROUP_ROLE_IS_MISSING_FAIL = "Permission Group is missing role.";

        public const string BP_PERMISSION_GROUP_EMPTY = "Permission Group Name can not be empty. Please try another.";

        //public const string BP_USER_GROUP_EMPTY = "Selected users into group should not be empty.";

        //public const string BP_ROLE_GROUP_EMPTY = "Selected roles into group should not be empty.";

        //public const string BP_GROUP_INVALID_NAME = "Group name is invalid due to contain the special characters. Please try another.";

        //public const string BP_GROUP_NAME_EMPTY = "Group name can not be empty. Please try another.";
        public const string BP_PERMISSION_EXISTED_ALREADY = "Permission {0} is existed in the system already.";

        public const string BP_PERMISSION_CREATE_FAIL = "Creating permission {0} is failure. Please check the log file for more detail information.";

        public const string BP_PERMISSION_REMOVED_FAIL = "Removing permission {0} is failure. Please check the log file for more detail information.";

        public const string BP_INVALID_PERMISSION_STATUS = "Invalid permission status! It should be one of (Active, InActive and Removed) group status";

        public const string BP_PERMISSION_UPDATED_FAIL = "Updating permission {0} is failure. Please check the log file for more detail information.";

        public const string BP_PERMISSION_NAME_EMPTY = "Permission name can not be empty. Please try another.";

        public const string BP_PERMISSION_INVALID_NAME = "Permission name is invalid due to contain the special characters. Please try another.";

        //PART
        public const string APP_PART_NAME_EMPTY = "Part name should not empty.";
        public const string APP_PART_CODE_EMPTY = "Part code should not empty.";
        public const string APP_PART_NOT_FOUND = "This Part information is not found.";
        public const string APP_PART_EXISTED_ALREADY = "This Part information is existed already.";
        public const string APP_PART_UPDATED_FAIL = "Update Part is failed";
        public const string APP_PART_INVALID_NAME = "Part name value is invalid";
        public const string APP_PART_INVALID_CODE = "Part code value is invalid";

    }
}
