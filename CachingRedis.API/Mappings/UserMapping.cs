using AutoMapper;
using CachingRedis.API.Dtos.Requests;
using CachingRedis.API.Entities;

namespace CachingRedis.API.Mappings;

/// <summary>
/// Information of user mapping
/// CreatedBy: ThiepTT(27/10/2023)
/// </summary>
public class UserMapping : Profile
{
    public UserMapping()
    {
        CreateMap<User, UserRequest>().ReverseMap();
    }
}