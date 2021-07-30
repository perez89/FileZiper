

namespace Application.Services.Interfaces
{
    using Application.Domain.DTOs;

    public interface IOutputService
    {
        string ProcessOutput(UserInputDTO argumentsDTO);
    }
}