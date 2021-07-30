namespace Application.Domain.Outputs
{
    public class OutputParametersDTO
    {
        public string[] _folderAndSubFilesToZip { get; set; }
        public string _sourcePath { get; set; }
        public string _destination { get; set; }
    }
}
