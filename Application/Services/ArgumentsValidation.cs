

namespace Application.Services
{
    using Application.Domain.DTOs;
    using Application.Domain.Enums;
    using Application.Factory.Interfaces;
    using Application.Services.Interfaces;
    using Application.Utitlities;
    using System.Linq;
    public class ArgumentsValidation : IArgumentsValidation
    {
        readonly IOutputFactory _outputFactory;
        public ArgumentsValidation(IOutputFactory outputFactory)
        {
            _outputFactory = outputFactory;
        }

        public bool IsValidate(UserCommandsDTO args)
        {
            var availableExclusions = ApplicationArguments.AvailableCommands();
            var availableOutputs = ApplicationArguments.AvailableOutputOperations();

            //check if there are argments
            if (args == null || !args.GetFlags().Any())
                return false;

            //mandatory Field      
            if (args[CommandTypes.Source.ToString()] == null)
            {
                return false;
            }

            //mandatory Field     

            if (args[CommandTypes.Output.ToString()] == null)
            {
                return false;
            }

            //validate if all exclusions flags inserted exist
            foreach (var arg in args.GetFlags())
            {
                if (!availableExclusions.Any(x => string.Equals(x.Value, arg, System.StringComparison.InvariantCultureIgnoreCase)))
                {
                    return false;
                }
            }

            var outputType = args.GetValues(CommandTypes.Output.ToString());

            if (outputType.Count() != 1)
                return false;

            var destination = args.GetValues(CommandTypes.Destination.ToString());

            if (destination.Count() != 1)
                return false;


            //validate if the output the output selected exists
            if (!availableOutputs.Any(x => string.Equals(x.Value, outputType.First(), System.StringComparison.InvariantCultureIgnoreCase)))
            {
                return false;
            }

            if (!ValidateOutputDestination(outputType.First(), destination.First()))
            {
                return false;
            }

            return true;
        }

        private bool ValidateOutputDestination(string output, string destination)
        {
            return _outputFactory.GetOutputTypeToTestDestination(output, destination).IsDestinationValid();
        }

    }
}
