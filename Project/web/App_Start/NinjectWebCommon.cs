[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(web.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(web.App_Start.NinjectWebCommon), "Stop")]

namespace web.App_Start
{
    using System;
    using System.Collections.Generic;
    using System.Web;
    using MediatR;
    using MediatR.Ninject;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;
    using OnlineStore.Application;
    using OnlineStore.Application.Carts;
    using OnlineStore.Application.Carts.Command;
    using OnlineStore.Application.Carts.Queries;
    using OnlineStore.Application.Common.Behaviors;
    using OnlineStore.Application.Common.Interfaces;
    using OnlineStore.Application.Products;
    using OnlineStore.Application.Products.Queries;
    using OnlineStore.Application.Users;
    using OnlineStore.Application.Users.Command;
    using OnlineStore.Infrastructure.Performance;
    using OnlineStore.Web.Services;
    using Project.Persistence;

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
            kernel.BindMediatR();

            kernel.Bind<IDbContext>().To<AppDbContext>();

            kernel.Bind<IRequestHandler<RegisterUserCommand, int>>().To<RegisterUserCommand.RegisterUserCommandHandler>();
            kernel.Bind<IRequestHandler<LoginUserCommand, long>>().To<LoginUserCommand.LoginUserCommandHandler>();
            kernel.Bind<IRequestHandler<GetProductsListQuery, List<ProductDTO>>>().To<GetProductsListQuery.GetProductsListQueryHandler>();
            kernel.Bind<IRequestHandler<GetUserCartQuery, CartDTO>>().To<GetUserCartQuery.GetUserCartQueryHandler>();
            kernel.Bind<IRequestHandler<UpdateUserCartCommand, int>>().To<UpdateUserCartCommand.UpdateUserCartCommandHandler>();
            //kernel.Bind<IRequestHandler<UpdateUserCartCommand, int>>().To<UpdateUserCartCommand.UpdateUserCartCommandHandler>();
            kernel.Bind(typeof(IPipelineBehavior<,>)).To(typeof(PerformanceBehavior<,>));
            kernel.Bind(typeof(IUserService)).To(typeof(UserService));
            kernel.Bind(typeof(IProductService)).To(typeof(ProductService));
            kernel.Bind(typeof(ICartService)).To(typeof(CartService));
           

            //kernel.BindApplication();

            kernel.Bind(typeof(IPerformanceLogger)).To(typeof(PerformanceLogger));

        }
    }
}
