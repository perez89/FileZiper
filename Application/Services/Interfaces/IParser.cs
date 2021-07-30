namespace Application.Services.Interfaces
{
    using Application.Domain.DTOs;

    public interface IParser
    { 
        UserInputDTO Parse(UserCommandsDTO args);
    }
}