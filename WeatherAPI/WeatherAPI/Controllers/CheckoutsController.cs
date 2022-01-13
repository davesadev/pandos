using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WeatherAPI.Models;
using WeatherAPI.View_Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckoutsController : ControllerBase
    {

        private readonly LibraryContext _context;
        public CheckoutsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<List<Checkout>> Get()
        {
            IQueryable<Checkout> checkouts = _context.Checkouts; //.Where(b => b.MultipleCopies > 2);
            Console.WriteLine(checkouts.ToQueryString());
            return await checkouts.ToListAsync();
        }

        // GET api/<CheckoutsController>/5
        [HttpGet("{id}")]
        public List<UserCheckoutVm> Get(int id)
        {
            var userCheckout = _context.Users.Where(u => u.UserId == id)
                .Select(u => new UserCheckoutVm
                {
                    UserId = u.UserId,
                    CheckedOutToId = u.UserId


                }).ToList();
            return userCheckout;
        }

        // POST api/<CheckoutsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<CheckoutsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CheckoutsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
