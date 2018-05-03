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
        [DisplayFormat(DataFormatString = "{0:F1}")]
        public int NumStars { get; set; }

        // Approved
        public ApprovalStatus ApprovalStatus { get; set; }

        // Votes
        [Display(Name = "Net Vote")]
        [DisplayFormat(DataFormatString = "{0:F0}")]
        public Int32 Votes { get; set; }

        // Navigation Properties
        // Movie
        public virtual Movie Movie { get; set; }

        // AppUser
        public virtual AppUser AppUser { get; set; }

        // Users that upvoted for this review
        public virtual List<AppUser> UsersThatUpVoted { get; set; }

        // Users that downvoted for this review
        public virtual List<AppUser> UsersThatDownVoted { get; set; }
    }
}