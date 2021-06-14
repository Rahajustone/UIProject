using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UIProjects.Helpers
{
    public class XMLFormaterChanger
    {
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
            catch(Exception ex)
            {
                // ILogger to store error for dev
                return default(T);
            }
        }
    }
}
