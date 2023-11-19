public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}

public class AuthorType : ObjectType<Author>
{
    protected override void Configure(IObjectTypeDescriptor<Author> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Id)
            .Name("Id")
            .Type<NonNullType<StringType>>();

        descriptor.Field(f => f.Name)
            .Name("Name")
            .Type<NonNullType<StringType>>();

        descriptor.Field(f => f.Books)
            .Name("Books")
            .Type<NonNullType<ListType<BookType>>>();

    }
}
