public class Mutation
{
    public async Task<BookPayload> AddBook(BookInput input)
    {
        var book = new Book { Title = input.title, Author = new Author { Name = input.author }  };
        return new BookPayload(book);
    }
}

public record BookPayload(Book? record, string? error = null);

public record BookInput(string title, string author);
