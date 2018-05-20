using System.Collections.Generic;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class ReviewClientService : IReviewClientService
    {
        private readonly IRepository<ReviewClient> _reviewClientRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ReviewClientService(
            IRepository<ReviewClient> reviewClientRepository, 
            IUnitOfWork unitOfWork, 
            IRepository<User> userRepository)
        {
            _reviewClientRepository = reviewClientRepository;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public void Add(ReviewClient reviewClient, string userLogin)
        {
            var user = _userRepository.GetFirst(u => u.Login == userLogin);

            reviewClient.UserId = user.UserId;

            _reviewClientRepository.Create(reviewClient);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<ReviewClient> Get()
        {
            return _reviewClientRepository.GetAll();
        }

        public void Delete(int id)
        {
            _reviewClientRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}