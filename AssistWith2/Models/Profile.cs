using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AssistWith.Models
{
    public class Profile : IProfile
    {
        [Key]
        public int ProfileId { get; set; }
        public string PROCODE { get; set; }
        public string ProfileUrl { get; set; }
        [NotMapped]
        public string ProfileUrlNormalized => (ProfileUrl?.Contains("http") ?? false) ? ProfileUrl : $"https://{ProfileUrl}" ;
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        [RegularExpression(Common.Constants.PasswordFormat, ErrorMessage = Common.Constants.PasswordFormatMessage)]
        [Required]
        public string Password { get; set; }
        public string Notes { get; set; }
        public int SortOrder{ get; set; }
    }
}