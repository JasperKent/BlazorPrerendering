using BlazorPrerendering.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorPrerendering.Api.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
}
