using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages9Demo.Domain.Models;
using RazorPages9Demo.Infrastructure.Postgres;

namespace RazorPages9Demo.Web.Pages.Movies
{
    public class DetailsModel : PageModel
    {
        private readonly PostgresContext _context;

        public DetailsModel(PostgresContext context)
        {
            _context = context;
        }

        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Movies.FirstOrDefaultAsync(m => m.Id == id);

            if (movie is not null)
            {
                Movie = movie;

                return Page();
            }

            return NotFound();
        }
    }
}