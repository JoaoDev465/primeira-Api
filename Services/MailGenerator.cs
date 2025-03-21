using System.Net;
using System.Net.Mail;
using Microsoft.AspNetCore.Http.HttpResults;
using MimeKit;
using MyJwtKey;

// configuração de envio de email,criado apenas com as bibliotecas .net

namespace MyMailServices;

public class MMailService
{
    public bool Send (
        string toMail,
        string toName,
        string Subject,
        string body,
        string fromMail = "joaodev465@gmail.com",
        string fromName = "João Marcelo"
    )
    {
        var smtpClient = new SmtpClient(Configuration.smtp.Host,Configuration.smtp.Port);

        smtpClient.Credentials = new NetworkCredential(Configuration.smtp.Password,Configuration.smtp.UserName);
        smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
        smtpClient.EnableSsl = true;

        var mail = new MailMessage();
        mail.From = new MailAddress(fromMail,fromName);
        mail.To.Add(new MailAddress(toMail,toName));
        mail.Subject = Subject;
        mail.Body = body;

        try
        {
          smtpClient.Send(mail);
          return true;
        }
        catch (Exception ex)
        {
            Console.Write(ex.Message);
            return false;
        }
    }
}