namespace MLaw.UserServices;

public static class UserServicesDomainErrorCodes
{
    public const string BAD_REQUEST = "UserServices:400";
    public const string NOT_FOUND = "UserServices:404";
    public const string INTERNAL_SERVER_ERROR = "UserServices:500";
    public const string UNAUTHORIZED = "UserServices:401";
    public const string FORBIDDEN = "UserServices:403";
    public const string CONFLICT = "UserServices:409";
    public const string UNPROCESSABLE_ENTITY = "UserServices:422";
    public const string TOO_MANY_REQUESTS = "UserServices:429";
    public const string SERVICE_UNAVAILABLE = "UserServices:503";
    public const string GATEWAY_TIMEOUT = "UserServices:504";
    public const string REQUEST_TIMEOUT = "UserServices:408";
    public const string PAYLOAD_TOO_LARGE = "UserServices:413";
    public const string NOT_IMPLEMENTED = "UserServices:501";
    public const string BAD_GATEWAY = "UserServices:502";
}
