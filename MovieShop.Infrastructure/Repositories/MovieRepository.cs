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
        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies
                .Include(m => m.MovieCasts).ThenInclude(m => m.Cast)
                .Include(m => m.MovieGenres).ThenInclude(m => m.Genre)
                .Include(m => m.Favorites)
                .FirstOrDefaultAsync(m => m.Id == id);
            return movie;
        }
        public async Task<IEnumerable<Movie>> GetTopRatedMovies()
        {
            var topRating = _dbContext.Set<Review>().Max(r => r.Rating);
            return await _dbContext.Movies
                .Where(m => m.Reviews
                    .Any(r => r.Rating == topRating))
                .ToListAsync();
        }
        
        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int genreId)
        {
            return await _dbContext.Movies
                .Where(m => m.MovieGenres
                    .Any(mg => mg.GenreId == genreId))
                .ToListAsync();
        }
        public async Task<IEnumerable<Movie>> GetHighestRevenueMovies()
        {
            var movies =  await _dbContext.Movies
                .OrderByDescending(m => m.Revenue).Take(50).ToListAsync();
            return movies;
        }
    }
}