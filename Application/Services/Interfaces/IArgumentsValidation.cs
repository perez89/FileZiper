
namespace Application.Services.Interfaces
{
    using Application.Domain.DTOs;

    public interface IArgumentsValidation
    {
        bool IsValidate(UserCommandsDTO args);
    }
    
}