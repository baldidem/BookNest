using BookNest.BookOperations.CreateBook;
using BookNest.BookOperations.DeleteBook;
using BookNest.BookOperations.GetBooks;
using BookNest.BookOperations.UpdateBook;
using BookNest.Context;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using static BookNest.BookOperations.CreateBook.CreateBookCommand;
using static BookNest.BookOperations.GetBooks.GetByIdQuery;
using static BookNest.BookOperations.UpdateBook.UpdateBookCommand;


namespace BookNest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookController : ControllerBase
    {
        private readonly BookNestDbContext _context;

        public BookController(BookNestDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            BookModel result;
            GetByIdQuery query = new(_context);
            try
            {
                query.BookId = id;
                GetByIdQueryValidator validator = new();
                validator.ValidateAndThrow(query);
                result = query.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok(result);

        }

        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            try
            {
                CreateBookCommand command = new CreateBookCommand(_context);
                command.Model = newBook;
                CreateBookCommandValidator validator = new CreateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return Ok();

        }

        [HttpPut]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
        
            try
            {
                UpdateBookCommand command = new(_context);
                command.BookId = id;
                command.Model = updatedBook;

                UpdateBookCommandValidator validator = new UpdateBookCommandValidator();
                validator.ValidateAndThrow(command);
                command.Handle();

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {           
            try
            {
                DeleteBookCommand command = new(_context);
                command.BookId = id;
                DeleteBookCommandValidator validator = new();
                validator.ValidateAndThrow(command);
                command.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

    }
}

