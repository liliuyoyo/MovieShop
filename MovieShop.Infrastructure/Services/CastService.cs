using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging.Abstractions;
using MovieShop.Core.Entities;
using MovieShop.Core.Models;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly IAsyncRepository<Cast> _castRepository;

        public CastService(IAsyncRepository<Cast> castRepository)
        {
            _castRepository = castRepository;
        }
        
        public async Task<CastDetailsResponseModel> GetCastDetailsWithMovies(int id)
        {
            var cast = await _castRepository.GetByIdAsync(id);
            var castDetailsResponseModel = new CastDetailsResponseModel();
            if (cast != null)
            {
                castDetailsResponseModel.Id = cast.Id;
                castDetailsResponseModel.Gender = cast.Gender;
                castDetailsResponseModel.Name = cast.Name;
                castDetailsResponseModel.ProfilePath = cast.ProfilePath;
                castDetailsResponseModel.TmdbUrl = cast.TmdbUrl;
                
                List<MovieResponseModel> movieResponseModels = new List<MovieResponseModel>();
                foreach (var movieCast in cast.MovieCasts)
                {
                    Movie movie = movieCast.Movie;
                    var response = new MovieResponseModel
                    {
                        Id = movie.Id, Title = movie.Title, PosterUrl = movie.PosterUrl, ReleaseDate = movie.ReleaseDate
                    };
                }
            }
            return castDetailsResponseModel;
        }
    }
}