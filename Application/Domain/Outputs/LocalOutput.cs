
namespace Application.Domain.Outputs
{
    using System;
    using System.IO;

    public class LocalOutput : IOutput
    {
        public string Destination { get; set; }
        public string FileName { get; set; }


        public LocalOutput(string destination)
        {
            Destination = destination;
       
        }
        public LocalOutput(string destination, string fileName)
        {
            Destination = destination;
            FileName = fileName;
        }


        public string Execute(byte[] ZippedStream)
        {

            //  const string fileName = "Test#@@#.dat";

            var finalPath = string.Format("{0}\\{1}.zip", Destination, FileName);
            using (FileStream
                fileStream = new FileStream(finalPath, FileMode.Create))
            {
                // Write the data to the file, byte by byte.
                for (int i = 0; i < ZippedStream.Length; i++)
                {
                    fileStream.WriteByte(ZippedStream[i]);
                }

                // Set the stream position to the beginning of the file.
                fileStream.Seek(0, SeekOrigin.Begin);

                // Read and verify the data.
                for (int i = 0; i < fileStream.Length; i++)
                {
                    if (ZippedStream[i] != fileStream.ReadByte())
                    {
                        Console.WriteLine("Error writing data.");
                        return "";
                    }
                }
                Console.WriteLine("The data was written to {0} " +
                    "and verified.", fileStream.Name);
            }
   

            Console.WriteLine("Ficheiro Criado");

            return "Zipped and saved on a File";
        }

        public bool ValidateDestination(string destination)
        {
            return Directory.Exists(destination);
        }
    }
}
