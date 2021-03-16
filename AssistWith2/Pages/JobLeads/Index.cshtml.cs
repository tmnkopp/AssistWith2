using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
using AssistWith.Services;
using Microsoft.AspNetCore.Mvc; 
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssistWith.Pages.JobLeads
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<AssistWith.Models.JobLead> JobLeads { get; set; }
        private readonly IJobLeadService _jobLeadService; 
        public IndexModel(IJobLeadService JobLeadService )
        {
            this._jobLeadService = JobLeadService; 
        }
        public void OnGet()
        {
            JobLeads = _jobLeadService.GetAll().ToList();
        } 
    }
}