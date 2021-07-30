namespace Application.Domain.Exclusions.Interfaces
{
    public interface IEventExclusionStrategy
    {
        bool CanHandle(IEvent @output);
        bool Exclude(IEvent @output, string filePath);
    }
}
