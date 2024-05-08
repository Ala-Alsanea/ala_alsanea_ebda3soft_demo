using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace ala_alsanea_ebda3soft_demo.Persistent.Models
{
    public class User : IdentityUser
    {
        public User()
        {
            EmailConfirmed = true;
        }
    }
}