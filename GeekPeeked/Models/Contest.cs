using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public enum ContestType
    {
        BoxOffice,
        Bracket,
        AcademyAwardsBallot
    }

    public class Contest : ITrackable
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public ContestType ContestType { get; set; }

        public string Title { get; set; } = string.Empty;

        public string Objective { get; set; } = string.Empty;
        public string Rules { get; set; } = string.Empty;

        public string Results { get; set; } = string.Empty;
        public string Standings { get; set; } = string.Empty;

        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }

        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;

        public string ModifiedBy { get; set; } = null;
        public DateTime? ModifiedDate { get; set; } = null;

        public virtual ICollection<AcademyAwardsCategory> AcademyAwardsCategories { get; set; }
    }
}