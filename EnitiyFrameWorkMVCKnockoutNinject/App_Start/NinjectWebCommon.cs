﻿[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(EnitiyFrameWorkMVCKnockoutNinject.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(EnitiyFrameWorkMVCKnockoutNinject.App_Start.NinjectWebCommon), "Stop")]

namespace EnitiyFrameWorkMVCKnockoutNinject.App_Start
{
    using System;
    using System.Web;

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using System.Web.Http;

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
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
            RegisterServices(kernel);

            // Install our Ninject-based IDependencyResolver into the Web API config
            //GlobalConfiguration.Configuration.DependencyResolver
            //    = new NinjectDependencyResolver(kernel);
            // Install into the MVC dependency resolver
            System.Web.Mvc.DependencyResolver.SetResolver(
                new NinjectMVCDependencyResolver(kernel));
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Load("EnitiyFrameWorkMVCKnockoutNinject*.dll");
        }        
    }
}
