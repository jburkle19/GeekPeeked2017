using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GeekPeeked.Models;
using GeekPeeked.Helpers;

namespace GeekPeeked.ViewModels
{
    public class ContestIndexViewModel
    {
        public bool ContestSignUpActive { get; set; } = CoreConfiguration.IsActiveContestSignUpOpen;

        public int? ActiveContestId { get; set; } = CoreConfiguration.ActiveContestId;
        public Contest ActiveContest { get; set; }

        public int? LastContestId { get; set; }
        public Contest LastContest { get; set; }

        public string PastContestsYearFilter { get; set; } = DateTime.Now.Year.ToString();
        public List<Contest> PastContests { get; set; }
    }

    public class ContestSignUpViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Email is not valid")]
        [DisplayName("Email")]
        public string Email { get; set; }

        public int ContestId { get; set; }
        public Contest Contest { get; set; }

        public List<ContestCategoryViewModel> Categories { get; set; }
    }

    public class UpdateContestViewModel
    {
        [Required(ErrorMessage = "Email is required")]
        [DisplayName("Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Verification Code is required")]
        [DisplayName("Verification Code")]
        public string VerificationCode { get; set; }

        public int ContestId { get; set; }
        public Contest Contest { get; set; }
    }

    public class ViewContestEntryViewModel
    {
        public int ContestEntryId { get; set; }
        public ContestEntry ContestEntry { get; set; }
        public Contest Contest { get; set; }
        
        public List<ContestCategoryViewModel> Categories { get; set; }
    }

    public class EditContestEntryViewModel
    {
        public int ContestEntryId { get; set; }
        public ContestEntry ContestEntry { get; set; }
        public Contest Contest { get; set; }

        public List<ContestCategoryViewModel> Categories { get; set; }
    }

    public class ContestCategoryViewModel
    {
        public int CategoryId { get; set; }
        public string CategoryTitle { get; set; }
        public int SortOrder { get; set; }

        public int? SelectedNomineeId { get; set; } = null;
        public List<ContestNomineeViewModel> Nominees { get; set; }
    }

    public class ContestNomineeViewModel
    {
        public int NomineeId { get; set; }
        public string NomineeText { get; set; }
        public int SortOrder { get; set; }
    }
}