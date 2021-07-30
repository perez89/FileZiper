namespace Application.Domain.Exclusions.Interfaces
{
    using System.Collections.Generic;
    using System.IO;

    public abstract class ExclusionBase : IEvent
    {
        protected IList<string> Exclusions { get; set; }

        public ExclusionBase(IList<string> exclusions)
        {
            Exclusions = exclusions;
        }

        public abstract bool Exclude(string filePath);


        protected string GetExtension(string filePath)
        {
            return Path.GetExtension(filePath);
        }

        protected string GetFileName(string filePath)
        {
            return Path.GetFileName(filePath);
        }

        protected string GetFileNameWithoutExtension(string filePath)
        {
            return Path.GetFileNameWithoutExtension(filePath);
        }

        protected bool FolderNameExist(string filePath, string folderName)
        {
            return filePath.ToLower().Contains(string.Format("\\{0}\\", folderName.ToLower()));
        }
    }
}
