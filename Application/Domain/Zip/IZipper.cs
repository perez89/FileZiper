

namespace Application.Domain
{
    public interface IZipper
    {
        IZipper Configure(string[] folderAndSubFilesToZip, string sourcePath);
        byte[] Zipsaas();
    }
}