public class Query
{
    public Thing GetThing()
    {
        return new Thing
        {
            Name = "Hello"
        };
    }
}
public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field(f => f.GetThing())
            .Type<ThingType>();
    }
}
