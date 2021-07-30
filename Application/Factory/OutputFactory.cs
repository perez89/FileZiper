

namespace Application.Factory
{
    using Application.Domain.Enums;
    using Application.Domain.Outputs;
    using System;

    public class OutputFactory : IOutputFactory
    {
        public IOutput GetOutputFromArgument(OutputType outputType, string destination, string fileName)
        {
            switch (outputType)
            {
                case OutputType.LocalFile:
                    return new LocalOutput(destination,  fileName);
                case OutputType.SMTP:
                    return new SmtpOutput(destination,  fileName);
                case OutputType.Remote:
                    return new RemoteOutput(destination, fileName);
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

                case OutputType.Remote: return new RemoteOutput(destination);

                default: throw new ArgumentOutOfRangeException(nameof(outputType), outputType, null);

            }
        }
    }
}
