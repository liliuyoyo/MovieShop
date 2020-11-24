using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieShop.Core.Entities;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Infrastructure.Data;

namespace MovieShop.Infrastructure.Repositories
{
    public class MovieRepository: EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            var topRating = _dbContext.Set<Review>().Max(r => r.Rating);
            return await _dbContext.Set<Movie>()
                .Where(m => m.Reviews
                    .Any(r => r.Rating == topRating))
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            return await _dbContext.Set<Movie>()
                .Where(m => m.MovieGenres
                    .Any(mg => mg.GenreId == genreId))
                .ToListAsync();
        }
        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var highestRevenue = _dbContext.Set<Movie>().Max(m => m.Revenue);
            return await _dbContext.Set<Movie>()
                .Where(m => m.Revenue == highestRevenue)
                .ToListAsync();
        }
    }
}