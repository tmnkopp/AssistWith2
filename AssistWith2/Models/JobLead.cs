using AssistWith.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssistWith.Models
{
    public class JobLead : IJobLead
    {
        [Key]
        public int JobLeadId { get; set; }
        public string JobLeadCode { get; set; }

        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string ContactAddress { get; set; }

        public string PortalUrl { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        [RegularExpression(Constants.PasswordFormat, ErrorMessage = Constants.PasswordFormatMessage)]
        public string Password { get; set; }
         
        public string JobTitle { get; set; }
        public string JobSource { get; set; }
        public string JobSourceURL { get; set; }
        public string JobDescription { get; set; }

        public DateTime? ApplyDate { get; set; }
        public string Notes { get; set; }
    }
}

 