using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cust_DVDRent.Models
{
    public class LoginModels
    {
        public string email { get; set; }
        public string password { get; set; }
        public int role { get; set; }
        public string status { get; set; }
        public string search { get; set; }
    }

    public class SignupModels
    {
        public string email { get; set; }
        public string password { get; set; }
        public string status { get; set; }
        public string erormsg { get; set; }
        public string confirmpassword { get; set; }
        public string firstname { get; set; }
        public string lastname { get; set; }
        public string search { get; set; }
    }
}
