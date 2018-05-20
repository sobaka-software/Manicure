using System;
using System.Linq.Expressions;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.BusinessLogic.Services.Concrete;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Manicure.Tests.BusinessLogic
{
    [TestClass]
    public class UserServiceTests
    {
        private Mock<IRepository<User>> _userRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private IUserService _sut;

        [TestInitialize]
        public void Init()
        {
            _userRepositoryMock = new Mock<IRepository<User>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [TestMethod]
        public void Create_CorrectUser_CallsCreateAndSave()
        {
            _sut = new UserService(_userRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.Create(new User
            {
                Password = "test"
            });

            _userRepositoryMock.Verify(m => m.Create(It.IsAny<User>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Update_CorrectUser_CallsUpdateAndSave()
        {
            _sut = new UserService(_userRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.Update(new User());

            _userRepositoryMock.Verify(m => m.Update(It.IsAny<User>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void GetBy_CorrectloginAndPassword_CallsGetFirst()
        {
            _sut = new UserService(_userRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.GetBy("test", "test");

            _userRepositoryMock.Verify(m => m.GetFirst(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }

        [TestMethod]
        public void GetCurrent_Correctlogin_CallsGetFirst()
        {
            _sut = new UserService(_userRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.GetCurrent("test");

            _userRepositoryMock.Verify(m => m.GetFirst(It.IsAny<Expression<Func<User, bool>>>()), Times.Once);
        }
    }
}
