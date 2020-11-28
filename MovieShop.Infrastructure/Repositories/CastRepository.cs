using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repositories
{
    public class CastRepository : EfRepository<Cast> 
    {
        public CastRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        
        public override async Task<Cast> GetByIdAsync(int id)
        {
            var cast = await _dbContext.Casts
                .Include(m => m.MovieCasts).ThenInclude(mc => mc.Movie)
                .FirstOrDefaultAsync(m => m.Id == id);
            return cast;
        }
    }
}