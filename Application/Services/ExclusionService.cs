
namespace Application.Services
{
    using Application.Domain.DTOs;
    using Application.Factory.Interfaces;
    using Application.Services.Interfaces;
    using System;
    using System.Linq;

    public class ExclusionService : IExclusionService
    {
        IExclusionController _ExclusionController; 
        IExclusionFactory _exclusionFactory; 
        IReadFilesService _readFilesService;
        public ExclusionService(IExclusionController ExclusionController, IExclusionFactory exclusionFactory, IReadFilesService readFilesService)
        {
            _ExclusionController = ExclusionController;
            _exclusionFactory = exclusionFactory;
            _readFilesService = readFilesService;
        }
        public void RemoveExclusionsFromInput(UserInputDTO inputUserCommands)
        {
            var exclusions = inputUserCommands.Exclusions.ToList().ConvertAll(x => _exclusionFactory.CreateExclusion(x.Type, x.Values));


            var folderAndSubFiles = _readFilesService.GetFiles(inputUserCommands.Source);

            Console.WriteLine(" ");
            Console.WriteLine("Loaded paths");

            foreach (var path in folderAndSubFiles)
            {

                Console.WriteLine(path);

            }

            Console.WriteLine(" ");

            Console.WriteLine("Exclusions to apply:");
            foreach (var exclusion in inputUserCommands.Exclusions)
            {

                Console.WriteLine("Type= " + exclusion.Type + " | Values: " + String.Join(", ", exclusion.Values));

            }



            var folderAndSubFilesFiltered = _ExclusionController.Process(exclusions, folderAndSubFiles);

            var folderAndSubFilesToZip = folderAndSubFilesFiltered.Select(x => x).ToArray();

            Console.WriteLine(" ");

            Console.WriteLine("Paths to Zip : ");
            foreach (var path in folderAndSubFilesToZip)
            {

                Console.WriteLine(path);

            }

            inputUserCommands.folderAndSubFilesToZip = folderAndSubFilesToZip;
        }
    }
}
