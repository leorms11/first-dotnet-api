using Bookstore.Dtos;
using Bookstore.Entities;
using Bookstore.Repositories;
using Bookstore.UseCases;
using Microsoft.AspNetCore.Mvc;

namespace Bookstore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BooksController(BooksRepository booksRepository, CreateBookUseCase createBookUseCase,
    UpdateBookUseCase updateBookUseCase) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
    public IActionResult Create([FromBody] CreateBookRequest request) =>
        Created(string.Empty, createBookUseCase.Execute(request));

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<Book>), StatusCodes.Status200OK)]
    public IActionResult GetAll() => Ok(booksRepository.GetAll());

    [HttpPut("{bookId:guid}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
    public IActionResult Update([FromRoute] Guid bookId, [FromBody] UpdateBookRequest updateBookRequest) =>
        Ok(updateBookUseCase.Execute(bookId, updateBookRequest));

    [HttpDelete("{bookId:guid}")]
    [ProducesResponseType(typeof(Book), StatusCodes.Status204NoContent)]
    public IActionResult Delete([FromRoute] Guid bookId)
    {
        booksRepository.Delete(bookId);
        return NoContent();
    }

}