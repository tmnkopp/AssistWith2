using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AssistWith.Models;
using Microsoft.EntityFrameworkCore;

namespace AssistWith.Pages.ClientPage 
{
    
    public class IndexModel : PageModel
    {

        [BindProperty]
        public List<AssistWith.Models.Client> Clients { get; set; }
        [BindProperty]
        public AssistWith.Models.ClientViewModel ClientViewModel { get; set; }
        public void OnGet()
        {
            Clients = new List<AssistWith.Models.Client>();
            int cnt = 0;
            foreach (var item in new string[] { "c1", "c2","c3", "c4" })
            {
                Clients.Add(new AssistWith.Models.Client() { ClientID = cnt++, Company = item });
            } 
        }
        public async Task<IActionResult> OnPostAsync() { 
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var result = ClientViewModel.Client.Company;
            return RedirectToPage("./Index");
        }
    }
}