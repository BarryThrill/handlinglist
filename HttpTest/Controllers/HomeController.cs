using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HttpTest.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public ContentResult Get()
        {
            StreamReader reader = new StreamReader("file.html");
            string file = reader.ReadToEnd();
            reader.Close();
            return Content(file, "text/html");
        }
    }
}
