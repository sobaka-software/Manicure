using System.Collections.Generic;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserService(
            IRepository<User> userRepository, 
            IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _unitOfWork = unitOfWork;
        }

        public void Create(User user)
        {
            user.Password = user.Password.GetHashCode().ToString();
            _userRepository.Create(user);
            _unitOfWork.SaveChanges();
        }

        public void Update(User user)
        {
            _userRepository.Update(user);
            _unitOfWork.SaveChanges();
        }

        public User GetBy(string login, string password)
        {
            password = password.GetHashCode().ToString();

            return _userRepository.GetFirst(u => u.Login == login && u.Password == password);
        }

        public IEnumerable<User> GetBy(string role)
        {
            return _userRepository.Get(u => u.Role == role);
        }

        public User GetCurrent(string login)
        {
            return _userRepository.GetFirst(u => u.Login == login);
        }
    }
}