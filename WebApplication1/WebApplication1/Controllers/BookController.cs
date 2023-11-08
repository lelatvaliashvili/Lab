using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Net;
using LibraryBookService.ActionFilters;
using LibraryBookService.Models;
using LibraryBookService.Repositories.Interface;

namespace LibraryBookService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BookController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet("GetAllBooks")]
        public async Task<IActionResult> GetBooksAsync()
        { 
            try
            {
                var books = await _bookRepository.GetAllBooksAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("GetBookById/{id}")]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            try
            {
                var books = await _bookRepository.GetBookFromLibraryById(id);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }  
        }

        [HttpPost("AddBookToLibrary")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> AddBookToLibraryAsync([FromBody]Book newBook)
        {
            try
            {
                await _bookRepository.AddBookToLibraryAsync(newBook);
                return Ok($"The new book {newBook.Name} was added to the list");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpPut("UpdateBookDetails")]
        public async Task<IActionResult> UpdateBookAsync(int id, string name)
        {
            try
            { 
                var books = await _bookRepository.UpdateBookFromLibraryAsync(id, name);
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("RemoveBookFromLibrary/{id}")]
        public async Task<IActionResult> RemoveBookFromLibraryAsync(int id)
        {
            try
            {
                var books = await _bookRepository.RemoveBookFromLibraryAsync(id);
                return Ok($"book with id: {id} was removed");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
