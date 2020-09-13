using System;

namespace AssistWith.Models
{
    public interface IJobLead
    {
        DateTime? ApplyDate { get; set; }
        string CompanyName { get; set; }
        string ContactAddress { get; set; }
        string ContactName { get; set; }
        string ContactPhone { get; set; }
        string JobDescription { get; set; }
        string JobLeadCode { get; set; }
        int JobLeadId { get; set; }
        string JobSource { get; set; }
        string JobSourceURL { get; set; }
        string JobTitle { get; set; }
        string Notes { get; set; }
        string Password { get; set; }
        string PasswordSalt { get; set; }
        string PortalUrl { get; set; }
        string Username { get; set; }
    }
}