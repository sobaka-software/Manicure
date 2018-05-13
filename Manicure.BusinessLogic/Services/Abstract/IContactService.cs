using Manicure.Common.General;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface IContactService
    {
        Contact Get();

        void Update(Contact contact);
    }
}