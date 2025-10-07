using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorPages9Demo.Domain.Models;
using RazorPages9Demo.Infrastructure.Postgres;

namespace RazorPages9Demo.Web.Pages.Movies
{
    public class IndexModel : PageModel
    {
        private readonly RazorPages9Demo.Infrastructure.Postgres.PostgresContext _context;

        public IndexModel(RazorPages9Demo.Infrastructure.Postgres.PostgresContext context)
        {
            _context = context;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Movie = await _context.Movies.ToListAsync();
        }
    }
}
