using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssistWith.Models;
using AssistWith.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AssistWith.Pages.Docs
{
    public class IndexModel : PageModel
    {  
        [BindProperty]
        public Template Template { get; set; } 
        private readonly IDocProvider _docProvider; 
        private readonly IJobLeadService _jobLeadService; 
        public IndexModel(
            IDocProvider docProvider
            , IJobLeadService jobLeadService)
        {
            this._docProvider = docProvider; 
            this._jobLeadService = jobLeadService; 
        }
        public void OnGet(int JobLeadId, string TemplateName)
        {
            Template = _docProvider.GetTemplateDocs().Where(t => t.Name == TemplateName).SingleOrDefault();
            JobLead JobLead = _jobLeadService.GetById(JobLeadId);
            Template.Content = _jobLeadService.CompileTemplate(Template.Content, JobLead);
        }
    }
}