using System;
using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;

namespace realEstateWebApp.Services
{
	public class EmailSender
	{
		public EmailSender()
		{
		}


        internal static bool SendEmail(string body, string toemail, string toname, out string errormessage)
        {
            bool success = false;
            errormessage = string.Empty;

            try
            {

                var config = new ConfigurationBuilder()
                    .AddJsonFile($"appsettings.json", true, true)
                    .AddUserSecrets<Program>().Build();

                var from = config["EmailSender:from"];

                MailMessage message = new MailMessage(from, toemail);

                message.Subject = "Auto Response Email";
                message.Body = body;
                message.BodyEncoding = System.Text.Encoding.UTF8;
                message.IsBodyHtml = true;

                SmtpClient client = new SmtpClient(config["EmailSender:smtpserver"], Convert.ToInt32(config["EmailSender:smtpport"]));

                System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(from, config["EmailSender:fromPassword"]);
                client.EnableSsl = true;

                client.Credentials = credentials;

                client.Send(message);
                success = true;

            }
            catch (Exception ex)
            {
                success = false;
                errormessage = ex.Message;
            }

            return success;
        }
    }
}

