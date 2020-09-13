namespace AssistWith.Models
{
    public interface IClient
    {
        int ClientID { get; set; }
        string Company { get; set; }
        string ContactAddress { get; set; }
        string ContactName { get; set; }
        string DBLogin { get; set; }
        string DBPass { get; set; }
        string Email { get; set; }
        string FTPLogin { get; set; }
        string FTPPass { get; set; }
        string HostingLogin { get; set; }
        string HostingPass { get; set; }
        string HostingUrl { get; set; }
        string Notes { get; set; }
        string PasswordSalt { get; set; }
        string Phone { get; set; }
        string SiteLogin { get; set; }
        string SitePassword { get; set; }
        string WebsiteUrl { get; set; }
    }
}