namespace Application.Services.Interfaces
{
    using Application.Domain.DTOs;

    public interface IUserCommandToInputParser
    { 
        UserInputDTO Parse(UserCommandsDTO args);
    }
}