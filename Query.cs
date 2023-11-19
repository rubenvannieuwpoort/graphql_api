public class Query
{
    public Thing GetThing()
    {
        return new Thing
        {
            Name = "Hello"
        };
    }

    public List<Thing> GetThings()
    {
        return new List<Thing>
        {
            new Thing { Name = "Thing1" },
            new Thing { Name = "Thing2" }
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

        descriptor
            .Field(f => f.GetThings())
            .Type<ListType<ThingType>>();
    }
}
