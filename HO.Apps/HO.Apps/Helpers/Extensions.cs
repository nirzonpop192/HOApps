using System;
using System.Text.RegularExpressions;

namespace HO.Apps.Helpers
{
    public static class Extensions
    {
        public static bool IsEmpty(this string content)
        {
            return string.IsNullOrWhiteSpace(content);
        }

        public static bool IsEmail(this string email)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(email, pattern, RegexOptions.IgnoreCase);
        }

        public static string GenerateErrorFileName()
        {
            return $"{DateTime.Now.ToString("yyyy-MM-dd_hhmmss")}_Error.txt";
        }
        public static bool IsValidPromoCode(this string content)
        {
            Regex regx = new Regex(@"\w{3,6}\-\w{3,9}(\-[a-zA-Z0-9]{1,6})?");
            return regx.IsMatch(content);
        }
        public static bool IsValidZipCode(this string content)
        {
            Regex regx = new Regex(@"\d{5}");
            return regx.IsMatch(content);
        }

    }
}
