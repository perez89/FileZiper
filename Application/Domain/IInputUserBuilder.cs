
namespace Application.Domain
{
    using Application.Domain.DTOs;
    using System.Collections.Generic;

    public interface IInputUserBuilder
    {
        IInputUserBuilder Build();

        IInputUserBuilder CreateInputUserBuilder(List<KeyValuePair<string, string>> commandsList);

        UserInputDTO Get();

        bool IsValid();
    }
}
