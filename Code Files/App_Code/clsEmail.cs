using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Web;



/// <summary>
/// Summary description for clsEmail
/// </summary>
public class clsEmail
{
    public void MailPaper(string toEmail, string body)
    {


        SmtpClient clint = new SmtpClient("smtp.gmail.com", 587);
        clint.EnableSsl = true;
        clint.Timeout = 10000;
        clint.DeliveryMethod = SmtpDeliveryMethod.Network;
        clint.UseDefaultCredentials = false;
        clint.Credentials = new NetworkCredential("www.smaksud41@gmail.com", "918306995748");
        MailMessage msg = new MailMessage();
        msg.To.Add(toEmail);
        //msg.CC.Add("email.com,2nd");
        msg.From = new MailAddress("www.smaksud41@gmail.com");
        msg.Subject = "Online Examination System";
        msg.Body = body;
        clint.Send(msg);
    }
    public void sendEMail(string toEmail, string body)
    {
        string fromEmail = "2019@gmail.com"; string frompwd = "2019";
        try
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress(fromEmail,"Project Title !!!");
            mail.To.Add(toEmail);
            mail.Subject = "Your Password !!!";
            mail.Body = body;
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(fromEmail, frompwd);
            SmtpServer.EnableSsl = true;
            SmtpServer.Send(mail);
        }
        catch
        {
          
        }
    }
}

