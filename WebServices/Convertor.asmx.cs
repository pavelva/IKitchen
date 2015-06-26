using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServices
{
    /// <summary>
    /// Summary description for Convertor
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Convertor : System.Web.Services.WebService
    {

        [WebMethod]
        public double convert(string from, string to, double amount)
        {
            if (from == "shekel" && to != from)
            {
                return amount / 3.85;
            }
            else if (from == "dollar" && to != from)
            {
                return amount * 3.85;
            }
            else
                return amount;
        }
    }
}
