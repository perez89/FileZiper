
namespace Application.Domain
{
    using Application.Domain.DTOs;

    public interface IInputUserBuilder
    {
        IInputUserBuilder Build();

        IInputUserBuilder CreateInputUserBuilder(string[] args);

        UserInputDTO Get();

        bool IsValid();
    }
}
