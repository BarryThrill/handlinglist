using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Web.Http;

namespace HttpTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        // POST api/values
        [HttpPost]
        public string Post([FromBody] DataModel body) {

            try
            {
                string data = Newtonsoft.Json.JsonConvert.SerializeObject(body); // Serialiserar det angivna objektet till en JSON - sträng med formatering
                StreamReader reader = new StreamReader("./db.json");
                string content = reader.ReadToEnd();
                reader.Close();
                System.IO.File.Delete("./db.json"); // Läs JSON och rensa filen
                StreamWriter writer = new StreamWriter("./db.json");
                content = content.Trim().Trim(']'); // Klippa ']' slutet av filen
                content += content[content.Length - 1] != '[' ? ", " + data : data; // Om det inte är det första objektet, sätt i ett kommatecken, annars lägger du bara in det som det första elementet
                content += ']'; // Lägg tilbaks ']'
                writer.Write(content);
                writer.Close(); // Rensa upp

                return "0";
            }
            catch (IOException e)
            {
                return "-1";
            }
        }
    }
}
