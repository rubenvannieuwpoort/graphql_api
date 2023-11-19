
using Microsoft.EntityFrameworkCore;

public class Context : DbContext
{
    public DbSet<Author> Authors { get; set; }
    public DbSet<Book> Books { get; set; }
    public DbSet<Tag> Tags { get; set; }

    public Context(DbContextOptions<Context> options) : base(options) { }
}
