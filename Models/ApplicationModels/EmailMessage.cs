namespace Models.ApplicationModels
{
    public class EmailMessage
    {
        public string Destination { get; set; }
        public string Body { get; set; }
        public string Topic { get; set; }
    }
}