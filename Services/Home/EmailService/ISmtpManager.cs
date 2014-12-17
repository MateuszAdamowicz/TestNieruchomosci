using Models.ApplicationModels;

namespace Services.Home.EmailService
{
    public interface ISmtpManager
    {
        void SendEmail(EmailMessage msg);
    }
}