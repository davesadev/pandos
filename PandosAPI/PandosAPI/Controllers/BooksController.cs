using Microsoft.AspNetCore.Mvc;
using PandosAPI.Models;
using Microsoft.EntityFrameworkCore;
using PandosAPI.View_Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PandosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        private readonly LibraryContext _context;
        public BooksController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/<BooksController>
        [HttpGet]
        public async Task<List<Book>> Get()
        {
            IQueryable<Book> books = _context.Books.Where(b => b.MultipleCopies > 2);
            Console.WriteLine(books.ToQueryString());
            return await books.ToListAsync();
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public List<BookCheckoutVm> Get(int id)
        {
            var bookCheckout = _context.Books.Where(b => b.BookId == id)
                .Select(b => new BookCheckoutVm
                {
                    BookId = b.BookId,
                    Title = b.Title,
                    AuthorId = b.AuthorId,
                    Checkouts = _context.Checkouts.Where(c => c.BookId == b.BookId).Select(c => new CheckoutVm()
                    {
                        CheckoutId = c.CheckoutId,
                        CheckoutDate = c.CheckoutDate,
                        DueByDate = c.DueByDate
                        //CheckedOut = true
                    }).ToList()
                });
            Console.WriteLine(bookCheckout.ToQueryString);
            return (List<BookCheckoutVm>)bookCheckout;
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
