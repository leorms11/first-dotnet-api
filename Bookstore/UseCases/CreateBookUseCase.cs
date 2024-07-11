using Bookstore.Dtos;
using Bookstore.Entities;
using Bookstore.Repositories;

namespace Bookstore.UseCases;

public class CreateBookUseCase(BooksRepository booksRepository)
{
    public Book Execute(BaseBookRequest request) => booksRepository.Create(Book.Create(request));
}