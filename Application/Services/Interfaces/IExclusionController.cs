
namespace Application.Services.Interfaces
{
    using Application.Domain;
    using System.Collections.Generic;

    public interface IExclusionController
    {
         IList<string> Process(IEvent @exclusion, IList<string> filePaths);

         IList<string> Process(IEnumerable<IEvent> exclusions, IList<string> filePaths);
    }
}