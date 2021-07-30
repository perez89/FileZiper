

namespace Application.Services.Interfaces
{
    using Application.Domain.DTOs;
    public interface IExclusionService
    {
        void RemoveExclusionsFromInput(UserInputDTO argumentsDTO);
    }
}
