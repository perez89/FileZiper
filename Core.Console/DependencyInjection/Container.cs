

namespace Core.Console.DependencyInjection
{
    using Application.DependencyInjection;
    using Interface.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    public static class Container
    {
        public static ServiceProvider Build()
        {
            var collection = new ServiceCollection();
            collection.SetupApplication();
            collection.SetupInterface();
            collection.SetupCoreConsole();
            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }

        private static IServiceCollection SetupCoreConsole(this IServiceCollection services)
        {
            return services;
           
        }
    }
}
