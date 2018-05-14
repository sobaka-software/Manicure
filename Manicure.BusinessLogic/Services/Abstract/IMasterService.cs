using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IMasterService
    {
        void Add(Master master, string userLogin);

        IEnumerable<Master> GetAll();
    }
}