using System;
using System.Configuration;
using System.IO;
using System.Net.Mime;
using System.Reflection;
using Models;
using Models.ApplicationModels;
using Models.ViewModels;
using RazorEngine.Templating;

namespace Services.Home.EmailService
{
    public class EmailSenderService : IEmailSenderService
    {
        private readonly ITemplateService _templateSercvie;
        private readonly ISmtpManager _smtpManager;
        private readonly string _domainName;

        public EmailSenderService(ITemplateService templateSercvie, ISmtpManager smtpManager)
        {
            _templateSercvie = templateSercvie;
            _smtpManager = smtpManager;
            _domainName = ConfigurationManager.AppSettings["emailDomain"];
        }

        public Result SendOfferQuestion(ContactEmail contactEmail)
        {
            var body = _templateSercvie.Parse(GetOfferTemplate(), contactEmail, null, null);

            var emailMsg = new EmailMessage()
            {
                Body = body,
                Destination = _domainName,
                Topic = "Pytanie od użytkownika dotyczące oferty"
            };

            _smtpManager.SendEmail(emailMsg);

            return new Result(true, null ,"");
        }

        public Result SendContactQuestion(ContactEmail contactEmail)
        {
            var body = _templateSercvie.Parse(GetContactTemplate(), contactEmail, null, null);

            var emailMsg = new EmailMessage()
            {
                Body = body,
                Destination = _domainName,
                Topic = "Pytanie od użytkownika"
            };

            _smtpManager.SendEmail(emailMsg);

            return new Result(true, null, "");
        }

        public Result SendOfferResponse(OfferStatus offerStatus, string destination)
        {
            string template;

            if (offerStatus == OfferStatus.Accepted)
            {
                template = GetOfferAcceptedTemplate();
            }
            else
            {
                template = GetOfferRejectedTemplate();
            }

            var body = _templateSercvie.Parse(template, null, null, null);

            var emailMsg = new EmailMessage()
            {
                Body = body,
                Destination = destination,
                Topic = "Odpowiedź dotycząca oferty"
            };

            _smtpManager.SendEmail(emailMsg);

            return new Result(true, null, "");
        }


        public string GetOfferRejectedTemplate()
        {
            string template =
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Templates/OfferRejectedEmailTemplate.cshtml"));
            return template;
        }

        public string GetOfferAcceptedTemplate()
        {
            string template =
                File.ReadAllText(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Templates/OfferAcceptedEmailTemplate.cshtml"));

            return template;
        }

        public string GetOfferTemplate()
        {
            string template = File.ReadAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Templates/QuestionEmailTemplate.cshtml"));

            return template;
        }

        public string GetContactTemplate()
        {
            var x = Directory.GetCurrentDirectory();

            string template = File.ReadAllText(
                Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "Templates/ContactEmailTemplate.cshtml"));
            
            return template;
        }
    }
}