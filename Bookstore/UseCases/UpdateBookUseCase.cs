using Bookstore.Dtos;
using Bookstore.Entities;
using Bookstore.Repositories;

namespace Bookstore.UseCases;

public class UpdateBookUseCase(BooksRepository booksRepository)
{
    public Book Execute(Guid bookId, UpdateBookRequest request)
    {
        var book = booksRepository.GetById(bookId);

        if (book is null)
            throw new Exception("Livro não encontrado!");

        book.Title = request.Title;
        book.Author = request.Author;
        book.Genre = request.Genre;
        book.Amount = request.Amount;
        book.Price = request.Price;

        return booksRepository.Update(book);
    }
}