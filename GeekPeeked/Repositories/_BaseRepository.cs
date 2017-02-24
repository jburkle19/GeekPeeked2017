using GeekPeeked.Models;

namespace GeekPeeked.Repositories
{
    public class BaseRepository
    {
        protected GeekPeekedDbContext _context;

        public BaseRepository(GeekPeekedDbContext context)
        {
            _context = context;
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}