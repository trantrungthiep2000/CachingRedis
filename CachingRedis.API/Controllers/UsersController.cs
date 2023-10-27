using AutoMapper;
using CachingRedis.API.Attributes;
using CachingRedis.API.Commoms;
using CachingRedis.API.Data;
using CachingRedis.API.Dtos.Requests;
using CachingRedis.API.Entities;
using CachingRedis.API.Services;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace CachingRedis.API.Controllers;

/// <summary>
/// Information of users controller
/// CreatedBy: ThiepTT(26/10/2023)
/// </summary>
[Route($"{ApiRouter.Root}")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DataContext _dataContext;
    private readonly IMapper _mapper;
    private readonly IResponseCacheService _responseCacheService;

    public UsersController(DataContext dataContext, IMapper mapper, IResponseCacheService responseCacheService)
    {
        _dataContext = dataContext;
        _mapper = mapper;
        _responseCacheService = responseCacheService;
    }

    /// <summary>
    /// Get all users entity framework
    /// </summary>
    /// <returns>IActionResult</returns>
    /// CreatedBy: ThiepTT(26/10/2023)
    [HttpGet]
    [Route($"{ApiRouter.User.GetAllUsersEF}")]
    [Cache(3600)]
    public async Task<IActionResult> GetAllUsersEF()
    {
        var users = await _dataContext.Users.ToListAsync();

        return Ok(users);
    }

    /// <summary>
    /// Get all users dapper
    /// </summary>
    /// <returns>IActionResult</returns>
    /// CreatedBy: ThiepTT(26/10/2023)
    [HttpGet]
    [Route($"{ApiRouter.User.GetAllUsersDapper}")]
    [Cache(3600)]
    public async Task<IActionResult> GetAllUsersDapper()
    {
        using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
        {
            var users = await connection.QueryAsync<User>("SELECT * FROM Users");

            return Ok(users);
        }
    }

    /// <summary>
    /// Create user
    /// </summary>
    /// <param name="userRequest">UserRequest</param>
    /// <returns>IActionResult</returns>
    /// CreatedBy: ThiepTT(27/10/2023)
    [HttpPost]
    [Route($"{ApiRouter.User.CreateUser}")]
    public async Task<IActionResult> CreateUser(UserRequest userRequest)
    {
        var user = _mapper.Map<User>(userRequest);

        await _dataContext.Users.AddAsync(user);
        var result = await _dataContext.SaveChangesAsync();

        var pattern = ConfigSystem.GeneratePattern(ControllerContext.ActionDescriptor.ControllerTypeInfo.Name);

        await _responseCacheService.RemoveCacheResponseAsync(pattern);

        return Ok(result);
    }
}