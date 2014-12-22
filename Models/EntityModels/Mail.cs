namespace Models.EntityModels
{
    public class Mail: Base
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Body { get; set; }
        public string OrderLink { get; set; }
        public bool Deleted { get; set; }
    }
}