namespace Application.Domain.Exclusions
{
    using Application.Domain.Exclusions.Interfaces;
    using System.Collections.Generic;
    using System.Linq;

    public class FolderExclusion : ExclusionBase
    {
        public FolderExclusion(IList<string> exclusions) : base(exclusions)
        {

        }

        public override bool Exclude(string filePath)
        {
            return Exclusions.Any(folderNameExclusion => FolderNameExist(filePath, folderNameExclusion));
        }
    }
}
