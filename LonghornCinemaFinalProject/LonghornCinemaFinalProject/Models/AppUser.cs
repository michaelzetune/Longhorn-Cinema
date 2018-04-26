using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;

namespace LonghornCinemaFinalProject.Models
{

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    //NOTE: This is the class for users
    public class AppUser : IdentityUser
    {
        //TODO: Put any additional fields that you need for your user here
        //First name is here as an example
        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First Name")]
        public String FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Display(Name = "Last Name")]
        public String LastName { get; set; }

        [Required(ErrorMessage = "Birthday is required")]
        [Display(Name = "Birthday")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Display(Name = "Street Address")]
        public String StreetAddress { get; set; }

        [Required(ErrorMessage = "City is required")]
        [Display(Name = "City")]
        public String City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Display(Name = "State")]
        public String State { get; set; }

        [Required(ErrorMessage = "Zip Code is required")]
        [Display(Name = "Zip Code")]
        public Int32 ZipCode { get; set; }

        public Decimal PopcornPointsBalance { get; set; }

        //TODO: Add any navigational properties needed for your user
        // Orders
        public virtual List<Order> Orders { get; set; }
        // MovieReviews
        public virtual List<MovieReview> MovieReviews { get; set; }
        // CreditCards
        public virtual List<CreditCard> CreditCards { get; set; }

        public AppUser()
        {
            if (Orders == null)
            {
                Orders = new List<Order>();
            }

            if (MovieReviews == null)
            {
                MovieReviews = new List<MovieReview>();
            }

            if (CreditCards == null)
            {
                CreditCards = new List<CreditCard>();
            }
        }

        //This method allows you to create a new user
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<AppUser> manager)
        {
            // NOTE: The authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}