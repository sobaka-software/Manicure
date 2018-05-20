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
    public class CourseServiceTests
    {
        private Mock<IRepository<Course>> _courseRepositoryMock;
        private Mock<IRepository<CourseEntry>> _courseEntryRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private ICourseService _sut;

        [TestInitialize]
        public void Init()
        {
            _courseRepositoryMock = new Mock<IRepository<Course>>();
            _courseEntryRepositoryMock = new Mock<IRepository<CourseEntry>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [TestMethod]
        public void Add_CorrectCourse_CallsCreateAndSave()
        {
            _sut = new CourseService(_courseRepositoryMock.Object, _unitOfWorkMock.Object, _courseEntryRepositoryMock.Object);

            _sut.Add(new Course());

            _courseRepositoryMock.Verify(m => m.Create(It.IsAny<Course>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Delete_CorrectId_CallsDeleteAndSave()
        {
            _courseEntryRepositoryMock.Setup(m => m.GetFirst(It.IsAny<Expression<Func<CourseEntry, bool>>>())).Returns(new CourseEntry
            {
                CourseId = 1,
                ClientId = 1
            });
            _sut = new CourseService(_courseRepositoryMock.Object, _unitOfWorkMock.Object, _courseEntryRepositoryMock.Object);

            _sut.Delete(int.MaxValue);

            _courseEntryRepositoryMock.Verify(m => m.Delete(It.IsAny<CourseEntry>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void Get_CallsGetAll()
        {
            _sut = new CourseService(_courseRepositoryMock.Object, _unitOfWorkMock.Object, _courseEntryRepositoryMock.Object);

            _sut.Get();

            _courseRepositoryMock.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void RequestCourse_CorrectCourseEntry_CallsCreateAndSave()
        {
            _courseRepositoryMock.Setup(m => m.GetFirst(It.IsAny<Expression<Func<Course, bool>>>())).Returns(new Course
            {
                CourseId = 1
            });
            _sut = new CourseService(_courseRepositoryMock.Object, _unitOfWorkMock.Object, _courseEntryRepositoryMock.Object);

            _sut.RequestCourse(new CourseEntry());

            _courseEntryRepositoryMock.Verify(m => m.Create(It.IsAny<CourseEntry>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void CourseDelete_CorrectId_CallsDeleteAndSave()
        {
            _sut = new CourseService(_courseRepositoryMock.Object, _unitOfWorkMock.Object, _courseEntryRepositoryMock.Object);

            _sut.CourseDelete(int.MaxValue);

            _courseRepositoryMock.Verify(m => m.Delete(It.IsAny<int>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
