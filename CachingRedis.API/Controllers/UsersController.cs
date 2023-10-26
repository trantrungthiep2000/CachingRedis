using CachingRedis.API.Attributes;
using CachingRedis.API.Data;
using CachingRedis.API.Entities;
using Dapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;

namespace CachingRedis.API.Controllers;

/// <summary>
/// Information of users controller
/// CreatedBy: ThiepTT(26/10/2023)
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly DataContext _dataContext;

    public UsersController(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    /// <summary>
    /// Get all users entity framework
    /// </summary>
    /// <returns>IActionResult</returns>
    /// CreatedBy: ThiepTT(26/10/2023)
    [HttpGet]
    [Route("GetAllUsersEF")]
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
    [Route("GetAllUsersDapper")]
    [Cache(3600)]
    public async Task<IActionResult> GetAllUsersDapper()
    {
        using (var connection = new SqlConnection(_dataContext.Database.GetDbConnection().ConnectionString))
        {
            connection.Open();
            var users = await connection.QueryAsync<User>("SELECT * FROM Users");

            return Ok(users);
        }
    }
}