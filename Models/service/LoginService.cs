using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vclass_clone.Models
{
    public class LoginService
    {
        private readonly LMSContext _context;
        public LoginService()
        {
            _context = new LMSContext();
        }

        public (object User, string Role) Login(string email, string password)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);

            if (user != null)
            {
                switch (user.Role)
                {
                    case "Admin":
                        var admin = _context.Admins.SingleOrDefault(a => a.UserId == user.Id);
                        return (admin, "Admin");
                    case "Facilitator":
                        var facilitator = _context.Facilitators.SingleOrDefault(f => f.UserId == user.Id);
                        return (facilitator, "Facilitator");
                    case "Student":
                        var student = _context.Students.SingleOrDefault(s => s.UserId == user.Id);
                        return (student, "Student");
                }
            }

            return (null, null);
        }
    }
}