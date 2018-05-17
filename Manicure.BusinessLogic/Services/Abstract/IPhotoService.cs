using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IPhotoService
    {
        IEnumerable<ExampleWork> Get();

        void AddDiploma(Diploma diploma);

        void AddExampleWork(ExampleWork exampleWork);

        void DeleteDiploma(int id);

        void DeleteExampleWork(int id);
    }
}