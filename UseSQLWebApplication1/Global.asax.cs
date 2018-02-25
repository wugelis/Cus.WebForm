using Autofac;
using Autofac.Integration.Web;
using Cus.Models.DbContextFactory;
using Cus.Models.Interface;
using Cus.Models.Repository;
using Cus.Services.Interface;
using Cus.Services.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Cus.WebForm
{
    public class Global : System.Web.HttpApplication, IContainerProviderAccessor
    {
        static IContainerProvider _containerProvider;
        protected void Application_Start(object sender, EventArgs e)
        {
            var builder = new ContainerBuilder();

            //builder.RegisterControllers(Assembly.GetExecutingAssembly());

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

            //builder.RegisterFilterProvider();

            //建立容器
            IContainer container = builder.Build();

            _containerProvider = new ContainerProvider(container);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        public IContainerProvider ContainerProvider
        {
            get { return _containerProvider; }
        }
    }
}