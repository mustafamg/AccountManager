using System.Linq;
using System.Web.Mvc;
using AccountManagement.Infrastructure;

namespace AccountManagement.Specs.Infrastructure
{
    public static class NinjectControllerFactoryUtils
    {
        public static void TemporarilyReplaceBinding<TService>(TService implementation)
        {
            var controllerFactory = (NinjectControllerFactory)ControllerBuilder.Current.GetControllerFactory();
            var kernel = controllerFactory.Kernel;

            // Remove existing bindings and replace with new one
            var originalBindings = kernel.GetBindings(typeof (TService)).ToList();
            
            kernel.Rebind<TService>().ToConstant(implementation).InSingletonScope();
            TidyUp.AddTask(() =>
            {
                kernel.Unbind(typeof(TService));
                foreach (var originalBinding in originalBindings)
                    kernel.AddBinding(originalBinding);
            });
        }
    }
}