using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.SolutionTypes
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<SolutionType> SolutionType { get;set; }

        public async Task OnGetAsync()
        {
            SolutionType = await _context.SolutionType.ToListAsync();

            IQueryable<SolutionType> solutionTypeIq = from s in _context.SolutionType
                                                  select s;
            solutionTypeIq = solutionTypeIq.Where(s => s.IsActive).AsNoTracking();
            SolutionType = await solutionTypeIq
                .OrderBy(i => i.LastModifiedDate)
                .ToListAsync();

        }
    }
}
