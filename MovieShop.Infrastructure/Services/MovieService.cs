using System.Collections.Generic;
using System.Threading.Tasks;
using MovieShop.Core.Entities;
using MovieShop.Core.Models;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _repository;
        
        public MovieService(IMovieRepository repository)
        {
            _repository = repository;
        }
        
        public Task<PagedResultSet<MovieResponseModel>> GetMoviesByPagination(int pageSize = 20, int page = 0, string title = "")
        {
            throw new System.NotImplementedException();
        }

        public Task<PagedResultSet<MovieResponseModel>> GetAllMoviePurchasesByPagination(int pageSize = 20, int page = 0)
        {
            throw new System.NotImplementedException();
        }

        public Task<PaginatedList<MovieResponseModel>> GetAllPurchasesByMovieId(int movieId)
        {
            throw new System.NotImplementedException();
        }

        public async Task<MovieDetailsResponseModel> GetMovieAsync(int id)
        {
            var moive = await _repository.GetByIdAsync(id);
            if (moive == null) return null;
            var response = new MovieDetailsResponseModel
            {
                Id = moive.Id, Title = moive.Title, PosterUrl = moive.PosterUrl, BackdropUrl = moive.BackdropUrl,
                Budget = moive.Budget,ImdbUrl = moive.ImdbUrl, Overview = moive.Overview,TmdbUrl = moive.TmdbUrl,
                ReleaseDate = moive.ReleaseDate, RunTime = moive.RunTime, Price = moive.Price, Revenue = moive.Revenue,
                Tagline = moive.Tagline
            };
            List<MovieDetailsResponseModel.CastResponseModel> casts = new List<MovieDetailsResponseModel.CastResponseModel>();
            foreach (var movieCast in moive.MovieCasts)
            {
                var cast = movieCast.Cast;
                var castResponseModel = new MovieDetailsResponseModel.CastResponseModel();
                castResponseModel.Id = cast.Id;
                castResponseModel.Name = cast.Name;
                castResponseModel.Gender = cast.Gender;
                castResponseModel.ProfilePath = cast.ProfilePath;
                castResponseModel.TmdbUrl = cast.TmdbUrl;
                castResponseModel.Character = movieCast.Character;
            }
            response.Casts = casts;
            
            List<Genre> genres = new List<Genre>();
            foreach (var movieGenre in moive.MovieGenres)
            {
                genres.Add(movieGenre.Genre);
            }
            response.Genres = genres;
            response.FavoritesCount = moive.Favorites.Count;
            return response;
        }

        public Task<IEnumerable<ReviewMovieResponseModel>> GetReviewsForMovie(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> GetMoviesCount(string title = "")
        {
            throw new System.NotImplementedException();
        }

        public Task<IEnumerable<MovieResponseModel>> GetTopRatedMovies()
        {
            throw new System.NotImplementedException();
        }

        public async Task<IEnumerable<MovieResponseModel>> GetHighestGrossingMovies()
        {
            var movies = await _repository.GetHighestRevenueMovies();
            var movieResponseModels = new List<MovieResponseModel>();
            foreach (var movie in movies)
            {
                movieResponseModels.Add(new MovieResponseModel{
                    Id = movie.Id, PosterUrl = movie.PosterUrl, Title = movie.Title, ReleaseDate = movie.ReleaseDate
                });
            }
            return movieResponseModels;
        }

        public Task<IEnumerable<MovieResponseModel>> GetMoviesByGenre(int genreId)
        {
            throw new System.NotImplementedException();
        }

        public Task<MovieDetailsResponseModel> CreateMovie(MovieCreateRequest movieCreateRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<MovieDetailsResponseModel> UpdateMovie(MovieCreateRequest movieCreateRequest)
        {
            throw new System.NotImplementedException();
        }
    }
}