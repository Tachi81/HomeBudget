using HomeBudget.Business_Logic;
using HomeBudget.DAL.Interfaces;
using HomeBudget.DAL.Repositories;
using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(HomeBudget.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(HomeBudget.App_Start.NinjectWebCommon), "Stop")]

namespace HomeBudget.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();
        /// <summary>
        /// Starts the application
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }
        
        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }
        
        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                kernel.Bind<IBankAccountRepository>().To<BankAccountRepository>();

                kernel.Bind<IExpensesRepository>().To<ExpensesRepository>();
                kernel.Bind<IEarningsRepository>().To<EarningsRepository>();
                kernel.Bind<ITransferRepository>().To<TransferRepository>();

                kernel.Bind<IExpenseCategoriesRepository>().To<ExpenseCategoriesRepository>();
                kernel.Bind<IEarningCategoriesRepository>().To<EarningCategoriesRepository>();

                kernel.Bind<IExpenseSubCategoriesRepository>().To<ExpenseSubCategoriesRepository>();
                kernel.Bind<IEarningSubCategoriesRepository>().To<EarningSubCategoriesRepository>();

                kernel.Bind<IBankAccountLogic>().To<BankAccountLogic>();





                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
        }        
    }
}
