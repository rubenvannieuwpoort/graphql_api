public class Mutation
{
    public async Task<ThingPayload> AddThing(ThingInput input)
    {
        Thing thing = new Thing() { Name = input.Naam };
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
        descriptor.Field(f => f.AddThing(default!));
    }
}
