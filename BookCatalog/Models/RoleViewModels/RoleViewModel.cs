using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Models.RoleViewModels
{
    public class RoleViewModel
    {
        public ApplicationUser applicationUser { get; set; }
        public string ApplicationUserId { get; set; }
        public string RoleId { get; set; }
        public IEnumerable<IdentityRole> Roles { get; set; }
    }
}
