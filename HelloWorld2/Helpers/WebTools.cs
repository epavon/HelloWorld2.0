using HelloWorld2.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;

namespace HelloWorld2.Helpers
{
    public class WebTools
    {
        public async Task<T> ServiceCall<T>(string serviceLocation)
        {
            T result = default(T);
            
            HttpWebRequest req  = (HttpWebRequest)WebRequest.Create(serviceLocation);
            try
            {
                using (WebResponse wResponse = await req.GetResponseAsync())
                {
                    using (StreamReader readStream = new StreamReader(wResponse.GetResponseStream()))
                    {
                        string jsonResponse = readStream.ReadToEnd();
                        var jsSerializer    = new JavaScriptSerializer();
                        result              = jsSerializer.Deserialize<T>(jsonResponse);  
                    }
                }
            }
            catch (WebException ex)
            {
                throw ex;
            }

            return result;
        }
    }
}