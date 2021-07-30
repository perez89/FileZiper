
namespace Application.Domain.DTOs
{
    using Application.Domain.Exclusions;
    using Application.Domain.Outputs;
    using System.Collections.Generic;
    using System.IO;

    public class UserInputDTO
    {
        public string Source { get; set; }
        public string Name { private get; set; }
        public IList<Exclusion> Exclusions { get; set; }
        public OutputDestinationDTO OutputDestination { get; set; }
        public string[] folderAndSubFilesToZip { get; set; }
        public string gGetFileName() {
            if (string.IsNullOrEmpty(Name)) {
                return Path.GetFileNameWithoutExtension(Source);
            }

            return Name;
        }

    }
}
