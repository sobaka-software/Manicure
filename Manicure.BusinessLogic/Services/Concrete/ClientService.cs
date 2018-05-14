using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class ClientService : IClientService
    {
        private readonly IRepository<Client> _clientRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ClientService(
            IRepository<Client> clientRepository, 
            IRepository<User> userRepository, 
            IUnitOfWork unitOfWork)
        {
            _clientRepository = clientRepository;
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public void Add(Client client, string userLogin)
        {
            var user = _userRepository.GetFirst(u => u.Login == userLogin);

            client.User = user;

            _clientRepository.Create(client);
            _unitOfWork.SaveChanges();
        }
    }
}