using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistWith.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace AssistWith.Pages.Profiles
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public AssistWith.Models.Profile Profile { get; set; }

        private readonly IService<AssistWith.Models.Profile> _ProfileService;
        private readonly UserManager<IdentityUser> _userManager;
        public EditModel(
            IService<AssistWith.Models.Profile> ProfileService
            , UserManager<IdentityUser> userManager)
        {
            _ProfileService = ProfileService;
            _userManager = userManager;
        }
        public IActionResult OnGet(int? id)
        {  
            Profile = new AssistWith.Models.Profile() { 
                ProfileId = 0 
                , Password= Utils.GeneratePassword(16)
                , Username = _userManager.GetUserName(User)
                , SortOrder=50 };
            if (id != null && id > 0) {
                Profile = _ProfileService.GetAll()
                  .Where(o => o.ProfileId == id.GetValueOrDefault())
                  .SingleOrDefault();
            } 
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) {
                var errors = ModelState.Values.SelectMany(v => v.Errors);
                return Page();
            }   
            if (Profile.ProfileId == 0)
                _ProfileService.Insert(Profile); 
            else
                _ProfileService.Update(Profile); 
            return RedirectToPage("Edit", new { id = Profile.ProfileId }); 
        }
    }
}