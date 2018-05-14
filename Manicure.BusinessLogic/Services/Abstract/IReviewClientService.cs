using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IReviewClientService
    {
        void Add(ReviewClient reviewClient);

        IEnumerable<ReviewClient> Get();
    }
}