using System;
using System.Linq.Expressions;
using Manicure.BusinessLogic.Dtos;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.BusinessLogic.Services.Concrete;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;
using Manicure.DataAccess.Concrete;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Manicure.Tests.BusinessLogic
{
    [TestClass]
    public class ReviewClientServiceTests
    {
        private Mock<IRepository<ReviewClient>> _reviewClientRepositoryMock;
        private Mock<IRepository<User>> _userRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private IReviewClientService _sut;

        [TestInitialize]
        public void Init()
        {
            _reviewClientRepositoryMock = new Mock<IRepository<ReviewClient>>();
            _userRepositoryMock = new Mock<IRepository<User>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [TestMethod]
        public void Add_CorrectReview_CallsCreateAndSave()
        {
            _userRepositoryMock.Setup(m => m.GetFirst(It.IsAny<Expression<Func<User, bool>>>())).Returns(new User
            {
                UserId = 1
            });
            _sut = new ReviewClientService(_reviewClientRepositoryMock.Object, _unitOfWorkMock.Object, _userRepositoryMock.Object);

            _sut.Add(new ReviewClient(), "test");

            _reviewClientRepositoryMock.Verify(m => m.Create(It.IsAny<ReviewClient>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Get_CallsGetAll()
        {
            _sut = new ReviewClientService(_reviewClientRepositoryMock.Object, _unitOfWorkMock.Object, _userRepositoryMock.Object);

            _sut.Get();

            _reviewClientRepositoryMock.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void Delete_CorrectId_CallsDeleteAndSave()
        {
            _sut = new ReviewClientService(_reviewClientRepositoryMock.Object, _unitOfWorkMock.Object, _userRepositoryMock.Object);

            _sut.Delete(int.MaxValue);

            _reviewClientRepositoryMock.Verify(m => m.Delete(It.IsAny<int>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
