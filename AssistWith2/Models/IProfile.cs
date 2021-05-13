namespace AssistWith.Models
{
    public interface IProfile
    {
        string Notes { get; set; }
        string Password { get; set; }
        string PasswordSalt { get; set; }
        string PROCODE { get; set; }
        int ProfileId { get; set; }
        string ProfileUrl { get; set; }
        string ProfileUrlNormalized { get;  }
        string Username { get; set; }
    }
}