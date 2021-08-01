

namespace Application.Domain.Exclusions
{
    using Application.Domain.Exclusions.Interfaces;
    public class FolderExclusionStrategy : IEventExclusionStrategy
    {
        public bool CanHandle(IEvent exclusion)
        {
            return exclusion?.GetType() == typeof(FolderExclusion);
        }
        
        public bool Exclude(IEvent exclusion, string filePath)
        {
            var exclusionA = (FolderExclusion)exclusion;
            return exclusionA.Exclude(filePath);
        }
    }
}
