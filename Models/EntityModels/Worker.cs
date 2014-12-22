using System;

namespace Models.EntityModels
{
    public class Worker: Base
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneFirst { get; set; }
        public string PhoneSecond { get; set; }
        public string Email { get; set; }
        public bool HasPhoto { get; set; }
        public string Photo { get; set; }
        public bool Deleted { get; set; }

        public string FullName
        {
            get { return String.Format("{0} {1}", FirstName, LastName); }
        }
    }
}