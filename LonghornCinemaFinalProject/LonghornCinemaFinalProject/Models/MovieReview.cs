using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace LonghornCinemaFinalProject.Models
{
    public enum ApprovalStatus {NotApproved, Approved}

    public class MovieReview
    {
        // Properties
        // MovieReviewID
        public Int32 MovieReviewID { get; set; }

        // ReviewText
        [Display(Name = "Review Text")]
        [StringLength(100, ErrorMessage = "The review must be fewer than 100 characters.")]
        public String ReviewText { get; set; }

        // NumStars
        [Display(Name = "Review Rating")]
        [Range(0, 5)]
        [DisplayFormat(DataFormatString = "{0:0}")]
        public Decimal NumStars { get; set; }

        // Approved
        public ApprovalStatus ApprovalStatus { get; set; }

        // Votes
        public Int32 Votes { get; set; }

        // Navigation Properties
        // Movie
        public virtual Movie Movie { get; set; }
    }
}