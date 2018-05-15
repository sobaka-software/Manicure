using System.Collections.Generic;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class ProcedureService : IProcedureService
    {
        private readonly IRepository<Procedure> _procedureRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcedureService(IRepository<Procedure> procedureRepository, IUnitOfWork unitOfWork)
        {
            _procedureRepository = procedureRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Procedure> Get()
        {
            return _procedureRepository.GetAll();
        }

        public void Update(Procedure procedure)
        {
            if (procedure.ProcedureId == 0)
            {
                _procedureRepository.Create(procedure);
            }
            else
            {
                _procedureRepository.Update(procedure);
            }

            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            _procedureRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}