using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AssistWith.Models;
using Microsoft.EntityFrameworkCore;
using AssistWith.Services;

namespace AssistWith.Pages.Clients 
{ 
    public class IndexModel : PageModel
    { 
        [BindProperty]
        public List<AssistWith.Models.Client> Clients { get; set; }
        private readonly IService<AssistWith.Models.Client> _clientService;
        public IndexModel(IService<AssistWith.Models.Client> ClientService)
        {
            _clientService = ClientService;
        }
        public void OnGet()
        { 
            Clients = _clientService.GetAll().ToList();  
        } 
    }
}