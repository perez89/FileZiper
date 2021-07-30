﻿namespace Core.Console
{
    using Application.Domain;
    using Application.Services.Interfaces;
    using Application.Utilities;
    using Core.Console.DependencyInjection;
    using Microsoft.Extensions.DependencyInjection;
    using System;

    public class Program
    {
        static void Main(string[] args)
        {
            ServiceProvider sp = Container.Build();

            var inputUserBuilder = sp.GetService<IInputUserBuilder>();
            var exclusionService = sp.GetService<IExclusionService>();
            var outputService = sp.GetService<IOutputService>();

            Console.WriteLine("Hello World! - .Net core");
            Console.ReadLine();


            //            var _outputBuilder = outputBuilder.CreateOutputBuilder(inputUserCommands).Build().Get(); ;

            var _inputUserBuilder = inputUserBuilder.CreateInputUserBuilder(args).Build();


            if (!_inputUserBuilder.IsValid())
            {

                Console.Error.WriteLine("\n{0} - Error: unrecognized or incomplete command line.", App.GetApplicationName());

                return;
            }

            var inputUserCommands = _inputUserBuilder.Get();


            exclusionService.RemoveExclusionsFromInput(inputUserCommands);


            var processed = outputService.ProcessOutput(inputUserCommands);


            Console.Out.WriteLine(">>>>>>> RESULT <<<<<<<<");
            Console.Out.WriteLine(processed);

            Console.Read();

        }
    }

}
