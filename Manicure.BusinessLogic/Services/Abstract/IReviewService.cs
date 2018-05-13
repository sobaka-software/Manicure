using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IReviewService
    {
        void Add(ReviewClient review);

        void Delete(int id);

        IEnumerable<ReviewClient> Get();
    }
}