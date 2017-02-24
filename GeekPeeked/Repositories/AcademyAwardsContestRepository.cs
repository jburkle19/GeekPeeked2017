using System.Collections.Generic;
using GeekPeeked.Models;
using GeekPeeked.Repositories.Interfaces;

namespace GeekPeeked.Repositories
{
    public class AcademyAwardsContestRepository : BaseRepository, IAcademyAwardsContestRepository
    {
        public AcademyAwardsContestRepository(GeekPeekedDbContext context) : base(context) { }

        public void AddCategory(AcademyAwardsCategory category)
        {
            this._context.AcademyAwardsCategories.Add(category);
        }
        public void RemoveCategory(AcademyAwardsCategory category)
        {
            this._context.AcademyAwardsCategories.Remove(category);
        }

        public void AddNomineeToCategory(AcademyAwardsCategory category, AcademyAwardsNominee nominee)
        {
            if (category.AcademyAwardsNominees == null)
                category.AcademyAwardsNominees = new List<AcademyAwardsNominee>();

            category.AcademyAwardsNominees.Add(nominee);
        }
        public void RemoveNomineeFromCategory(AcademyAwardsCategory category, AcademyAwardsNominee nominee)
        {
            category.AcademyAwardsNominees.Remove(nominee);
        }
    }
}