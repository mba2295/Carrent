using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(13, ErrorMessage = "Please enter Valid NIC number", MinimumLength = 13)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Please enter Valid NIC number")]
        public string NIC { get; set; }

        [Required]
        [StringLength(50)]
        public string Phone { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Car> Car { get; set; }
        public DbSet<MembershipType> membershipType { get; set; }
        public DbSet<Engine> Engine { get; set; }
        public DbSet<Manufacturer> Manufacturer { get; set; }
        public DbSet<Condition> Condition { get; set; }
        public DbSet<Rental> Rental { get; set; }


        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }



    }
}