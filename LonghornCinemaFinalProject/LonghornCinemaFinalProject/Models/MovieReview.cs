using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LonghornCinemaFinalProject.Models
{
    public enum ApprovalStatus { NotApproved, Approved}

    public class MovieReview
    {
        // Properties
        // MovieReviewID
        public Int32 MovieReviewID { get; set; }

        // ReviewText
        public String ReviewText { get; set; }

        // NumStars
        public Decimal NumStars { get; set; }

        // Approved
        public ApprovalStatus ApprovalStatus { get; set; }

        // Navigation Properties
        // Movie
        // User
    }
}