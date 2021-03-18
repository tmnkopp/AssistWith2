using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AssistWith.Models;
using AssistWith.Services;
using HandlebarsDotNet;

namespace AssistWith.Pages
{ 
    public class IndexModel : PageModel
    {
        [BindProperty]
        public string TemplateRendered { get; set; } 
        public IndexModel( ) 
        { 
        } 
        public void OnGet()
        {
            string source =
                @"<div class=""entry"">
                  <h1>{{title}}</h1>
                  <div class=""body"">
                    {{body}}
                  </div>
                </div>";

            var template = Handlebars.Compile(source);

            var data = new
            {
                title = "My new post",
                body = "This is my first post!"
            };

            var result = template(data);
            TemplateRendered = result;
        }
        public JsonResult OnGetFoo()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("1","aaa");
            dic.Add("2","bbb");
            return new JsonResult(dic);
        }
    }  
}
