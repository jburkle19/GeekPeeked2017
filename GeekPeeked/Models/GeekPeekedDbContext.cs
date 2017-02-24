using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GeekPeeked.Models
{
    public class GeekPeekedDbContext : DbContext
    {
        public GeekPeekedDbContext() : base("DefaultConnection")
        {
        }

        public DbSet<Contest> Contests { get; set; }

        public DbSet<AcademyAwardsCategory> AcademyAwardsCategories { get; set; }
        public DbSet<AcademyAwardsNominee> AcademyAwardsNominees { get; set; }

        public DbSet<ContestEntry> ContestEntries { get; set; }
        public DbSet<AcademyAwardsContestEntrySelection> AcademyAwardsContestEntrySelections { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}