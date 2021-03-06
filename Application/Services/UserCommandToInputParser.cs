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

            var source = _argsDictionary.Get(CommandTypes.Name.ToString()).FirstOrDefault();
            return source.Value;
        }
        private string GetSourceName() {

            var source = _argsDictionary.Get(CommandTypes.Source.ToString()).FirstOrDefault();
            return source.Value;
        }

        private IList<Exclusion> GetExclusions()
        {
            var extensionsTypes = new string[] { CommandTypes.EExtension.ToString(), CommandTypes.EFile.ToString(), CommandTypes.EFolder.ToString() };
            var exclusions = _argsDictionary.Get(extensionsTypes);
            var result = GetExclusionType(exclusions);

            return result;
        }

        public IList<Exclusion> GetExclusionType(IEnumerable<KeyValuePair<string, string>> exclusions)
        {
            var availableExclusions = ApplicationArguments.AvailableExtensions();

            var result = new List<Exclusion>();


            foreach (var availableExclusion in availableExclusions)
            {
                var _exclusions = exclusions.Where(x => x.Key.Equals(availableExclusion.Value));
                if (_exclusions.Any())
                {
                    var patternToRemove = _exclusions.Select(x => x.Value).ToList();
                    result.Add(_exclusionFactory.CreateExclusion(availableExclusion.Value, patternToRemove));
                }
            }

            return result;
        }

        private OutputDestinationDTO GetOutputDestination()
        {

            var outputType = _argsDictionary.Get(CommandTypes.Output.ToString()).FirstOrDefault();
            var destination = _argsDictionary.Get(CommandTypes.Destination.ToString()).FirstOrDefault();

            return GetOutputDestination(outputType, destination);
        }

        private OutputDestinationDTO GetOutputDestination(KeyValuePair<string, string> outputType, KeyValuePair<string, string> destination)
        {
            var availableOutput = ApplicationArguments.AvailableOutputOperations().FirstOrDefault(x=> string.Equals(x.Value, outputType.Value, StringComparison.OrdinalIgnoreCase) ).Value;

            return _outputFactory.CreateOutputDestination(availableOutput, destination.Value);        
        }

    }
}