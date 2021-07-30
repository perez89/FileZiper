

namespace Application.Factory
{
    using Application.Domain.Enums;
    using Application.Domain.Outputs;
    using Application.Factory.Interfaces;
    using System;

    public class OutputFactory : IOutputFactory
    {
        public IOutput CreateOutputFromArguments(OutputType outputType, string destination, string fileName)
        {
            switch (outputType)
            {
                case OutputType.LocalFile:
                    return new LocalOutput(destination,  fileName);
                case OutputType.SMTP:
                    return new SmtpOutput(destination,  fileName);
                case OutputType.FileShare:
                    return new FileShareOutput(destination, fileName);
                default:
                    throw new ArgumentOutOfRangeException(nameof(outputType), outputType, null);
            }

        }

        public IOutput GetOutputTypeToTestDestination(string outputType, string destination)
        {
            switch ((OutputType)Enum.Parse(typeof(OutputType), outputType, true))
            {

                case OutputType.LocalFile: return new LocalOutput(destination);

                case OutputType.SMTP: return new SmtpOutput(destination);

                case OutputType.FileShare: return new FileShareOutput(destination);

                default: throw new ArgumentOutOfRangeException(nameof(outputType), outputType, null);

            }
        }

        public OutputDestinationDTO CreateOutputDestination(string type, string destination)
        {
            return new OutputDestinationDTO
            {
                Type = (OutputType)Enum.Parse(typeof(OutputType), type),
                Destination = destination
            };
        }
    }
}
