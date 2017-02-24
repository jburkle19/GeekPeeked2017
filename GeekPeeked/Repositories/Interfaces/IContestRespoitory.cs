using System.Collections.Generic;
using GeekPeeked.Models;

namespace GeekPeeked.Repositories.Interfaces
{
    public interface IContestRespoitory : IBaseRepository
    {
        Contest GetContest(int id);

        IEnumerable<Contest> GetContests();
        IEnumerable<Contest> GetContests(string year);

        void Add(Contest contest);
        void Remove(Contest contest);

        void AddEntry(ContestEntry entry);
        void RemoveEntry(ContestEntry entry);

        ContestEntry GetContestEntry(int contestEntryId);
        ContestEntry GetContestEntry(int contestId, string email, string verificationCode);

        bool VerifyContestEntry(int contestId, string email, string verificationCode);

        AcademyAwardsContestEntrySelection GetSelection(ContestEntry entry, int categoryId);

        void AddAcademyAwardsNomineeSelectionToContestEntry(ContestEntry entry, AcademyAwardsContestEntrySelection selection);
        void RemoveAcademyAwardsNomineeSelectionFromContestEntry(ContestEntry entry, AcademyAwardsContestEntrySelection selection);
    }
}
