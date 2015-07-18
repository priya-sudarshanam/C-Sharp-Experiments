using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Mail;

/// <summary>
/// Summary description for Utilities
/// </summary>
public static class Utilities
{
	static Utilities()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public static void SendMail(string from, string to, string subject, string body)
    {
        SmtpClient mailClient = new SmtpClient(BalloonShopConfiguration.MailServer);
        mailClient.Credentials = new NetworkCredential(BalloonShopConfiguration.MailUsername, BalloonShopConfiguration.MailPassword);
        MailMessage mailMessage = new MailMessage(from, to, subject, body);
        mailClient.Send(mailMessage);
   
    }

    //send error log email
    public static void LogError(Exception e)
    {
        string errorMessage = "Exception generated on \n";
        HttpContext context = HttpContext.Current;
        errorMessage += "\nPage location: " + context.Request.RawUrl;
        errorMessage += "\n\n Message: " + e.Message;
        errorMessage += "\n\n Source: " + e.Source;
        errorMessage += "\n\n Method: " + e.TargetSite;
        errorMessage += "\n\n Stack Trace: \n\n " + e.StackTrace;

        if (BalloonShopConfiguration.EnableErrorLogEmail)
        {
            string from = BalloonShopConfiguration.MailFrom;
            string to = BalloonShopConfiguration.ErrorLogEmail;
            string subject = "BalloonShop Error Report";
            string body = errorMessage;
            SendMail(from, to, subject, body);
        }
    }

}