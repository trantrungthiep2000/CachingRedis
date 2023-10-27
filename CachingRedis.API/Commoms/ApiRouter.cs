namespace CachingRedis.API.Commoms;

/// <summary>
/// Information of api router
/// CreatedBy: ThiepTT(27/10/2023)
/// </summary>
public static class ApiRouter
{
    /// <summary>
    /// Root
    /// </summary>
    public const string Root = "api/[controller]";

    /// <summary>
    /// Api
    /// </summary>
    public const string Api = "api";

    /// <summary>
    /// Infomation of user
    /// CreatedBy: ThiepTT(27/10/2023)
    /// </summary>
    public static class User
    {
        /// <summary>
        /// Get all users entity framework
        /// </summary>
        public const string GetAllUsersEF = "GetAllUsersEF";

        /// <summary>
        /// Get all users dapper
        /// </summary>
        public const string GetAllUsersDapper = "GetAllUsersDapper";

        /// <summary>
        /// Create user
        /// </summary>
        public const string CreateUser = "CreateUser";
    }
}