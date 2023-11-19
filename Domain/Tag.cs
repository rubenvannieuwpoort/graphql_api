public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class TagType : ObjectType<Tag>
{
    protected override void Configure(IObjectTypeDescriptor<Tag> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Id)
            .Name("Id")
            .Type<NonNullType<StringType>>();

        descriptor.Field(f => f.Name)
            .Name("Name")
            .Type<NonNullType<StringType>>();

        descriptor.Field(f => f.Description)
            .Name("Description")
            .Type<NonNullType<StringType>>();
    }
}
