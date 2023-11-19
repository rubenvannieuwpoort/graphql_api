public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public virtual ICollection<Author> Authors { get; set; }
    public virtual ICollection<Tag> Tags { get; set; }
}

public class BookType : ObjectType<Book>
{
    protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Id)
            .Name("Id")
            .Type<NonNullType<StringType>>();

        descriptor.Field(f => f.Title)
            .Name("Title")
            .Type<NonNullType<StringType>>();

        descriptor.Field(f => f.Authors)
            .Name("Authors")
            .Type<NonNullType<ListType<AuthorType>>>();

        descriptor.Field(f => f.Tags)
            .Name("Tags")
            .Type<NonNullType<ListType<TagType>>>();
    }
}
