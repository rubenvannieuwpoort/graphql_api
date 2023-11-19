public class Mutation
{
    public async Task<ThingPayload> NewThing(ThingInput input, [Service]Context context)
    {
        Thing thing = new Thing() { Name = input.Naam };
        context.Things.Add(thing);
        context.SaveChanges();
        return new ThingPayload(thing);
    }
}

public record ThingInput(string Naam);

public record ThingPayload(Thing? record, string? error = null);

public class MutationType : ObjectType<Mutation>
{
    protected override void Configure(
        IObjectTypeDescriptor<Mutation> descriptor)
    {
        descriptor.Field(f => f.NewThing(default!, default!));
    }
}
