public class Query
{
    public IEnumerable<Author> GetAuthors([Service] Context context)
    {
        return context.Authors.ToList();
    }

    public IEnumerable<Book> GetBooks([Service] Context context)
    {
        return context.Books.ToList();
    }

    public IEnumerable<Tag> GetTags([Service] Context context)
    {
        return context.Tags.ToList();
    }
}
public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field(f => f.GetAuthors(default!))
            .Type<NonNullType<ListType<AuthorType>>>();

        descriptor
            .Field(f => f.GetBooks(default!))
            .Type<NonNullType<ListType<BookType>>>();

        descriptor
            .Field(f => f.GetTags(default!))
            .Type<NonNullType<ListType<TagType>>>();
    }
}
