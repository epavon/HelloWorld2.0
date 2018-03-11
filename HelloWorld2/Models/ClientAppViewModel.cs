using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloWorld2.Models
{
    public class ClientAppViewModel
    {
        public string AppName { get; set; }
        public Dictionary<string,string> ClientFiles { get; set; }
    }
}