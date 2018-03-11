using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld2.Models
{
    public class CaptchaRequest
    {
        public string secret { get; set; }
        public string response { get; set; }
        public string remoteip { get; set; }
    }
}