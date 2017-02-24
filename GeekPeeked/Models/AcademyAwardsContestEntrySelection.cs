using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeekPeeked.Models
{
    public class AcademyAwardsContestEntrySelection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ContestEntry")]
        public int ContestEntryId { get; set; }
        public ContestEntry ContestEntry { get; set; }

        public int AcademyAwardsCategoryId { get; set; }
        public int SelectedAcademyAwardNomineeId { get; set; }
    }
}