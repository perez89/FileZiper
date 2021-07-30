

namespace Application.Domain.Outputs
{
    public interface IOutput
    {
        string Destination { get; set; }
        string FileName { get; set; }
        string Execute(byte[] ZippedStream);
        bool ValidateDestination(string destination);


    }
}
