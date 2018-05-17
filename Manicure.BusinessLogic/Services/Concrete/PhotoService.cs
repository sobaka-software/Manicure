using System.Collections.Generic;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class PhotoService : IPhotoService
    {
        private readonly IRepository<Diploma> _diplomaRepository;
        private readonly IRepository<ExampleWork> _exampleWorkRepository;
        private readonly IUnitOfWork _unitOfWork;

        public PhotoService(
            IRepository<ExampleWork> exampleWorkRepository,
            IRepository<Diploma> diplomaRepository,
            IUnitOfWork unitOfWork)
        {
            _exampleWorkRepository = exampleWorkRepository;
            _diplomaRepository = diplomaRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<ExampleWork> Get()
        {
            return _exampleWorkRepository.GetAll();
        }

        public void AddDiploma(Diploma diploma)
        {
            _diplomaRepository.Create(diploma);
            _unitOfWork.SaveChanges();
        }

        public void AddExampleWork(ExampleWork exampleWork)
        {
            _exampleWorkRepository.Create(exampleWork);
            _unitOfWork.SaveChanges();
        }

        public void DeleteDiploma(int id)
        {
            _diplomaRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }

        public void DeleteExampleWork(int id)
        {
            _exampleWorkRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}