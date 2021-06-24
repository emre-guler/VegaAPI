using System;
using Vega.Enums;

namespace Vega.Entities
{
    public class User : BaseEntity 
    {
        public string Fullname { get; set; }
        public string PhoneNumber { get; set; }
        public string MailAddress { get; set; }
        public string Password { get; set; }
        public string ProfilePhoto { get; set; }
        public int Money { get; set; }
        public Role Role { get; set; }
        public DateTime BirthDate { get; set; }
        public bool MailVerify { get; set; }
    }
}