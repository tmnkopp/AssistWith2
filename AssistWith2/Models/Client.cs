using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssistWith.Models
{
    public class Client : IClient
    {
        [Key]
        public int ClientID { get; set; }
        public string Company { get; set; }
        public string ContactName { get; set; }
        public string ContactAddress { get; set; }
        public string Phone { get; set; } 
        public string Email { get; set; }

        public string PasswordSalt { get; set; }

        public string WebsiteUrl { get; set; }
        public string SiteLogin { get; set; }
        public string SitePassword { get; set; }
        
        public string HostingUrl { get; set; }
        public string HostingLogin { get; set; }
        public string HostingPass { get; set; }
        public string FTPLogin { get; set; }
        public string FTPPass { get; set; }
        public string DBLogin { get; set; }
        public string DBPass { get; set; }

        public string Notes { get; set; }
    }
}