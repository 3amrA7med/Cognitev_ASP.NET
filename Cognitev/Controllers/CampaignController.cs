using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IO;
using Cognitev.Models;
using Newtonsoft.Json.Linq;
using System.Data;

namespace Cognitev.Controllers
{
    
    public class CampaignController : ApiController
    {

        DBHandler handler;

        public CampaignController()
        {
            // Initialize the database handler which will handle queries excution.
            handler = new DBHandler();
        }

        /*
         * Get the campaigns to report them
         */
        [Route("api/campaign/get_campaigns")]
        [HttpGet]
        public DataTable Get()
        {
            return handler.get_campaigns();
        }

        /*
         * This function calls exeternal api to get category if not given.
         */
        public string Get_category(string url)
        {
            string str_url = "https://ngkc0vhbrl.execute-api.eu-west-1.amazonaws.com/api/?url=https://";
            str_url = str_url + string.Format(url) + "/";
            // prepare the request. And set parameters.
            WebRequest requestObjGet = WebRequest.Create(str_url);
            // determine method used
            requestObjGet.Method = "GET";
            HttpWebResponse responseObj = (HttpWebResponse)requestObjGet.GetResponse();
            string str_result;
            // get response as a stream.
            using (Stream stream = responseObj.GetResponseStream())
            {
                StreamReader sr = new StreamReader(stream);
                str_result = sr.ReadToEnd();
                sr.Close();
            }
            //parse to json and extract the category.
            dynamic json = JObject.Parse(str_result);
            string category = json.category.name;
            System.Diagnostics.Debug.WriteLine(category);
            return category;
        }
        /*
         *Add campaign to the database. 
         */
        [Route("api/campaign/add_campaign")]
        [HttpPost]
        public void add_campaign([FromBody]Campaign c)
        {

            if (c.category==null || c.category == "")
            {
                c.category = Get_category(c.name);
            }
            handler.add_campaign(c);
        }
    }
}
