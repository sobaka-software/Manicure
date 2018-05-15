using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IProcedureService
    {
        IEnumerable<Procedure> Get();

        void Add(ProcedureEntry procedureEntry, Schedule schedule);

        void Update(Procedure procedure);

        void Delete(int id);
    }
}