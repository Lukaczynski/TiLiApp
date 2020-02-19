using AutoMapper;
using TiLi.Core.Domain.Entities;
using TiLi.Infrastructure.Data.Entities;


namespace TiLi.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            CreateMap<User, AppUser>().ConstructUsing(u => new AppUser {Id=u.Id, FirstName = u.FirstName, LastName = u.LastName, UserName = u.UserName, PasswordHash = u.PasswordHash});
            CreateMap<AppUser, User>().ConstructUsing(au => new User(au.FirstName, au.LastName, au.Email, au.UserName, au.Id, au.PasswordHash));
        }
    }
}
