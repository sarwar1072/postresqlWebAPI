using Autofac;
using Framework.LibraryMVC.Repositories;
using Framework.LibraryMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.LibraryMVC
{
    public class InfrastructureModule:Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;
        private readonly string _webHostEnvironment;

        public InfrastructureModule(string connectionString, string migrationAssemblyName,
            string webHostEnvironment)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
            _webHostEnvironment = webHostEnvironment;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ApplicationDbContext>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .WithParameter("migrationAssemblyName", _migrationAssemblyName)
                .InstancePerLifetimeScope();

            //builder.RegisterType<ApplicationDbContext>().As<IApplicationDbContext>()
            //    .WithParameter("connectionString", _connectionString)
            //    .WithParameter("migrationAssemblyName", _migrationAssemblyName)
            //    .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();

            builder.RegisterType<ProjectUnitOfWork>().As<IProjectUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<ProductServices>().As<IProductServices>().InstancePerLifetimeScope();
            base.Load(builder);
        }
    }
}
