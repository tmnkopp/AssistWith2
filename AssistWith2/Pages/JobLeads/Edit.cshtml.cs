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
using AssistWith.Services;

namespace AssistWith.Pages.JobLeads
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public JobLead JobLead { get; set; }
        [BindProperty]
        public List<Template> Templates { get; set; }
        [BindProperty]
        public string[] SelectedItems { get; set; }
         
        public SelectList selectList { get; set; }

        private readonly IJobLeadService _jobLeadService;
        private readonly IEncryptionService _encryptionService;
        private readonly IDocProvider _docProvider;
        public EditModel(
            IJobLeadService JobLeadService,
            IEncryptionService EncryptionService,
            IDocProvider DocProvider)
        {
            this._jobLeadService = JobLeadService;
            this._encryptionService = EncryptionService;
            this._docProvider = DocProvider;
        }  
        public IActionResult OnGet(int? id)
        {
            JobLead = new AssistWith.Models.JobLead() { JobLeadId = 0 };
            if (id != null && id > 0)
            {
                JobLead = _jobLeadService.GetAll()
                  .Where(o => o.JobLeadId == id.GetValueOrDefault())
                  .SingleOrDefault();
            }  
            Templates = new List<Template>();
            foreach (Template template in _docProvider.GetTemplateDocs()) { 
                template.Content = _jobLeadService.CompileTemplate(template.Content, JobLead);
                Templates.Add(template);
            }

            selectList = 
                new SelectList(Templates.ToList(), nameof(Template.Name), nameof(Template.Name));
            SelectedItems = new string[] { "resume.html", "cover.html" }; 
            return Page();
        }

        public IActionResult OnPost()
        {
            var items = SelectedItems.ToList();
            if (!ModelState.IsValid)
                return Page();
            if (JobLead.JobLeadId == 0)
                _jobLeadService.Insert(JobLead);
            else
                _jobLeadService.Update(JobLead);
            return Page();
        }
    }
}
