using Microsoft.EntityFrameworkCore;
using RazorPages9Demo.Domain.Models;

namespace RazorPages9Demo.Infrastructure.Postgres;

public class PostgresContext : DbContext
{
    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }
    
    public DbSet<Movie> Movies { get; set; } = null!; 
}