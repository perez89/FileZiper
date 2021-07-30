namespace Application.Services
{
    using Application.Domain.DTOs;
    using Application.Domain.Enums;
    using Application.Domain.Exclusions;
    using Application.Domain.Outputs;
    using Application.Factory.Interfaces;
    using Application.Services.Interfaces;
    using Application.Utitlities;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class UserCommandToInputParser : IUserCommandToInputParser
    {
        UserCommandsDTO _argsDictionary;
        private IExclusionFactory _exclusionFactory { get; set; }    
        private IOutputFactory _outputFactory { get; set; }
        public UserCommandToInputParser(IExclusionFactory exclusionFactory, IOutputFactory outputFactory)
        {
            _exclusionFactory = exclusionFactory;
            _outputFactory = outputFactory;
        }

        public UserInputDTO Parse(UserCommandsDTO args)
        {
            _argsDictionary = args;


            var argumentsDTO = new UserInputDTO
            {
                Source = GetSourceName(),
                Name = GetZipName(),
                
                Exclusions = GetExclusions(),

                OutputDestination = GetOutputDestination()

            };

            return argumentsDTO;
        }

        private string GetZipName()
        {

            var source = _argsDictionary[CommandTypes.Name.ToString()].FirstOrDefault();
            return source?.Argument;
        }
        private string GetSourceName() {

            var source = _argsDictionary[CommandTypes.Source.ToString()].FirstOrDefault();
            return source?.Argument;
        }

        private IList<Exclusion> GetExclusions()
        {
            var extensionsTypes = new string[] { CommandTypes.EExtension.ToString(), CommandTypes.EFile.ToString(), CommandTypes.EFolder.ToString() };
            var exclusions = _argsDictionary[extensionsTypes];
            var result = GetExclusionType(exclusions);

            return result;
        }

        public IList<Exclusion> GetExclusionType(IEnumerable<UserCommand> exclusions)
        {
            var availableExclusions = ApplicationArguments.AvailableExtensions();

            var result = new List<Exclusion>();


            foreach (var availableExclusion in availableExclusions)
            {
                var _exclusions = exclusions.Where(x => x.Option.Equals(availableExclusion.Value));
                if (_exclusions.Any())
                {
                    var patternToRemove = _exclusions.Select(x => x.Argument).ToList();
                    result.Add(_exclusionFactory.CreateExclusion(availableExclusion.Value, patternToRemove));
                }
            }

            return result;
        }

        private OutputDestinationDTO GetOutputDestination()
        {

            var outputType = _argsDictionary[CommandTypes.Output.ToString()].FirstOrDefault();
            var destination = _argsDictionary[CommandTypes.Destination.ToString()].FirstOrDefault();

            return GetOutputDestination(outputType, destination);
        }

        private OutputDestinationDTO GetOutputDestination(UserCommand outputType, UserCommand destination)
        {
            var availableOutput = ApplicationArguments.AvailableOutputOperations().FirstOrDefault(x=> string.Equals(x.Value, outputType.Argument, StringComparison.OrdinalIgnoreCase) ).Value;

            return _outputFactory.CreateOutputDestination(availableOutput, destination.Argument);        
        }

    }
}