using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Cus.Models.DbContextFactory;
using Cus.Models.Interface;
using Cus.Models.Repository;
using Cus.MVC5.Controllers.Api;
using Cus.Services.Interface;
using Cus.Services.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace Cus.MVC5.App_Start
{
    public class AutofacConfig
    {
        public static void Bootstrapper()
        {
            //容器建立者
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;

            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<CustomersService>().As<ICustomersService>().InstancePerRequest();
            builder.RegisterType<EmployeesService>().As<IEmployeesService>().InstancePerRequest();
            builder.RegisterType<OrdersService>().As<IOrdersService>().InstancePerRequest();
            builder.RegisterType<ProductsService>().As<IProductsService>().InstancePerRequest();
            builder.RegisterType<ShippersService>().As<IShippersService>().InstancePerRequest();

            string connectionString = ConfigurationManager.ConnectionStrings["MSSQLDbConfig"].ConnectionString;

            //註冊DbContextFactory
            builder.RegisterType<DbContextFactory>()
                .WithParameter("connectionString", connectionString)
                .As<IDbContextFactory>()
                .InstancePerRequest();

            builder.RegisterType<CustomersRepository>()
                .WithParameter("IUnitOfWork", new UnitOfWork(new DbContextFactory(connectionString)))
                .As<ICustomersRepository>().InstancePerRequest();

            builder.RegisterType<EmployeesRepository>()
                .WithParameter("IUnitOfWork", new UnitOfWork(new DbContextFactory(connectionString)))
                .As<IEmployeesRepository>().InstancePerRequest();

            builder.RegisterType<OrdersRepository>()
                .WithParameter("IUnitOfWork", new UnitOfWork(new DbContextFactory(connectionString)))
                .As<IOrdersRepository>().InstancePerRequest();

            builder.RegisterType<ProductsRepository>()
                .WithParameter("IUnitOfWork", new UnitOfWork(new DbContextFactory(connectionString)))
                .As<IProductsRepository>().InstancePerRequest();

            builder.RegisterType<ShippersRepository>()
                .WithParameter("IUnitOfWork", new UnitOfWork(new DbContextFactory(connectionString)))
                .As<IShippersRepository>().InstancePerRequest();

            //註冊 Repository
            builder.RegisterGeneric(typeof(GenericRepository<>))
                .WithParameter("IDbContextFactory", new DbContextFactory(connectionString))
                .As(typeof(IRepository<>));

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();

            builder.RegisterFilterProvider();

            //建立容器
            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}