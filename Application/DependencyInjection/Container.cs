namespace Application.DependencyInjection
{
    using Application.Domain;
    using Application.Domain.Exclusions;
    using Application.Domain.Exclusions.Interfaces;
    using Application.Domain.Outputs;
    using Application.Factory;
    using Application.Factory.Interfaces;
    using Application.Services;
    using Application.Services.Interfaces;
    using Microsoft.Extensions.DependencyInjection;
    using System.Linq;
    using System.Reflection;
    using static Application.Services.UserCommandToInputParser;

    public static class Container
    {
        public static IServiceCollection SetupApplication(this IServiceCollection services)
        {


            return services
                //Implementations

                .AddSingleton<IOutput, LocalOutput>()
                .AddSingleton<IOutput, SmtpOutput>()
                .AddSingleton<IEvent, FileExclusion>()
                .AddSingleton<IEvent, ExtensionExclusion>()
                .AddSingleton<IEvent, FolderExclusion>()
                .AddSingleton<IOutputBuilder, OutputBuilder>()
                .AddSingleton<IExclusionController, ExclusionController>()

                //Strategies

                .AddSingleton<IEventExclusionStrategy, FolderExclusionStrategy>()
                .AddSingleton<IEventExclusionStrategy, ExtensionExclusionStrategy>()
                .AddSingleton<IEventExclusionStrategy, FileExclusionStrategy>()


                //df
                .AddSingleton<IUserArgumentsHandler, UserArgumentsHandler>()
                .AddSingleton<IUserCommandToInputParser, UserCommandToInputParser>()
                .AddSingleton<IArgumentsValidation, ArgumentsValidation>()


                .AddSingleton<IZipper, Zipper>()

                .AddSingleton<IInputUserBuilder, InputUserBuilder>()
                .AddSingleton<IExclusionService, ExclusionService>()
                .AddSingleton<IOutputService, OutputService>()
                .AddSingleton<IReadFilesService, ReadFilesService>()
                .AddSingleton<IExclusionFactory, ExclusionFactory>()
                .AddSingleton<IOutputFactory, OutputFactory>();


        }


        public static void RegisterAllTypes<T>(this IServiceCollection services, Assembly[] assemblies,
      ServiceLifetime lifetime = ServiceLifetime.Transient)
        {
            var typesFromAssemblies = assemblies.SelectMany(a => a.DefinedTypes.Where(x => x.GetInterfaces().Contains(typeof(T))));
            foreach (var type in typesFromAssemblies)
                services.Add(new ServiceDescriptor(typeof(T), type, lifetime));
        }
    }
}
