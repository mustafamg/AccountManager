using System;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;
using System.Web.Routing;
using System.Web.Security;
using System.Web;
using AccountManagement.Domain.Repositories;
using AccountManagement.Domain.Model;

namespace AccountManagement.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        // A Ninject "kernel" is the thing that can supply object instances
        public IKernel Kernel = new StandardKernel(new MyAppModules());
        // ASP.NET MVC calls this to get the controller for each request
        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            return controllerType != null ? (IController)Kernel.Get(controllerType) : null;
        }
        // Configures how abstract service types are mapped to concrete implementations
        private class MyAppModules : NinjectModule
        {
            public override void Load()
            {
                //Todo: Need more work and test
                var db = new AccountDbContext();
                var ac = new AccountsRepository(db);
                //Todo: Bind your interfaces to their impelementors
                Bind<IAccountsRepository>().ToConstant<AccountsRepository>(ac).InSingletonScope();
            }
        //    AccountsRepository _gb;
        //    private AccountsRepository gb
        //    {
        //        get
        //        {
        //            if (HttpContext.Current.Application["gb"] == null)
        //                System.Web.HttpContext.Current.Application["gb"] = new AccountsRepository();

        //            return System.Web.HttpContext.Current.Application["gb"] as AccountsRepository;
        //        }
        //    }
        }
    }
}