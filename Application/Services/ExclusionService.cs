
namespace Application.Services
{
    using Application.Domain.DTOs;
    using Application.Factory;
    using Application.Services.Interfaces;
    using System.IO;
    using System.Linq;


    public class ExclusionService : IExclusionService
    {
        IExclusionHandler _exclusionHandler; 
        IExclusionFactory _exclusionFactory;
        public ExclusionService(IExclusionHandler exclusionHandler, IExclusionFactory exclusionFactory)
        {
            _exclusionHandler = exclusionHandler;
            _exclusionFactory = exclusionFactory;
        }
        public void RemoveExclusionsFromInput(UserInputDTO inputUserCommands)
        {
            var exclusions = inputUserCommands.Exclusions.ToList().ConvertAll(x => _exclusionFactory.CreateExclusion(x.ExclusionType, x.Exclusions));


            var folderAndSubFiles = Directory.GetFiles(inputUserCommands.Source, "*", SearchOption.AllDirectories);


            var folderAndSubFilesFiltered = _exclusionHandler.Process(exclusions, folderAndSubFiles);

            var folderAndSubFilesToZip = folderAndSubFilesFiltered.Select(x => x).ToArray();

            inputUserCommands.folderAndSubFilesToZip = folderAndSubFilesToZip;
        }
    }
}
