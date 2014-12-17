using Context;
using Models;
using Models.ApplicationModels;
using Models.EntityModels;

namespace Services.Home.EmailService
{
    public class EmailStorageService : IEmailStorageService
    {
        private readonly ApplicationContext _applicationContext;

        public EmailStorageService(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public Result SaveEmail(ContactEmail contactEmail)
        {
            var mail = AutoMapper.Mapper.Map<Mail>(contactEmail);
            _applicationContext.Mails.Add(mail);
            _applicationContext.SaveChanges();

            return new Result(true, null ,"");
        }
    }
}