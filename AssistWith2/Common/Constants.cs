using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistWith.Common
{
    public static class Constants
    {
        public const int SaltSize = 24;
        public const string PasswordFormat = @"[\S]{8,}";
        public const string PasswordFormatMessage = @"
            Requires at least 8 letters, numbers, special characters" +
            " - no white space allowed";
    }
}
