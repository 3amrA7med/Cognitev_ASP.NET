using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Cognitev.Models;
namespace Cognitev
{
    public class DBHandler
    {
        DBManager dbMan;

        public DBHandler()
        {
            dbMan = new DBManager();
        }

        public void add_campaign(Campaign c)
        {
            string query = "INSERT INTO campaign(name,country,budget,category,goal) "
                + "VALUES ('" + c.name + " ','" + c.country + "',' " + c.budget + "',' " + c.category + "',' " + c.goal + "');";
            dbMan.ExecuteNonQuery(query);
        }

        public DataTable get_campaigns()
        {
            string query = "select * from campaign";
            return dbMan.ExecuteReader(query);
        }
    }
}