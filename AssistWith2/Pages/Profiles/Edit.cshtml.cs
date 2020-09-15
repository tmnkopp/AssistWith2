using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistWith.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace AssistWith.Pages.Profiles
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public AssistWith.Models.Profile Profile { get; set; }

        private readonly IService<AssistWith.Models.Profile> _ProfileService;
        public EditModel(IService<AssistWith.Models.Profile> ProfileService)
        {
            _ProfileService = ProfileService;
        }
        public IActionResult OnGet(int? id)
        {
            Profile = new AssistWith.Models.Profile() { ProfileId = 0 };
            if (id != null)
                Profile = _ProfileService.GetAll()
                        .Where(o => o.ProfileId == id.GetValueOrDefault())
                        .SingleOrDefault();
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            if (Profile.ProfileId == 0)
                _ProfileService.Insert(Profile);
            else
                _ProfileService.Update(Profile);
            return Page();
        }
    }
}