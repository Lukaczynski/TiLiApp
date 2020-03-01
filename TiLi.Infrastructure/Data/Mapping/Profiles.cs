using AutoMapper;
using TiLi.Core.Domain.Entities;
using TiLi.Infrastructure.Data.Entities;


namespace TiLi.Infrastructure.Data.Mapping
{
    public class DataProfile : Profile
    {
        public DataProfile()
        {
            #region User
            CreateMap<User, AppUser>()
                .ConstructUsing(u => new AppUser
                {
                    Id = u.Id,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    UserName = u.UserName,
                    PasswordHash = u.PasswordHash
                });

            CreateMap<AppUser, User>()
                .ConstructUsing(au => new User(au.FirstName, au.LastName, au.Email, au.UserName, au.Id, au.PasswordHash));
            #endregion User

            #region Project
            CreateMap<Core.Domain.Entities.Project, Entities.Project>()
                .ConstructUsing(dep => new Entities.Project()
                {
                    Name = dep.Name,
                    Description = dep.Description
                });

            CreateMap<Entities.Project, Core.Domain.Entities.Project>()
                .ConstructUsing(dep => new Core.Domain.Entities.Project(dep.Name, dep.Description, dep.Id));
            #endregion Project

            #region Role
            CreateMap<Role, AppRole>()
                .ConstructUsing(x => new AppRole()
                {
                    Name = x.Name,
                    ConcurrencyStamp = x.ConcurrencyStamp,
                    Id = x.Id,
                    NormalizedName = x.NormalizedName
                });
            CreateMap<AppRole, Role>()
                .ConvertUsing(x => new Role(x.Name, x.NormalizedName, x.ConcurrencyStamp, x.Id));
            #endregion Role
        }
    }
}
