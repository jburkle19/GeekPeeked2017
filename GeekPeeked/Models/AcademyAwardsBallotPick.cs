using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public class AcademyAwardsBallotPick : ITrackable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Email { get; set; } = string.Empty;
        public string VerificationCode { get; set; } = Guid.NewGuid().ToString();
        public bool IsVerfied { get; set; } = false;

        public int ContestId { get; set; }
        public int AcademyAwardsCategoryId { get; set; }
        public int SelectedAcademyAwardsNomineeId { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; } = null;
        public DateTime? ModifiedDate { get; set; } = null;
    }
}