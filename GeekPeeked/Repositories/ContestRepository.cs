using System.Linq;
using System.Collections.Generic;
using GeekPeeked.Models;
using GeekPeeked.Repositories.Interfaces;

namespace GeekPeeked.Repositories
{
    public class ContestRepository : BaseRepository, IContestRespoitory
    {
        public ContestRepository(GeekPeekedDbContext context) : base(context) { }

        public Contest GetContest(int id)
        {
            return (from c in this._context.Contests where c.Id == id select c).FirstOrDefault();
        }

        public IEnumerable<Contest> GetContests()
        {
            return this._context.Contests.OrderByDescending(c => c.EndDateTime);
        }
        public IEnumerable<Contest> GetContests(string year)
        {
            return this._context.Contests.Where(c => c.EndDateTime.Year.ToString() == year).OrderByDescending(c => c.EndDateTime);
        }

        public void Add(Contest contest)
        {
            this._context.Contests.Add(contest);
        }
        public void Remove(Contest contest)
        {
            this._context.Contests.Remove(contest);
        }

        public void AddEntry(ContestEntry entry)
        {
            this._context.ContestEntries.Add(entry);
        }

        public void RemoveEntry(ContestEntry entry)
        {
            this._context.ContestEntries.Remove(entry);
        }

        public ContestEntry GetContestEntry(int contestEntryId)
        {
            return (from c in this._context.ContestEntries where c.Id == contestEntryId select c).FirstOrDefault();
        }
        public ContestEntry GetContestEntry(int contestId, string email, string verificationCode)
        {
            return (from c in this._context.ContestEntries where c.ContestId == contestId && c.Email.ToLower() == email.ToLower() && c.VerificationCode == verificationCode select c).FirstOrDefault();
        }

        public bool VerifyContestEntry(int contestId, string email, string verificationCode)
        {
            bool result = false;

            var entry = this.GetContestEntry(contestId, email, verificationCode);
            if (entry != null && entry.ContestId == contestId)
            {
                result = true;
                entry.IsVerfied = true;
            }

            return result;
        }

        public AcademyAwardsContestEntrySelection GetSelection(ContestEntry entry, int categoryId)
        {
            return entry.AcademyAwardsContestEntrySelections.FirstOrDefault(s => s.AcademyAwardsCategoryId == categoryId);
        }

        public void AddAcademyAwardsNomineeSelectionToContestEntry(ContestEntry entry, AcademyAwardsContestEntrySelection selection)
        {
            if (entry.AcademyAwardsContestEntrySelections == null)
                entry.AcademyAwardsContestEntrySelections = new List<AcademyAwardsContestEntrySelection>();

            entry.AcademyAwardsContestEntrySelections.Add(selection);
        }
        public void RemoveAcademyAwardsNomineeSelectionFromContestEntry(ContestEntry entry, AcademyAwardsContestEntrySelection selection)
        {
            entry.AcademyAwardsContestEntrySelections.Remove(selection);
        }
    }
}