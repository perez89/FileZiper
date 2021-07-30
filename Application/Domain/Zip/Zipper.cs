

namespace Application.Domain
{
    using System.IO;
    using System.IO.Compression;
    public class Zipper : IZipper
    {
        private string[] _folderAndSubFilesToZip { get; set; }
        private string _sourcePath { get; set; }


        public IZipper Configure(string[] folderAndSubFilesToZip, string sourcePath)
        {
            _folderAndSubFilesToZip = folderAndSubFilesToZip;
            _sourcePath = sourcePath;
            return this;
        }

        public byte[] Zipsaas()
        {
            var entryNames = GetEntryNames(_folderAndSubFilesToZip, _sourcePath, true);
      

            using (MemoryStream zipToCreate = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zipToCreate, ZipArchiveMode.Create, true))
                {
                    for (int i = 0; i < _folderAndSubFilesToZip.Length; i++)
                    {
                        archive.CreateEntryFromFile(_folderAndSubFilesToZip[i], entryNames[i], CompressionLevel.Optimal);
                    }              
                }

                return zipToCreate.ToArray();
            }
        }


        private string[] GetEntryNames(string[] names, string sourceFolder, bool includeBaseName)
        {
            if (names == null || names.Length == 0)
                return new string[0];

            if (includeBaseName)
                sourceFolder = Path.GetDirectoryName(sourceFolder);

            int length = string.IsNullOrEmpty(sourceFolder) ? 0 : sourceFolder.Length;
            if (length > 0 && sourceFolder != null && sourceFolder[length - 1] != Path.DirectorySeparatorChar && sourceFolder[length - 1] != Path.AltDirectorySeparatorChar)
                length++;

            var result = new string[names.Length];
            for (int i = 0; i < names.Length; i++)
            {
                result[i] = names[i].Substring(length);
            }

            return result;
        }

    }
}
