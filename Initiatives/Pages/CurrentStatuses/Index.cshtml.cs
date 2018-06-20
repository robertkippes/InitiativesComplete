using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Initiatives.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace Initiatives.Pages.CurrentStatuses
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<CurrentStatus> CurrentStatus { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<CurrentStatus> currentStatusIq = from s in _context.CurrentStatus
                                              select s;
            currentStatusIq = currentStatusIq.Where(s => s.IsActive).AsNoTracking();
            CurrentStatus = await currentStatusIq
                .OrderBy(i => i.LastModifiedDate)
                .ToListAsync();
        }
    }
}