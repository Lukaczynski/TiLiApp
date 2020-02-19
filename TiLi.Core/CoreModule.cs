using Autofac;
using TiLi.Core.Interfaces.UseCases;
using TiLi.Core.UseCases;

namespace TiLi.Core
{
  public class CoreModule : Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      builder.RegisterType<RegisterUserUseCase>().As<IRegisterUserUseCase>().InstancePerLifetimeScope();
      builder.RegisterType<LoginUseCase>().As<ILoginUseCase>().InstancePerLifetimeScope();
    }
  }
}
