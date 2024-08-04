using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Web;

namespace vclass_clone.include
{
    public class Validate
    {
        public bool IsValidEmail(string email)
        {
            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        public bool IsValidPhone(string phone)
        {
            return phone.Length >= 10 && phone.All(char.IsDigit);
        }

        public bool IsStrongPassword(string password)
        {
            if (password.Length < 8) return false;

            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
    }
}