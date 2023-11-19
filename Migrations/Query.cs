public class Query
{
    public List<Thing> GetThings([Service]Context context)
    {
        return context.Things.ToList();
    }
}
public class QueryType : ObjectType<Query>
{
    protected override void Configure(IObjectTypeDescriptor<Query> descriptor)
    {
        descriptor
            .Field(f => f.GetThings(default!))
            .Type<ListType<ThingType>>();
    }
}
