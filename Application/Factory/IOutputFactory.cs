

namespace Application.Factory
{
    using Application.Domain.Enums;
    using Application.Domain.Outputs;

    public interface IOutputFactory
    {
        IOutput GetOutputFromArgument(OutputType type, string destination, string fileName);
        IOutput GetOutputTypeToTestDestination(string outputType, string destination);
    }
}