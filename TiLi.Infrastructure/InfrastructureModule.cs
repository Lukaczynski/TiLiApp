using Autofac;
using TiLi.Core.Interfaces.Gateways.Repositories;
using TiLi.Core.Interfaces.Services;
using TiLi.Infrastructure.Auth;
using TiLi.Infrastructure.Data.EntityFramework.Repositories;
namespace TiLi.Infrastructure
{
    public class InfrastructureModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RoleRepository>().As<IRoleRepository>().InstancePerLifetimeScope();
            builder.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProjectRepository>().As<IProjectRepository>().InstancePerLifetimeScope();
            builder.RegisterType<JwtFactory>().As<IJwtFactory>().SingleInstance();
        }
    }
}
