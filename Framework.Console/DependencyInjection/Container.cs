

namespace Framework.Console.DependencyInjection
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
            collection.SetupFrameworkConsole();         
            collection.SetupInterface();

            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }

        private static IServiceCollection SetupFrameworkConsole(this IServiceCollection services)
        {
            return services;
             
        }
    }
}
