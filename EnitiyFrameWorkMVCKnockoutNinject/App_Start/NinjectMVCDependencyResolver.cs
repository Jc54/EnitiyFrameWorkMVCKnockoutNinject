using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace EnitiyFrameWorkMVCKnockoutNinject.App_Start
{
    public class NinjectMVCDependencyResolver : NinjectDependencyScope, System.Web.Mvc.IDependencyResolver
    {
        private IKernel kernel;

        public NinjectMVCDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(kernel.BeginBlock());
        }
    }
}