using Application.Domain.Exclusions.Interfaces;

namespace Application.Domain.Exclusions
{
    internal class ExtensionExclusionStrategy : IEventExclusionStrategy
    {
        public bool CanHandle(IEvent  output)
        {
            return  output?.GetType() == typeof(ExtensionExclusion);
        }

        public bool Exclude(IEvent output, string filePath)
        {
            //  Guard.Argument( event, nameof( event)).Cast<LocalOutput>();

            var outputA = (ExtensionExclusion) output;
            return  outputA.Exclude(filePath);
        }
    }
}
