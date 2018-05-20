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
    public class ClientServiceTests
    {
        private Mock<IRepository<Client>> _clientRepositoryMock;
        private Mock<IRepository<User>> _userRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private IClientService _sut;

        [TestInitialize]
        public void Init()
        {
            _clientRepositoryMock = new Mock<IRepository<Client>>();
            _userRepositoryMock = new Mock<IRepository<User>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [TestMethod]
        public void Add_CorrectClient_CallsCreateAndSave()
        {
            _userRepositoryMock.Setup(m => m.GetFirst(It.IsAny<Expression<Func<User, bool>>>())).Returns(new User
            {
                UserId = 1,
                Login = "test",
                Password = "test"
            });
            _sut = new ClientService(_clientRepositoryMock.Object, _userRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.Add(new Client(), "test");

            _clientRepositoryMock.Verify(m => m.Create(It.IsAny<Client>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
