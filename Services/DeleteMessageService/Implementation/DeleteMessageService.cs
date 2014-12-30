using Context;

namespace Services.DeleteMessageService.Implementation
{
    public class DeleteMessageService : IDeleteMessageService
    {
        private readonly IApplicationContext _applicationContext;

        public DeleteMessageService(IApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void DeleteMesssage(int id)
        {
            var mail = _applicationContext.Mails.Find(id);
            if (mail != null)
            {
                mail.Deleted = true;
            }
            _applicationContext.SaveChanges();
        } 
    }
}