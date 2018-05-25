using System.Collections.Generic;
using Manicure.BusinessLogic.Dtos;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IProcedureService
    {
        IEnumerable<Procedure> Get();

        void Add(ProcedureDto procedure);

        void Update(Procedure procedure);

        void Delete(int id);

        IEnumerable<Procedure> GetBy(int masterId);
    }
}