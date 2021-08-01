

namespace Application.Domain.Exclusions
{
    using Application.Domain.Exclusions.Interfaces;
    internal class ExtensionExclusionStrategy : IEventExclusionStrategy
    {
        public bool CanHandle(IEvent  output)
        {
            return  output?.GetType() == typeof(ExtensionExclusion);
        }

        public bool Exclude(IEvent output, string filePath)
        {
            var outputA = (ExtensionExclusion) output;
            return  outputA.Exclude(filePath);
        }
    }
}
