using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Entity
{
    public class User
    {
        public int id { get; set; }
        public string fullName { get; set; }
        public DateTime birthday { get; set; }
        public string avatar { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string linkFacebook { get; set; }
        public int userPoint { get; set; }
        public DateTime createDate { get; set; }
    }
}
