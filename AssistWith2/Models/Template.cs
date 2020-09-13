using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AssistWith.Models
{
    public enum TemplateType { 
        txt , html 
    }
    public class Template
    {
        public Template()
        { 
        }
        public Template(string Content, string ext, string Name)
        {
            this.Content = Content;
            this.EXT = ext;
            this.Name = Name;
        }
        public string Title { get; set; }
        public string Content { get; set; }
        public string EXT { get; set; }
        public string Name { get; set; }
        public TemplateType TemplateType { get; set; }
    }
}