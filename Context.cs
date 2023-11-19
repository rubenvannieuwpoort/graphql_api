
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Thing> Things { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }
}
