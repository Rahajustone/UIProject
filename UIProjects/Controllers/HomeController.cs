using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using UIProjects.Models;
using UIProjects.ViewModels;

namespace UIProjects.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(HttpRequestMessage request)
        {
            // Read them at first
            const string URLString = "https://www.theverge.com/rss/front-page/index.xml";


            //var test = ApiWebRequestHelper.GetXmlRequest<Testclass>(URLString);

            WebRequest apiRequest = WebRequest.Create(URLString);
            HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

            if (apiResponse.StatusCode == HttpStatusCode.OK)
            {
                string xmlOutput;
                using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                    xmlOutput = sr.ReadToEnd();



                //var jsResult = (Feed)JsonConvert.DeserializeObject<Feed>(xmlOutput);


                XmlSerializer xmlSerialize = new XmlSerializer(typeof(FeedViewModel));

                Console.WriteLine(xmlSerialize.ToString());
                var xmlResult = (FeedViewModel)xmlSerialize.Deserialize(new StringReader(xmlOutput));


                ViewData["data"] = JsonConvert.SerializeObject(xmlResult);
            }



            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }


    public class ApiWebRequestHelper
    {

        /// <summary>  
        /// Gets a request from an external XML formatted API and returns a deserialized object of data.  
        /// </summary>  
        /// <typeparam name="T"></typeparam>  
        /// <param name="requestUrl"></param>  
        /// <returns></returns>  
        public static T GetXmlRequest<T>(string requestUrl)
        {
            try
            {
                WebRequest apiRequest = WebRequest.Create(requestUrl);
                HttpWebResponse apiResponse = (HttpWebResponse)apiRequest.GetResponse();

                if (apiResponse.StatusCode == HttpStatusCode.OK)
                {
                    string xmlOutput;
                    using (StreamReader sr = new StreamReader(apiResponse.GetResponseStream()))
                        xmlOutput = sr.ReadToEnd();

                    XmlSerializer xmlSerialize = new XmlSerializer(typeof(T));

                    Console.WriteLine(xmlSerialize.ToString());
                    var xmlResult = (T)xmlSerialize.Deserialize(new StringReader(xmlOutput));

                    if (xmlResult != null)
                        return xmlResult;
                    else
                        return default(T);
                }
                else
                {
                    return default(T);
                }
            }
            catch (Exception ex)
            {
                // Log error here.
                throw new Exception(ex.Message);
                //return default(T);
            }
        }
    }
}
