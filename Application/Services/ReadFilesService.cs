

namespace Application.Services
{
    using Application.Services.Interfaces;
    using System.IO;

    public class ReadFilesService : IReadFilesService
    {
        public string[] GetFiles(string source)
        {
            return Directory.GetFiles(source, "*", SearchOption.AllDirectories);
        }

    }
}
