using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AssistWith.Data;
using AssistWith.Models; 
namespace AssistWith.Pages 
{
    public class ClientPageModel : PageModel
    {
        private readonly AssistWith.Data.ApplicationDbContext _context;

        public ClientPageModel(AssistWith.Data.ApplicationDbContext context)
        {
            _context = context;
        } 
        public AssistWith.Models.Client Client { get; set; }
        public AssistWith.Models.ClientViewModel ClientViewModel { get; set; }

        public void OnGet()
        {
            ClientViewModel = new ClientViewModel()
            {
                Client = new AssistWith.Models.Client() { ClientID = 0 } 
            };
        }
        

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null) 
                id = 0;  
            Client = await _context.Clients.FirstOrDefaultAsync(m => m.ClientID == id);

            if (Client == null) 
                Client = new AssistWith.Models.Client() { ClientID = 0 };
        
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(Client.ClientID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientID == id);
        }
    }
}
