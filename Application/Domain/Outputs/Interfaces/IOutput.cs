

namespace Application.Domain.Outputs
{
    public interface IOutput
    {
        string Destination { get; set; }
        string FileName { get; set; }
        string Execute(byte[] ZippedStream);
        bool IsDestinationValid(string destination);
        bool IsDestinationValid();

    }
}
