using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AssistWith.Models; 
namespace AssistWith.Pages.ClientPage 
{
    public class IndexModel : PageModel
    {

        public AssistWith.Models.Client Client { get; set; }
        public void OnGet()
        {
            Client = new AssistWith.Models.Client() { ClientID = 0 };
        
        }
    }
}