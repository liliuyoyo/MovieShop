using System.Threading.Tasks;
using MovieShop.Core.Entities;
using MovieShop.Core.Models;
using MovieShop.Core.RepositoryInterfaces;
using MovieShop.Core.ServiceInterfaces;

namespace MovieShop.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            throw new System.NotImplementedException();
        }

        public Task<UserRegisterResponseModel> CreateUser(UserRegisterRequestModel requestModel)
        {
            throw new System.NotImplementedException();
        }

        public async Task<UserRegisterResponseModel> GetUserDetails(int id)
        {
            var user =  await _userRepository.GetByIdAsync(id);
            return null;
        }

        public async Task<User> GetUser(string email)
        {
            return await _userRepository.GetUserByEmail(email);
        }

        public Task<PagedResultSet<User>> GetAllUsersByPagination(int pageSize = 20, int page = 0, string lastName = "")
        {
            throw new System.NotImplementedException();
        }

        public Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> FavoriteExists(int id, int movieId)
        {
            throw new System.NotImplementedException();
        }

        public Task<FavoriteResponseModel> GetAllFavoritesForUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task PurchaseMovie(PurchaseRequestModel purchaseRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task<PurchaseResponseModel> GetAllPurchasesForUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task AddMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateMovieReview(ReviewRequestModel reviewRequest)
        {
            throw new System.NotImplementedException();
        }

        public Task DeleteMovieReview(int userId, int movieId)
        {
            throw new System.NotImplementedException();
        }

        public Task<ReviewResponseModel> GetAllReviewsByUser(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}