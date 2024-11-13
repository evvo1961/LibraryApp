using LibraryAppApi.Data;
using LibraryAppApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAppApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly AppDbContext appDbContext;

        public BookController(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        //Create a book
        [HttpPost]
        public async Task<ActionResult<List<Book>>> AddBook(Book book)
        {
            if (book != null) 
            { 
                appDbContext.Books.Add(book);
                await appDbContext.SaveChangesAsync();
                return Ok(await appDbContext.Books.ToListAsync());
            }
            return BadRequest("Object instance not set");
        }

        //Get all books
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var books = await appDbContext.Books.ToListAsync();
            return Ok(books);
        }

        //Get single book
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Book>> GetBook(int id)
        {
            var book = await appDbContext.Books.FirstOrDefaultAsync(x => x.Id == id);
            if (book != null) 
            {
                return Ok(book);
            }
            return BadRequest("Book is not available");
        }

        //Update a book
        [HttpPut]
        public async Task<ActionResult<Book>> UpdateBook(Book updatedBook)
        {
            if (updatedBook != null)
            {
                var book = await appDbContext.Books.FirstOrDefaultAsync(x => x.Id == updatedBook.Id);
                book!.Title = updatedBook.Title;
                book!.Author = updatedBook.Author;
                book.PublicationDate = updatedBook.PublicationDate;
                book.EditionNumber = updatedBook.EditionNumber;
                book!.ISBN = updatedBook.ISBN;
                await appDbContext.SaveChangesAsync();
                return Ok(book);
            }
            return BadRequest("Book not found");
        }

        //Delete a book
        [HttpDelete]
        public async Task<ActionResult<List<Book>>> DeleteBook(int id)
        {
            var book = await appDbContext.Books.SingleOrDefaultAsync(x => x.Id == id);
            if (book != null)
            {
                appDbContext.Books.Remove(book);
                await appDbContext.SaveChangesAsync();
                return Ok(await appDbContext.Books.ToListAsync());
            }
            return NotFound();
        }

    }
}
