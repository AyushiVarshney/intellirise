using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace Explore_App.COMMON
{
    public class PasswordHelper
    {
        //public static string SendEmail(UserPassword info)
        //{
        //    try
        //    {
        //        MailMessage mailMessage = new MailMessage()
        //        {
        //            Subject = "Account Password",
        //            Body = "This is  your account password--  " + info.Password,
        //            IsBodyHtml = false
        //        };
        //        mailMessage.To.Add(new MailAddress(info.Emailid));
        //        SmtpClient smtpClient = new SmtpClient();
        //        smtpClient.Host = "smtpout.secureserver.net";
        //        smtpClient.Port = 80;
        //        smtpClient.Send(mailMessage); 
        //        return "true";

        //    }
        //    catch (Exception ex)
        //    {
        //        return ex.ToString();
        //    }
        //}
    }
}