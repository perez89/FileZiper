

namespace Application.Domain
{
    using Application.Domain.DTOs;
    using Application.Domain.Outputs;
    public interface IOutputBuilder
    {
        IOutputBuilder Build();

        IOutputBuilder CreateOutputBuilder(UserInputDTO argumentsDTO);

        IOutputBridgeBase Get();
    }
}
