using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistWith.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace AssistWith.Pages.Clients
{ 
    public class EditModel : PageModel
    { 
        [BindProperty]
        public AssistWith.Models.Client Client { get; set; }

        private readonly IService<AssistWith.Models.Client> _clientService; 
        public EditModel(IService<AssistWith.Models.Client> ClientService)
        {
            _clientService = ClientService; 
        }
        public IActionResult OnGet(int? id)
        {
            Client = new AssistWith.Models.Client() { ClientID = 0 };
            if (id != null) 
                Client = _clientService.GetAll()
                        .Where(o => o.ClientID == id.GetValueOrDefault())
                        .SingleOrDefault();  
            return Page();
        }
        public IActionResult OnPost()
        { 
            if (!ModelState.IsValid) 
                return Page(); 
            if (Client.ClientID==0) 
                _clientService.Insert(Client);
            else
                _clientService.Update(Client); 
            return Page();
        }
    }
}