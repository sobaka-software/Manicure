using System.Collections.Generic;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class ReviewClientService : IReviewClientService
    {
        private readonly IRepository<ReviewClient> _reviewClientRepository;
        private readonly IUnitOfWork _unitOfWork;
        
        public ReviewClientService(IRepository<ReviewClient> reviewClientRepository, IUnitOfWork unitOfWork)
        {
            _reviewClientRepository = reviewClientRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(ReviewClient reviewClient)
        {
            _reviewClientRepository.Create(reviewClient);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<ReviewClient> Get()
        {
            return _reviewClientRepository.GetAll();
        }
    }
}