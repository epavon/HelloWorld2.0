using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld2.Models
{
    public class CaptchaResponse
    {
        public bool success { get; set; }
        public string[] error_codes { get; set; }

    }
}