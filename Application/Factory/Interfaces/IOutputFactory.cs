

namespace Application.Factory.Interfaces
{
    using Application.Domain.Enums;
    using Application.Domain.Outputs;

    public interface IOutputFactory
    {
        IOutput CreateOutputFromArguments(OutputType type, string destination, string fileName);
        IOutput GetOutputTypeToTestDestination(string outputType, string destination);

        OutputDestinationDTO CreateOutputDestination(string outputType, string destination);
    }
}