using Bookstore.Entities;

namespace Bookstore.Repositories;

public class BooksRepository
{
    private List<Book> books = new();

    public Book Create(Book book)
    {
        books.Add(book);
        return book;
    }
    
    public IEnumerable<Book> GetAll() => books;

    public Book? GetById(Guid bookId) => books.Find(x => x.Id == bookId);

    public Book Update(Book book)
    {
        var bookIndex = books.FindIndex(x => x.Id == book.Id);
        books[bookIndex] = book;
        return book;
    }

    public void Delete(Guid bookId) => books = books.Where(x => x.Id != bookId).ToList();
}