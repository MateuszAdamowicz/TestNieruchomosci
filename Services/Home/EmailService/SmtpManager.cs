using System.Configuration;
using System.Net.Mail;
using Models.ApplicationModels;
using Services.Admin;

namespace Services.Home.EmailService
{
    public class SmtpManager : ISmtpManager
    {
        private readonly IAppSettingsService _appSettingsService;
        private readonly string _domainName;


        public SmtpManager(IAppSettingsService appSettingsService)
        {
            _appSettingsService = appSettingsService;
            _domainName = _appSettingsService.GetKey("emailDomain");
        }

        public void SendEmail(EmailMessage msg)
        {
            var client = new SmtpClient();

            var mail = new MailMessage(_domainName, msg.Destination)
            {
                Subject = msg.Topic,
                Body = msg.Body,
                IsBodyHtml = true
            };

            client.Send(mail);
        }
    }
}