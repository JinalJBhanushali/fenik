using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.SecurityManager.AspNetIdentity
{
    public class ApplicationUser : IdentityUser
    {

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }


        public ApplicationUser(
            string email,
            string firstName,
            string lastName,
            string companyName = "",
            string createdById = ""
            )
        {
            EmailConfirmed = true;
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow;
            Email = email.Trim();
            UserName = Email;
            FirstName = firstName.Trim();
            LastName = lastName.Trim();
        }

    }

}
