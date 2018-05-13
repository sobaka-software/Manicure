using System;
using System.Collections.Generic;
using Manicure.Common.General;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IArticleService
    {
        IEnumerable<Article> Get();

        void Add(Article article);

        void Update(Article article);

        void Delete(Guid id);
    }
}