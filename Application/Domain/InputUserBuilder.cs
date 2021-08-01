

namespace Application.Domain
{
    using Application.Domain.DTOs;
    using Application.Services.Interfaces;

    public class InputUserBuilder : IInputUserBuilder
    {

        private string[] _args { get; set; }
        private bool _IsValid { get; set; }
        private UserInputDTO userInputDTO;
        private readonly IUserArgumentsHandler _userCommands;
        private readonly IArgumentsValidation _validateArgs;
        private readonly IUserCommandToInputParser _parser;


        public InputUserBuilder(IUserArgumentsHandler userCommands, IArgumentsValidation validateArgs, IUserCommandToInputParser parser)
        {
            this._userCommands = userCommands;
            this._validateArgs = validateArgs;
            this._parser = parser;
        }
        public IInputUserBuilder Build()
        {
            var userCommandsDTO = _userCommands.Extract(_args);

            _IsValid = _validateArgs.IsValidate(userCommandsDTO);

            if (_IsValid)
            {
                userInputDTO = _parser.Parse(userCommandsDTO);
            }

          
            return this;

        }

        public IInputUserBuilder CreateInputUserBuilder(string[] args)
        {
            _args = args;

            return this;
        }

        public UserInputDTO Get()
        {
            return userInputDTO;
        }



        public bool IsValid()
        {
            return _IsValid;
        }


    }
}
