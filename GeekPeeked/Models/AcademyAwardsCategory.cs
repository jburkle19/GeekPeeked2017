using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public class AcademyAwardsCategory : ITrackable
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Contest")]
        public int ContestId { get; set; }
        public Contest Contest { get; set; }

        public string CategoryTitle { get; set; } = string.Empty;
        public string Year { get; set; } = string.Empty;

        public int PointValue { get; set; } = 0;

        public int SortOrder { get; set; } = 0;

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; } = null;
        public DateTime? ModifiedDate { get; set; } = null;

        public virtual ICollection<AcademyAwardsNominee> AcademyAwardsNominees { get; set; }
    }
}