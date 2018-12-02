using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Newtonsoft.Json;

namespace HowtoconvertJSONtodatatableinCsharp1268724
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.codeproject.com/Answers/1268827/How-to-convert-JSON-to-datatable-in-Csharp#answer1
            
            HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create("http://xml.flightview.com/fvDemoConsOOOI/fvxml.exe?a=fvxmldemoSoo1&b=thrk$xxxx&depap=xxx&depdate=xxxxxx&dephr=xxxx");
            httpWebRequest.Method = WebRequestMethods.Http.Get;
            httpWebRequest.Accept = "application/json; charset=utf-8";
            string file;
            var response = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                file = sr.ReadToEnd();
            }

            var xmldoc = new XmlDocument();
            xmldoc.LoadXml(file);
            var json = JsonConvert.SerializeXmlNode(xmldoc);
            var table = JsonConvert.DeserializeAnonymousType(json, new { Makes = default(DataTable) }).Makes;
            if (table.Rows.Count > 0)
            {
                //do something
            }
        }
    }
}
