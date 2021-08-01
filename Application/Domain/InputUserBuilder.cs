

namespace Application.Domain
{
    using Application.Domain.DTOs;
    using Application.Services.Interfaces;
    using System.Collections.Generic;

    public class InputUserBuilder : IInputUserBuilder
    {

        private List<KeyValuePair<string, string>> _commandsList { get; set; }
        private bool _IsValid { get; set; }
        private UserInputDTO userInputDTO;
   
        private readonly IArgumentsValidation _validateArgs;
        private readonly IUserCommandToInputParser _parser;


        public InputUserBuilder( IArgumentsValidation validateArgs, IUserCommandToInputParser parser)
        {
       
            this._validateArgs = validateArgs;
            this._parser = parser;
        }
        public IInputUserBuilder Build()
        {
            var userCommandsDTO = new UserCommandsDTO(_commandsList);

            _IsValid = _validateArgs.IsValidate(userCommandsDTO);

            if (_IsValid)
            {
                userInputDTO = _parser.Parse(userCommandsDTO);
            }

          
            return this;

        }

        public IInputUserBuilder CreateInputUserBuilder(List<KeyValuePair<string, string>> commandsList)
        {
            _commandsList = commandsList;

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
