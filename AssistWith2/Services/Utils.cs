using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistWith.Services
{
    public static class Utils
    { 
        public static string GeneratePassword(int length)
        { 
            string[] randomChars = new[] {
                "ABCDEFGHJKLMNOPQRSTUVWXYZ",    
                "abcdefghijkmnopqrstuvwxyz",   
                "0123456789",
                "!@$?#_"
            };
            Random rand = new Random(Environment.TickCount + length);
            List<char> chars = new List<char>();
         
            for (int i = chars.Count; i < length || chars.Distinct().Count() < 6; i++)
            {
                string rcs = randomChars[rand.Next(0, randomChars.Length)];
                chars.Insert(
                    rand.Next(0, chars.Count)
                    , rcs[rand.Next(0, rcs.Length)]
                );
            }
            chars.Insert(0, randomChars[0][rand.Next(0, randomChars[0].Length)]);
            chars.Insert(1, randomChars[1][rand.Next(0, randomChars[1].Length)]);

            return new string(chars.ToArray());
        }
    }
}
