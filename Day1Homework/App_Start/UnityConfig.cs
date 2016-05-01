using System;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Day1Homework.Repositories;
using Day1Homework.Service.Interface;
using Day1Homework.Service.EF;
using Day1Homework.Service;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Day1Homework.Models;
using System.Data.Entity;
using Day1Homework.Controllers;

namespace Day1Homework.App_Start
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container = new Lazy<IUnityContainer>(() =>
        {
            var container = new UnityContainer();
            RegisterTypes(container);
            return container;
        });

        /// <summary>
        /// Gets the configured Unity container.
        /// </summary>
        public static IUnityContainer GetConfiguredContainer()
        {
            return container.Value;
        }
        #endregion

        /// <summary>Registers the type mappings with the Unity container.</summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>There is no need to register concrete types such as controllers or API controllers (unless you want to 
        /// change the defaults), as Unity allows resolving a concrete type even if it was not previously registered.</remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below. Make sure to add a Microsoft.Practices.Unity.Configuration to the using statements.
            //container.LoadConfiguration();

            //先做出EF
            //因為UnitOfWork要是Singleton instance 所以生命週期要改成PerRequestLifetimeManager
            container.RegisterType<IUnitOfWork, EFUnitOfWork>(new PerRequestLifetimeManager());
            container.RegisterType<IAccountBookService, AccountBookService>();
            container.RegisterType<ILogService, LogService>();

            //container
            //.RegisterType<IDataContextAsync, NorthwindContext>(new PerRequestLifetimeManager())
            //.RegisterType<IUnitOfWorkAsync, UnitOfWork>(new PerRequestLifetimeManager())
            //.RegisterType<IRepositoryAsync<Customer>, Repository<Customer>>();

            //container.RegisterType(typeof(UserManager<>),
            //new InjectionConstructor(typeof(IUserStore<>)));
            //container.RegisterType<Microsoft.AspNet.Identity.IUser>(new InjectionFactory(c => c.Resolve<Microsoft.AspNet.Identity.IUser>()));
            //container.RegisterType(typeof(IUserStore<>), typeof(UserStore<>));
            //container.RegisterType<IdentityUser, ApplicationUser>(new ContainerControlledLifetimeManager());
            //container.RegisterType<DbContext, ApplicationDbContext>(new ContainerControlledLifetimeManager());

            container.RegisterType<DbContext, ApplicationDbContext>(new HierarchicalLifetimeManager());
            container.RegisterType<UserManager<ApplicationUser>>(
                new HierarchicalLifetimeManager());
            container.RegisterType<IUserStore<ApplicationUser>, UserStore<ApplicationUser>>(
                new HierarchicalLifetimeManager());

            container.RegisterType<AccountController>(
                new InjectionConstructor());
        }
    }
}
