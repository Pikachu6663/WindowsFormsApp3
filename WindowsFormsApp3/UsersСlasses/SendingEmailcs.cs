using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp3.UsersСlasses;
using System.Net.Mail;
using System.Net;
using System.Linq.Expressions;
public class SendingEmail
{

    private InfoEmailSending InfoEmailSending { get; set; }

    public SendingEmail(InfoEmailSending infoEmailSending)
    {
        InfoEmailSending = infoEmailSending ?? throw new ArgumentNullException(nameof(infoEmailSending));

    }
    public void Send()
    {
        try
        {
            SmtpClient mySmtpClient = new SmtpClient(InfoEmailSending.SmtpClientAdress);
            mySmtpClient.UseDefaultCredentials = false;
            mySmtpClient.EnableSsl = true;
            NetworkCredential basicAuthenticalionInfo = new NetworkCredential
                ("elka6454@mail.ru", "mcyrEa6hacadiNunuLx5");
            mySmtpClient.Credentials = basicAuthenticalionInfo;
            MailAddress from = new MailAddress("example@example.com", "John Doe");
            MailAddress to = new MailAddress("elka6454@mail.ru", "Артем");
            MailMessage myMail = new MailMessage(from, to);
            MailAddress replyTo = new MailAddress("example@example.com");
            myMail.ReplyToList.Add(replyTo);
            Encoding encoding = Encoding.UTF8;
            myMail.Subject = InfoEmailSending.Subject;
            myMail.SubjectEncoding = encoding;
            myMail.Body = InfoEmailSending.Body;
            myMail.BodyEncoding = encoding;
            mySmtpClient.Send(myMail);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

