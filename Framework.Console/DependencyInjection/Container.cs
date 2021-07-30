

namespace Framework.Console.DependencyInjection
{
    using Application.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    public static class Container
    {
        public static ServiceProvider Build()
        {
            var collection = new ServiceCollection();
            collection.SetupApplication();
            collection.SetupFrameworkConsole();
            var serviceProvider = collection.BuildServiceProvider();
            return serviceProvider;
        }

        private static IServiceCollection SetupFrameworkConsole(this IServiceCollection services)
        {
            return services;
             
        }
    }
}
