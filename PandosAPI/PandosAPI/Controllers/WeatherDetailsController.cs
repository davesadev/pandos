using Microsoft.AspNetCore.Mvc;
using PandosAPI.Identity;
using PandosAPI.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PandosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDetailsController : ControllerBase
    {
        // need to scaffold or migrate more models, but for now will use masterContext.cs
        private readonly ApplicationDbContext _context;

        /*
        public WeatherDetailsController (ApplicationDbContext _context)
        {
            _context = context;
        }
        */

        ////////////////////


        // GET: api/<WeatherDetailsController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<WeatherDetailsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<WeatherDetailsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<WeatherDetailsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<WeatherDetailsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
