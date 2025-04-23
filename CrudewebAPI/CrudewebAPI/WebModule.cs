using Autofac;
using CrudewebAPI.Models;
using Framework;

namespace CrudewebAPI
{
    public class WebModule:Module
    {

        protected override void Load(ContainerBuilder builder)
        {


            //builder.RegisterType<PAndSUnitOfWork>().As<IPAndSUnitOfWork>()
            //    .InstancePerLifetimeScope();

            //builder.RegisterType<QuestionRepository>().As<IQuestionRepository>()
            //    .InstancePerLifetimeScope();
            builder.RegisterType<ProductModel>().AsSelf()
                .InstancePerLifetimeScope();

            //builder.RegisterType<PublicLayoutModel>()
            //   .AsSelf()
            //   .InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
