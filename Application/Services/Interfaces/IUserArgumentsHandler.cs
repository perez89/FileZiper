
namespace Application.Services.Interfaces
{
    using Application.Domain.DTOs;

    public interface IUserArgumentsHandler
    {
        UserCommandsDTO Extract(string[] Args);
    }
}