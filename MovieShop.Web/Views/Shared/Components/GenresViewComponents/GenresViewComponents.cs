using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.Web.Views.Shared.Components.GenresViewComponents
{
    public class GenresViewComponents : ViewComponent
    {
        private IGenreService _genreService;

        public GenresViewComponents(IGenreService genreService)
        {
            _genreService = genreService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var genres =  await _genreService.GetAllGenres();
            return View(genres);
        }
    }
}