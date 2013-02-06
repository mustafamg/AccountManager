using System;
using System.Web.Mvc;
using Ninject;
using Ninject.Modules;
using System.Web.Routing;
using System.Web.Security;
using System.Web;
using AccountManagement.Models;


namespace AccountManagement.Infrastructure
{
    public class NinjectControllerFactory : DefaultControllerFactory
    {
        // A Ninject "kernel" is the thing that can supply object instances
        public IKernel Kernel = new StandardKernel(new MyAppModules());
        // ASP.NET MVC calls this to get the controller for each request
        protected override IController GetControllerInstance(RequestContext context, Type controllerType)
        {
            return controllerType!=null? (IController)Kernel.Get(controllerType):null;
        }
        // Configures how abstract service types are mapped to concrete implementations
        private class MyAppModules : NinjectModule
        {
            public override void Load()
            {
                //Todo: Bind your interfaces to their impelementors
                Bind<IRegisterRepository>().ToConstant<RegisterRepository>(regRep).InSingletonScope();
            }
            RegisterRepository _regRep;
            private RegisterRepository regRep
            {
                get
                {
                if (HttpContext.Current.Application["regRep"] == null)
                    System.Web.HttpContext.Current.Application["regRep"] = new RegisterRepository();

                return System.Web.HttpContext.Current.Application["regRep"] as RegisterRepository;
            } }
        }
    }
}
