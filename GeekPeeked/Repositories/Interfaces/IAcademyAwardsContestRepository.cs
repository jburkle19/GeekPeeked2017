using GeekPeeked.Models;


namespace GeekPeeked.Repositories.Interfaces
{
    public interface IAcademyAwardsContestRepository : IBaseRepository
    {
        void AddCategory(AcademyAwardsCategory category);
        void RemoveCategory(AcademyAwardsCategory category);

        void AddNomineeToCategory(AcademyAwardsCategory category, AcademyAwardsNominee nominee);
        void RemoveNomineeFromCategory(AcademyAwardsCategory category, AcademyAwardsNominee nominee);
    }
}