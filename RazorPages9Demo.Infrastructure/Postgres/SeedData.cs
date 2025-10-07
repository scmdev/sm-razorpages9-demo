using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using RazorPages9Demo.Domain.Models;

namespace RazorPages9Demo.Infrastructure.Postgres;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using var context = new PostgresContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<PostgresContext>>());

        if (context.Movies == null)
        {
            throw new ArgumentNullException(nameof(context.Movies), "Entity set 'PostgresContext.Movies' is null.");
        }

        // Look for any movies.
        if (context.Movies.Any())
        {
            return; // DB has been seeded
        }

        context.Movies.AddRange(
            new Movie
            {
                Title = "When Harry Met Sally",
                ReleaseDate = DateOnly.Parse("1989-2-12"),
                Genre = "Romantic Comedy",
                Price = 7.99M
            },
            new Movie
            {
                Title = "Ghostbusters ",
                ReleaseDate = DateOnly.Parse("1984-3-13"),
                Genre = "Comedy",
                Price = 8.99M
            },
            new Movie
            {
                Title = "Ghostbusters 2",
                ReleaseDate = DateOnly.Parse("1986-2-23"),
                Genre = "Comedy",
                Price = 9.99M
            },
            new Movie
            {
                Title = "Rio Bravo",
                ReleaseDate = DateOnly.Parse("1959-4-15"),
                Genre = "Western",
                Price = 3.99M
            }
        );
        context.SaveChanges();
    }
}