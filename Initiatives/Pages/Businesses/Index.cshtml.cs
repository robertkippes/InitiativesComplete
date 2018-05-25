using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives.Models;

namespace Initiatives.Pages.Businesses
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<Business> Business { get;set; }

        public async Task OnGetAsync()
        {
            

            IQueryable<Business> businessIq = from s in _context.Businesses
                                                  select s;
            businessIq= businessIq.Where(s => s.IsActive);
            Business = await businessIq
                .OrderBy(i => i.LastModifiedDate)
                .ToListAsync();

            


            
        }
    }
}
