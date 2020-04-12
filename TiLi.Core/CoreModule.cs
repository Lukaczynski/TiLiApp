using Autofac;
using TiLi.Core.Interfaces.UseCases;
using TiLi.Core.UseCases;

namespace TiLi.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            #region Account
            builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetUserRolesUseCase>().As<IGetUserRoleUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetUsersUseCase>().As<IGetUsersUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<AddRoleToUserUseCase>().As<IAddRoleToUserUseCase>().InstancePerLifetimeScope();
            #endregion Account

            #region Role
            builder.RegisterType<CreateRoleUseCase>().As<ICreateRoleUseCase>().InstancePerLifetimeScope();
            #endregion Role

            #region Project
            builder.RegisterType<CreateProjectUseCase>().As<ICreateProjectUseCase>().InstancePerLifetimeScope();
            builder.RegisterType<GetProjectsUseCase>().As<IGetProjectsUseCase>().InstancePerLifetimeScope();
            #endregion Project

            #region TimeEntry
            builder.RegisterType<AddTimeEntryUseCase>().As<IAddTimeEntryUseCase>().InstancePerLifetimeScope();
            #endregion TimeEntry
            //<-GENERATED_MODULE_TEMPLATE_ADD->
        }
    }
}
