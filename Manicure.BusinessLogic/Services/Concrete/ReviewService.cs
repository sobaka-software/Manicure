using System.Collections.Generic;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository<ReviewClient> _reviewClientRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IRepository<ReviewClient> reviewClientRepository, IUnitOfWork unitOfWork)
        {
            _reviewClientRepository = reviewClientRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(ReviewClient review)
        {
            _reviewClientRepository.Create(review);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _reviewClientRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<ReviewClient> Get()
        {
            return _reviewClientRepository.GetAll();
        }
    }
}