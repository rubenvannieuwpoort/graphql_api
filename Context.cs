
using Microsoft.EntityFrameworkCore;

class Context : DbContext
{
    public DbSet<Thing> Things { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }
}
