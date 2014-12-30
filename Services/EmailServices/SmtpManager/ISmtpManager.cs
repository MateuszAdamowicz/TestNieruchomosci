using Models.ApplicationModels;

namespace Services.EmailServices.SmtpManager
{
    public interface ISmtpManager
    {
        void SendEmail(EmailMessage msg);
    }
}