using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UIProjects.Helpers;
using UIProjects.ViewModels;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UIProjects.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedController : ControllerBase
    {
        // GET: api/<FeedController>
        [HttpGet]
        public IActionResult Get()
        {
            const string URLString = "https://www.theverge.com/rss/front-page/index.xml";

            var xmlResult = XMLFormaterChanger.GetXmlRequest<FeedViewModel>(URLString);
            var objToJson = JsonConvert.SerializeObject(xmlResult);

            return Ok(objToJson);
        }
    }
}
