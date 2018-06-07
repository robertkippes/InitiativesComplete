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

        //id is the Engagements ID
        public async Task OnGetAsync(int id)
        {
            Note = await _context.Note.Include(n => n.InitiativeNavigation)
                .Where(a => a.InitiativeId == id)
                .Where(a => a.IsActive == true)
                .ToListAsync();
           

        }
}

}