using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Services;

namespace JsonNetWebAppDemo
{
    /// <summary>
    /// Summary description for AjaxServer
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AjaxServer : System.Web.Services.WebService
    {
        [WebMethod(EnableSession = true)]
        public string DoSomething(string param1, string param2)
        {
            if (param1 == "" && param2 == "")
                return "[]";

            var list = new List<string>();
            list.Add("some string value");

            if (Session["someSessionValue"] != null)
                list.Add(Session["someSessionValue"].ToString());

            //slower built in 'JavaScriptSerializer'
            var json = new JavaScriptSerializer().Serialize(list);
            return json;

            //faster 'JsonConvert'
            //var json2 = JsonConvert.SerializeObject(list);
            //return json2;
        }
    }
}