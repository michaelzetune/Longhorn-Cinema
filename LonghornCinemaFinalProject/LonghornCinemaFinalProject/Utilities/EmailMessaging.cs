using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Mail;
using System.Net;

namespace LonghornCinemaFinalProject.Utilities
{
    public class EmailMessaging
    {

        public static void SendEmail(String toEmailAddress, String emailSubject, String emailBody)
        {
            //Create an email client to send the emails     
            var client = new SmtpClient("smtp.gmail.com", 587) {Credentials = new NetworkCredential("LonghornCinema333@gmail.com", "team5FTW!"),EnableSsl = true};

            //Add anything that you need to the body of the message     
            // /n is a new line – this will add some white space after the main body of the message            
            
            //Create an email address object for the sender address     
            MailAddress senderEmail = new MailAddress("LonghornCinema333@gmail.com", "Team 5");
            MailMessage mm = new MailMessage();
            mm.Subject = "Team 5 - " + emailSubject;
            mm.Sender = senderEmail;
            mm.From = senderEmail;
            mm.To.Add(new MailAddress(toEmailAddress));
            mm.Body = emailBody;
            client.Send(mm);
        }

    }
}