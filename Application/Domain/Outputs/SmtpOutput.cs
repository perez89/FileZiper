namespace Application.Domain.Outputs
{
    using System.Text.RegularExpressions;

    public class RemoteOutput : IOutput
    {
        public string Destination { get; set; }
        public string FileName { get; set; }
        public RemoteOutput(string destination)
        {
            Destination = destination;
        }

        public RemoteOutput(string destination, string fileName)
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

            return "Zipped and sent Remote";

        }


        public bool ValidateDestination(string destination)
        {
            return Regex.IsMatch(destination, @"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$/");
        }
    }
}
