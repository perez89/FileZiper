namespace Application.Domain.Outputs
{
    using System.IO;
    using System.Text.RegularExpressions;

    public class SmtpOutput : IOutput
    {
        public string Destination { get; set; }
        public string FileName { get; set; }

     
        public SmtpOutput(string destination)
        {
            Destination = destination;
        }

        public SmtpOutput(string destination, string fileName)
        {
            Destination = destination;
            FileName = fileName;
        }

        public string Execute(byte[] ZippedStream)
        {

            //MailMessage mail = new MailMessage();
            //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            //mail.From = new MailAddress("lplperezubi@gmail.com");
            //mail.To.Add(Destination);
            //mail.Subject = "Test Mail - 1";
            //mail.Body = "mail with attachment";

            //Attachment attachment;
            //attachment = new Attachment(ZippedStream, "name.zip", "application/zip");
            //mail.Attachments.Add(attachment);

            //SmtpServer.Port = 587;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("your mail@gmail.com", "your password");
            //SmtpServer.EnableSsl = true;

            //SmtpServer.Send(mail);
            //File.WriteAllBytes(Destination, ZippedStream.ToArray());

            //Console.WriteLine("Email Criado");

            return "Zipped and sent by Email";

        }

        public bool IsDestinationValid(string destination)
        {
            return destination.Contains("@");

        }

        public bool IsDestinationValid()
        {
            return Destination.Contains("@");

        }
    }
}
