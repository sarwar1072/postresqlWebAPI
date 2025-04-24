using Autofac;
using SimpleCrudeMVC.Models;

namespace SimpleCrudeMVC
{
    public class WebModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //builder.RegisterType<BlogViewModel>().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType<BlogModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<EditModel>().AsSelf().InstancePerLifetimeScope();
            //builder.RegisterType<FileHelper>().As<IFileHelper>().InstancePerLifetimeScope();
            builder.RegisterType<ProductListModel>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<ProductModel>().AsSelf().InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
