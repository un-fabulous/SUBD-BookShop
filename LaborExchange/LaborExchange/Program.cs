using LaborExchangeBusinessLogic.BusinessLogics;
using LaborExchangeBusinessLogic.Interfaces;
using LaborExchangeBusinessLogic.ViewModels;
using LaborExchangeDatabaseImplement.Implements;
using System;
using System.Windows.Forms;
using Unity;
using Unity.Lifetime;

namespace LaborExchange
{
    static class Program
    {
        public static UsersViewModel User { get; set; }
        
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var container = BuildUnityContainer();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(container.Resolve<FormMain>());
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();
            currentContainer.RegisterType<IBooksStorage, BooksStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IUsersStorage, UsersStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IAuthorsStorage, AuthorsStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IStatusStorage, StatusStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IOrdersStorage, OrdersStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IPublishinghouseStorage, PublishinghouseStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<PublishinghouseLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<UsersLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<AuthorsLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<StatusLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<BooksLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<OrdersLogic>(new HierarchicalLifetimeManager());
            return currentContainer;
        }
    }
}
