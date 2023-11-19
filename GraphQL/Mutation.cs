public class Mutation
{
    public async Task<AuthorPayload> NewAuthor(AuthorInput input, [Service] Context context)
    {
        try
        {
            Author author = new Author() { Name = input.Name };
            context.Authors.Add(author);
            context.SaveChanges();
            return new AuthorPayload(author);
        }
        catch (Exception ex)
        {
            return new AuthorPayload(null, ex.Message);
        }
    }

    public async Task<BookPayload> NewBook(BookInput input, [Service] Context context)
    {
        try
        {
            var authors = input.Authors.Select(author => context.Find<Author>(author.Id)!).ToList();
            var tags = input.Tags.Select(tag => context.Find<Tag>(tag.Id)!).ToList();
            Book book = new Book()
            {
                Title = input.Title,
                Authors = authors,
                Tags = tags
            };
            context.Books.Add(book);
            context.SaveChanges();
            return new BookPayload(book);
        }
        catch (Exception ex)
        {
            return new BookPayload(null, ex.Message);
        }
    }

    public async Task<TagPayload> NewTag(TagInput input, [Service] Context context)
    {
        try
        {
            Tag tag = new Tag() { Name = input.Name, Description = input.Description };
            context.Tags.Add(tag);
            context.SaveChanges();
            return new TagPayload(tag);
        }
        catch (Exception ex)
        {
            return new TagPayload(null, ex.Message);
        }
    }
}


public class AuthorInputType : InputObjectType<AuthorInput> { }
public record AuthorInput(string Name);
public record AuthorPayload(Author? record, string? error = null);


public class BookInputType : InputObjectType<BookInput> { }
public record BookInput(string Title, List<AuthorByIdInput> Authors, List<TagByIdInput> Tags);
public record AuthorByIdInput(int Id);
public record TagByIdInput(int Id);
public record BookPayload(Book? record, string? error = null);


public class TagInputType : InputObjectType<TagInput> { }
public record TagInput(string Name, string Description);
public record TagPayload(Tag? record, string? error = null);


public class MutationType : ObjectType<Mutation>
{
    protected override void Configure(
        IObjectTypeDescriptor<Mutation> descriptor)
    {
        descriptor.Field(f => f.NewAuthor(default!, default!));
        descriptor.Field(f => f.NewTag(default!, default!));
        descriptor.Field(f => f.NewBook(default!, default!));
    }
}
