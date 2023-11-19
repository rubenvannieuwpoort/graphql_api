public class Thing
{
    public int Id { get; set; }
    public string Name { get; set; }
}

public class ThingType : ObjectType<Thing>
{
    protected override void Configure(IObjectTypeDescriptor<Thing> descriptor)
    {
        descriptor.BindFields(BindingBehavior.Explicit);
        descriptor.BindFieldsExplicitly();

        descriptor.Field(f => f.Name)
            .Name("Naam")
            .Type<NonNullType<StringType>>();
    }
}
