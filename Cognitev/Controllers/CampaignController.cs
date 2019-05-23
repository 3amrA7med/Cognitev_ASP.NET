using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
// using System.Net;
using System.IO;
using Cognitev.Models;
using Newtonsoft.Json.Linq;

namespace Cognitev.Controllers
{
    
    public class CampaignController : ApiController
    {
        List<Campaign> campaigns = new List<Campaign>();

        // GET api/campaign
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("api/campaign/get_campaign/{name}")]
        [HttpGet]
        public string Get(string name)
        {
            return "value";
        }
        public string Get_category(string url)
        {
            string str_url = "https://ngkc0vhbrl.execute-api.eu-west-1.amazonaws.com/api/?url=https://";
            str_url = str_url + string.Format(url) + "/";
            WebRequest requestObjGet = WebRequest.Create(str_url);
            requestObjGet.Method = "GET";
            HttpWebResponse responseObj = (HttpWebResponse)requestObjGet.GetResponse();
            string str_result;
            using (Stream stream = responseObj.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                str_result = sr.ReadToEnd();
                sr.Close();
            }
            dynamic json = JObject.Parse(str_result);
            string category = json.category.name;
            System.Diagnostics.Debug.WriteLine(category);
            return category;
        }

        [Route("api/campaign/add_campaign")]
        [HttpPost]
        // POST api/campaign
        public void add_campaign([FromBody]Campaign c)
        {

            if (c.category==null && c.category == "")
            {
                c.category = Get_category(c.name);
            }
            campaigns.Add(c);
        }

        /*
            Report function that gives the array of data upon request
        */
        [Route("api/campaign/report/{url}")]
        [HttpGet]
        public string Report(string url)
        {
            return "77";
        }
    }
}
