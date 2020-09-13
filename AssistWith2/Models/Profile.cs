using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssistWith.Models
{
    public class Profile : IProfile
    {
        public int ProfileId { get; set; }
        public string PROCODE { get; set; }
        public string ProfileUrl { get; set; }
        public string Username { get; set; }
        public string PasswordSalt { get; set; }
        [RegularExpression(Common.Constants.PasswordFormat, ErrorMessage = Common.Constants.PasswordFormatMessage)]
        [Required]
        public string Password { get; set; }
        public string Notes { get; set; }
        public int SortOrder{ get; set; }
    }
}