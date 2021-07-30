namespace Application.Services
{
    using Application.Domain;
    using Application.Domain.Exclusions.Interfaces;
    using Application.Services.Interfaces;
    using System.Collections.Generic;
    using System.Linq;
    public class ExclusionHandler : IExclusionHandler
    {
        private readonly IEnumerable<IEventExclusionStrategy> _outputStrategies;

        public ExclusionHandler(IEnumerable<IEventExclusionStrategy> outputStrategies)
        {
            this._outputStrategies = outputStrategies;
        }

        public IList<string> Process(IEvent  exclusion, IList<string> filePaths)
        {
            foreach (var messageStrategy in this._outputStrategies)
            {
                if (messageStrategy.CanHandle(exclusion))
                {
                    filePaths = filePaths.Where(filePath => !messageStrategy.Exclude(exclusion, filePath)).ToList();
                }
            }

            return filePaths;
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


