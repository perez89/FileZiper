using Application.Domain.Exclusions.Interfaces;

namespace Application.Domain.Exclusions
{

    public class FileExclusionStrategy : IEventExclusionStrategy
    {
        public bool CanHandle(IEvent  output)
        {
            return  output?.GetType() == typeof(FileExclusion);
        }

        public bool Exclude(IEvent  output, string filePath)
        {
            var  outputA = (FileExclusion) output;
            return  outputA.Exclude(filePath);
        }
    }
}
