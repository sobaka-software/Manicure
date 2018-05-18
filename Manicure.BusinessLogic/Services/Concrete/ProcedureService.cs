using System.Collections.Generic;
using AutoMapper;
using Manicure.BusinessLogic.Dtos;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class ProcedureService : IProcedureService
    {
        private readonly IRepository<Procedure> _procedureRepository;
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<Schedule> _scheduleRepository;
        private readonly IRepository<ProcedureEntry> _procedureEntryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ProcedureService(
            IRepository<Procedure> procedureRepository,
            IUnitOfWork unitOfWork,
            IRepository<Client> clientRepository,
            IRepository<Schedule> scheduleRepository,
            IRepository<ProcedureEntry> procedureEntryRepository)
        {
            _procedureRepository = procedureRepository;
            _unitOfWork = unitOfWork;
            _clientRepository = clientRepository;
            _scheduleRepository = scheduleRepository;
            _procedureEntryRepository = procedureEntryRepository;
        }

        public void Add(ProcedureDto procedure)
        {
            var client = _clientRepository.GetFirst(c => c.User.Login == procedure.ClientLogin);
            var procedureForEntry = _procedureRepository.GetFirst(p => p.ProcedureId == procedure.ProcedureId);
            var schedule = Mapper.Map<ProcedureDto, Schedule>(procedure);
            schedule.EndTime = procedure.StartTime.AddMinutes(procedureForEntry.Duration);
            _scheduleRepository.Create(schedule);
            _unitOfWork.SaveChanges();

            var procedureEntry = Mapper.Map<ProcedureDto, ProcedureEntry>(procedure);

            procedureEntry.ScheduleId = schedule.ScheduleId;
            procedureEntry.ClientId = client.ClientId;

            _procedureEntryRepository.Create(procedureEntry);
            _unitOfWork.SaveChanges();
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
            _procedureEntryRepository.Delete(id);
            _unitOfWork.SaveChanges();
        }
    }
}