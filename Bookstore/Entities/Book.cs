using Bookstore.Dtos;

namespace Bookstore.Entities;

public class Book
{
    public Book(string title, string author, string genre, double price, int amount)
    {
        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        Genre = genre;
        Price = price;
        Amount = amount;
    }

    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Genre { get; set; }
    public double Price { get; set; }
    public int Amount { get; set; }

    public static Book Create(BaseBookRequest baseBookRequest) => new(
        baseBookRequest.Title,
        baseBookRequest.Author,
        baseBookRequest.Genre,
        baseBookRequest.Price,
        baseBookRequest.Amount);
}