namespace Application.Services
{
    using Application.Domain;
    using Application.Domain.Exclusions.Interfaces;
    using Application.Services.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    public class ExclusionController : IExclusionController
    {
        private readonly IEnumerable<IEventExclusionStrategy> _outputStrategies;

        public ExclusionController(IEnumerable<IEventExclusionStrategy> outputStrategies)
        {
            this._outputStrategies = outputStrategies;
        }

        public IList<string> Process(IEvent  exclusion, IList<string> loadedLines)
        {
            foreach (var messageStrategy in this._outputStrategies)
            {
                if (messageStrategy.CanHandle(exclusion))
                {
                    loadedLines = loadedLines.Where(filePath => !messageStrategy.Exclude(exclusion, filePath)).ToList();
                }
            }

            return loadedLines;
        }

        public IList<string> Process(IEnumerable<IEvent> exclusions, IList<string> filePaths)
        {
            foreach (var _exclusion in exclusions)
            {
                filePaths = this.Process(_exclusion, filePaths);
            }

            return filePaths;
        }
    }
}


