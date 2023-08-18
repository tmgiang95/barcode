namespace Clean.WinF.Shared.Constants
{
    public static class CustomErrorCode
    {
        //USER
        public const string BP_INVALID_LDAP_CHECKED = "BP_INVALID_LDAP_CHECKED";
        public const string BP_USER_NOT_FOUND = "BP_USER_NOT_FOUND";
        public const string BP_USER_HAS_NO_PERMISSION = "BP_USER_HAS_NO_PERMISSION";
        public const string BP_USER_EXISTED_ALREADY = "BP_USER_EXISTED_ALREADY";
        public const string BP_USER_WAITED_TO_APPROVAL = "BP_USER_WAITED_TO_APPROVAL";
        public const string BP_USER_SEND_EMAIL_REQUEST_FAIL = "BP_USER_SEND_EMAIL_REQUEST_FAIL";
        public const string BP_INTERNAL_USER_CREATE_FAIL = "BP_INTERNAL_USER_CREATE_FAIL";
        public const string BP_INTERNAL_USER_UPDATED_FAIL = "BP_INTERNAL_USER_UPDATED_FAIL";
        public const string BP_INTERNAL_USER_REMOVED_FAIL = "BP_INTERNAL_USER_REMOVED_FAIL";
        public const string BP_LDAP_USER_CREATE_FAIL = "BP_LDAP_USER_CREATE_FAIL";
        public const string BP_LDAP_USER_UPDATED_FAIL = "BP_LDAP_USER_UPDATED_FAIL";
        public const string BP_LDAP_USER_REMOVED_FAIL = "BP_LDAP_USER_REMOVED_FAIL";
        public const string BP_INVALID_USER_STATUS = "BP_INVALID_USER_STATUS";
        public const string BP_USER_FULL_NAME_EMPTY = "BP_USER_FULLNAME_EMPTY";
        public const string BP_USER_NAME_EMPTY = "BP_USER_NAME_EMPTY";
        public const string BP_USER_EMAIL_EMPTY = "BP_USER_EMAIL_EMPTY";
        public const string BP_USER_EMAIL_INVALID = "BP_USER_EMAIL_INVALID";
        public const string BP_USER_INVALID_NAME = "BP_USER_INVALID_NAME";
        public const string BP_WAM_INVALID_IV_USER_EMPTY = "BP_WAM_INVALID_IV_USER_EMPTY";
        public const string BP_WAM_INVALID_X_FOWARDED_FOR = "BP_WAM_INVALID_X_FOWARDED_FOR";
        public const string BP_WAM_EMPTY_X_FOWARDED_FOR = "BP_WAM_EMPTY_X_FOWARDED_FOR";
        public const string BP_WAM_EMPTY_SERVER_IP = "BP_WAM_INVALID_SERVER_IP";
        public const string BP_WAM_INVALID_SERVER_IP = "BP_WAM_INVALID_SERVER_IP";
        public const string BP_USER_INVALID_WAM_VALIDATION = "BP_USER_INVALID_WAM_VALIDATION";
        public const string BP_DISTRIBUTION_LIST_NAME_EMPTY = "BP_DISTRIBUTION_LIST_NAME_INVALID";
        public const string BP_DISTRIBUTION_LIST_NOT_FOUND = "BP_DISTRIBUTION_LIST_NOT_FOUND";
        public const string BP_DISTRIBUTION_LIST_EXISTED_ALREADY = "BP_DISTRIBUTION_LIST_EXISTED_ALREADY";
        public const string BP_DISTRIBUTION_LIST_EMAIL_EMPTY = "BP_DISTRIBUTION_LIST_EMAIL_EMPTY";
        public const string BP_DISTRIBUTION_LIST_EMAIL_INVALID = "BP_DISTRIBUTION_LIST_EMAIL_INVALID";
        public const string BP_DISTRIBUTION_LIST_GROUP_EMPTY = "BP_DISTRIBUTION_LIST_GROUP_EMPTY";
        public const string BP_DISTRIBUTION_LIST_ADD_FAIL = "BP_DISTRIBUTION_LIST_ADD_FAIL";

        //Group controller
        public const string BP_GROUP_NOT_FOUND = "BP_GROUP_NOT_FOUND";
        public const string BP_GROUP_EXISTED_ALREADY = "BP_GROUP_EXISTED_ALREADY";
        public const string BP_GROUP_CREATE_FAIL = "BP_GROUP_CREATE_FAIL";
        public const string BP_GROUP_UPDATED_FAIL = "BP_GROUP_UPDATED_FAIL";
        public const string BP_GROUP_REMOVED_FAIL = "BP_GROUP_REMOVED_FAIL";
        public const string BP_INVALID_GROUP_STATUS = "BP_INVALID_GROUP_STATUS";
        public const string BP_GROUP_STATUS_ACTIVE_ONLY = "BP_GROUP_STATUS_ACTIVE_ONLY";
        public const string BP_USER_GROUP_EMPTY = "BP_USER_GROUP_EMPTY";
        public const string BP_USER_GROUP_EXISTED_ALREADY = "BP_USER_GROUP_EXISTED_ALREADY";
        public const string BP_ROLE_GROUP_EMPTY = "BP_ROLE_GROUP_EMPTY";
        public const string BP_GROUP_INVALID_NAME = "BP_GROUP_INVALID_NAME";
        public const string BP_GROUP_INVALID_VALUE = "BP_GROUP_INVALID_VALUE";
        public const string BP_GROUP_NAME_EMPTY = "BP_GROUP_NAME_EMPTY";
        public const string BP_USER_GROUP_ID_VALUE = "BP_USER_GROUP_ID_VALUE";
        public const string BP_GROUP_EXIST_SPECIAL_CHARS_NAME = "BP_GROUP_EXIST_SPECIAL_CHARS_NAME";
        public const string BP_GROUP_EXIST_SPECIAL_CHARS_DESCRIPTION = "BP_GROUP_EXIST_SPECIAL_CHARS_DESCRIPTION";

        //Role controller
        public const string BP_ROLE_NOT_FOUND = "BP_ROLE_NOT_FOUND";
        public const string BP_ROLE_EXISTED_ALREADY = "BP_ROLE_EXISTED_ALREADY";
        public const string BP_ROLE_CREATE_FAIL = "BP_ROLE_CREATE_FAIL";
        public const string BP_ROLE_UPDATED_FAIL = "BP_ROLE_UPDATED_FAIL";
        public const string BP_ROLE_REMOVED_FAIL = "BP_ROLE_REMOVED_FAIL";
        public const string BP_ROLE_ADD_PERMISSION_FAIL = "BP_ROLE_ADD_PERMISSION_FAIL";
        public const string BP_ROLE_INVALID_NAME = "BP_ROLE_INVALID_NAME";
        public const string BP_ROLE_NAME_EMPTY = "BP_ROLE_NAME_EMPTY";
        public const string BP_ROLE_EXIST_SPECIAL_CHARS_NAME = "BP_ROLE_EXIST_SPECIAL_CHARS_NAME";
        public const string BP_ROLE_EXIST_SPECIAL_CHARS_DESCRIPTION = "BP_ROLE_EXIST_SPECIAL_CHARS_DESCRIPTION";

        //Permission controller 
        public const string BP_PERMISSION_NOT_FOUND = "BP_PERMISSION_NOT_FOUND";
        public const string BP_PERMISSION_EXISTED_ALREADY = "BP_PERMISSION_EXISTED_ALREADY";
        public const string BP_PERMISSION_CREATE_FAIL = "BP_PERMISSION_CREATE_FAIL";
        public const string BP_PERMISSION_UPDATED_FAIL = "BP_PERMISSION_UPDATED_FAIL";
        public const string BP_PERMISSION_REMOVED_FAIL = "BP_PERMISSION_REMOVED_FAIL";
        public const string BP_PERMISSION_ADD_PERMISSION_FAIL = "BP_PERMISSION_ADD_PERMISSION_FAIL";
        public const string BP_PERMISSION_INVALID_NAME = "BP_PERMISSION_INVALID_NAME";
        public const string BP_PERMISSION_NAME_EMPTY = "BP_PERMISSION_NAME_EMPTY";

        //Exception cases
        public const string BP_BAD_REQUEST_CLIENT_ERROR = "BP_BAD_REQUEST_CLIENT_ERROR";
        public const string BP_UNAUTHORIZED_CLIENT_ERROR = "BP_UNAUTHORIZED_CLIENT_ERROR";
        public const string BP_FORBIDDEN_CLIENT_ERROR = "BP_FORBIDDEN_CLIENT_ERROR";
        public const string BP_NOT_FOUND_CLIENT_ERROR = "BP_NOT_FOUND_CLIENT_ERROR";
        public const string BP_METHOD_NOT_ALLOWED_CLIENT_ERROR = "BP_METHOD_NOT_ALLOWED_CLIENT_ERROR";
        public const string BP_NOT_ACCEPTED_CLIENT_ERROR = "BP_NOT_ACCEPTED_CLIENT_ERROR";
        public const string BP_REQUEST_TIME_OUT_CLIENT_ERROR = "BP_REQUEST_TIME_OUT_CLIENT_ERROR";
        public const string BP_CONFLICT_CLIENT_ERROR = "BP_CONFLICT_CLIENT_ERROR";
        public const string BP_REQUEST_TOO_LARGE_CLIENT_ERROR = "BP_REQUEST_TOO_LARGE_CLIENT_ERROR";
        public const string BP_UNEXPECTED_CLIENT_ERROR = "BP_UNEXPECTED_CLIENT_ERROR";
        public const string BP_UNKNOWN_CLIENT_ERROR = "BP_UNKNOWN_CLIENT_ERROR";

        public const string BP_INTERNAL_SERVER_ERROR = "BP_INTERNAL_SERVER_ERROR";
        public const string BP_NOT_IMPLEMENTED_SERVER_ERROR = "BP_NOT_IMPLEMENTED_SERVER_ERROR";
        public const string BP_BAD_GATEWAY_SERVER_ERROR = "BP_BAD_GATEWAY_SERVER_ERROR";
        public const string BP_SERVICE_UNAVAILABLE_SERVER_ERROR = "BP_SERVICE_UNAVAILABLE_SERVER_ERROR";
        public const string BP_GATEWAY_TIMEOUT_SERVER_ERROR = "BP_GATEWAY_TIMEOUT_SERVER_ERROR";
        public const string BP_HTTP_VERSION_NOT_SUPPORT_SERVER_ERROR = "BP_HTTP_VERSION_NOT_SUPPORT_SERVER_ERROR";
        public const string BP_NETWORK_AUTHEN_REQ_SERVER_ERROR = "BP_NETWORK_AUTHEN_REQ_SERVER_ERROR";
        public const string BP_UNKNOWN_SERVER_ERROR = "BP_UNKNOWN_SERVER_ERROR";

        //Permission Group controller 
        public const string BP_PERMISSION_GROUP_EMPTY = "BP_PERMISSION_GROUP_EMPTY";
        public const string BP_PERMISSION_GROUP_NOT_FOUND = "BP_PERMISSION_GROUP_NOT_FOUND";
        public const string BP_INVALID_PERMISSION_GROUP_STATUS = "BP_INVALID_PERMISSION_GROUP_STATUS";
        public const string BP_PERMISSION_GROUP_EXISTED_ALREADY = "BP_PERMISSION_GROUP_EXISTED_ALREADY";
        public const string BP_PERMISSION_GROUP_INVALID_NAME = "BP_PERMISSION_GROUP_INVALID_NAME";
        public const string BP_PERMISSION_GROUP_REMOVED_FAIL = "BP_PERMISSION_GROUP_REMOVED_FAIL";
        public const string BP_PERMISSION_GROUP_UPDATED_FAIL = "BP_PERMISSION_GROUP_UPDATED_FAIL";
        public const string BP_PERMISSION_GROUP_ROLE_IS_MISSING_FAIL = "BP_PERMISSION_GROUP_ROLE_IS_MISSING_FAIL";


        //Part 
        public const string APP_PART_NAME_EMPTY = "APP_PART_NAME_EMPTY";
        public const string APP_PART_CODE_EMPTY = "APP_PART_CODE_EMPTY";
        public const string APP_PART_NOT_FOUND = "APP_PART_NOT_FOUND";
        public const string APP_PART_UPDATED_FAIL = "APP_PART_UPDATED_FAIL";
        public const string APP_PART_INVALID_NAME = "APP_PART_INVALID_NAME";
        public const string APP_PART_INVALID_CODE = "APP_PART_INVALID_CODE";
        //public const string BP_INVALID_PERMISSION_GROUP_STATUS = "BP_INVALID_PERMISSION_GROUP_STATUS";
        //public const string BP_PERMISSION_GROUP_EXISTED_ALREADY = "BP_PERMISSION_GROUP_EXISTED_ALREADY";
        //public const string BP_PERMISSION_GROUP_INVALID_NAME = "BP_PERMISSION_GROUP_INVALID_NAME";
        //public const string BP_PERMISSION_GROUP_REMOVED_FAIL = "BP_PERMISSION_GROUP_REMOVED_FAIL";
        //public const string BP_PERMISSION_GROUP_ROLE_IS_MISSING_FAIL = "BP_PERMISSION_GROUP_ROLE_IS_MISSING_FAIL";
    }

    public static class CustomOperationCodes
    {
        public const string APP_PART_ADD_SUCCESS = "APP_PART_ADD_SUCCESS";
        public const string APP_PART_ADD_FAIL = "APP_PART_ADD_FAIL";

        public const string APP_PART_UPDATE_SUCCESS = "APP_PART_UPDATE_SUCCESS";
        public const string APP_PART_UPDATE_FAIL = "APP_PART_UPDATE_FAIL";

        public const string APP_PART_DELETE_SUCCESS = "APP_PART_DELETE_SUCCESS";
        public const string APP_PART_DELETE_FAIL = "APP_PART_DELETE_FAIL";
    }
}
