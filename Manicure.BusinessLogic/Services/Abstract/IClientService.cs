using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IClientService
    {
        void Add(Client client, string userLogin);
    }
}