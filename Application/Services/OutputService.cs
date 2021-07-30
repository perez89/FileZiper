namespace Application.Services
{
    using Application.Domain;
    using Application.Domain.DTOs;
    using Application.Services.Interfaces;

    public class OutputService : IOutputService
    {
         private readonly IOutputBuilder _outputBuilder;
        public OutputService(IOutputBuilder outputBuilder)
        {
            _outputBuilder = outputBuilder;
        }
        public string ProcessOutput(UserInputDTO argumentsDTO)
        {
            var output = _outputBuilder.CreateOutputBuilder(argumentsDTO).Build().Get();

            return output.ExecuteOutput();
        }
    }
}
