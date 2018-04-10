using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public class Role
    {
        // Properties
        // RoleID
        public Int32 RoleID { get; set; }

        // Name
        public String RoleName { get; set; }

        // Navigation Properties
        // Users
        public virtual List<User> Users { get; set; }

        public Role()
        {
            if (Users == null)
            {
                Users = new List<User>();
            }
        }
    }
}