using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PandosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[]
                {"value1", "value2", "newvalue99"};
        }
    }
}
