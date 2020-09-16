using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AssistWith.Models;
using Microsoft.EntityFrameworkCore;
using AssistWith.Services;
using Microsoft.AspNetCore.Authorization;

namespace AssistWith.Pages.Profiles
{
    [Authorize(Roles = "Admin")]
    public class IndexModel : PageModel
    { 
        [BindProperty]
        public List<AssistWith.Models.Profile> Profiles { get; set; }
        private readonly IService<AssistWith.Models.Profile> _ProfileService;
        public IndexModel(IService<AssistWith.Models.Profile> ProfileService)
        {
            _ProfileService = ProfileService;
        }
        public void OnGet()
        {
            Profiles = _ProfileService.GetAll().ToList();  
        } 
    }
}