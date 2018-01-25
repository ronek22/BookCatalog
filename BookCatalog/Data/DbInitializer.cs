using BookCatalog.Helpers;
using BookCatalog.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookCatalog.Data
{
    public class DbInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public DbInitializer(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public void Seed()
        {
            _context.Database.Migrate();

            // add example roles
            if (!_context.Roles.Any())
            {
                var roleNames = new[]
                {
                    RoleHelper.Administrator,
                    RoleHelper.Moderator,
                    RoleHelper.User
                };

                foreach (var roleName in roleNames)
                {
                    // it creates role in database
                    var role = new IdentityRole(roleName) { NormalizedName = RoleHelper.Normalize(roleName) };
                    _context.Roles.Add(role);
                }
            }

            // add admin account
            if (!_context.ApplicationUsers.Any())
            {
                const string userName = "admin@admin.com";
                const string userPass = "admin1";

                var user = new ApplicationUser { UserName = userName, Email = userName };
                _userManager.CreateAsync(user, userPass).Wait();
                _userManager.AddToRoleAsync(user, RoleHelper.Administrator).Wait();
            }

            _context.SaveChanges();
        }
    }
}
