using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Initiatives;
using Initiatives.Models;

namespace Initiatives.Pages.Notes
{
    public class IndexModel : PageModel
    {
        private readonly InitiativeContext _context;

        public IndexModel(InitiativeContext context)
        {
            _context = context;
        }

        public IList<Note> Note { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Note = await _context.Note.Include(n => n.Initiative).Where(a => a.InitiativeId == id).ToListAsync();
            //Note = await _context.
            // This is the filter type pattern.


        }
}

}