using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MovieShop.Core.Entities;
using MovieShop.Core.ServiceInterfaces;
using MovieShop.Infrastructure.Data;
using MovieShop.Infrastructure.Repositories;

namespace MovieShop.Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        
        public Task<IEnumerable<Genre>> GetAllGenres()
        {
            throw new NotImplementedException();
        }
    }
}