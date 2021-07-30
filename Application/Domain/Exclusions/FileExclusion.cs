namespace Application.Domain.Exclusions
{
    using Application.Domain.Exclusions.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class FileExclusion : ExclusionBase
    {
        public FileExclusion(IList<string> exclusions) : base(exclusions)
        {
            
        }

        public override bool Exclude(string filePath)
        {
           return Exclusions.Any(fileExclusion => string.Equals(GetFileNameWithoutExtension(filePath), fileExclusion, System.StringComparison.OrdinalIgnoreCase));                 
        }
    }
}
