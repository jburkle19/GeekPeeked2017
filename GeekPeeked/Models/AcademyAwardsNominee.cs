using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public class AcademyAwardsNominee : ITrackable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("AcademyAwardsCategory")]
        public int AcademyAwardsCategoryId { get; set; }
        public AcademyAwardsCategory AcademyAwardsCategory { get; set; }

        public string NomineeText { get; set; } = string.Empty;

        public bool IsWinner { get; set; } = false;

        public int SortOrder { get; set; } = 0;

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; } = null;
        public DateTime? ModifiedDate { get; set; } = null;
    }
}