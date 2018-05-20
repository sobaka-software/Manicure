using Manicure.BusinessLogic.Services.Abstract;
using Manicure.BusinessLogic.Services.Concrete;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Manicure.Tests.BusinessLogic
{
    [TestClass]
    public class PhotoServiceTests
    {
        private Mock<IRepository<Diploma>> _diplomaRepositoryMock;
        private Mock<IRepository<ExampleWork>> _exampleWorkRepositoryMock;
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private IPhotoService _sut;

        [TestInitialize]
        public void Init()
        {
            _diplomaRepositoryMock = new Mock<IRepository<Diploma>>();
            _exampleWorkRepositoryMock = new Mock<IRepository<ExampleWork>>();
            _unitOfWorkMock = new Mock<IUnitOfWork>();
        }

        [TestMethod]
        public void Get_CallsGetAll()
        {
            _sut = new PhotoService(_exampleWorkRepositoryMock.Object, _diplomaRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.Get();

            _exampleWorkRepositoryMock.Verify(m => m.GetAll(), Times.Once);
        }

        [TestMethod]
        public void AddDiploma_CorrectDiploma_CallsCreateAndSave()
        {
            _sut = new PhotoService(_exampleWorkRepositoryMock.Object, _diplomaRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.AddDiploma(new Diploma());

            _diplomaRepositoryMock.Verify(m => m.Create(It.IsAny<Diploma>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void AddExampleWork_CorrectExample_CallsCreateAndSave()
        {
            _sut = new PhotoService(_exampleWorkRepositoryMock.Object, _diplomaRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.AddExampleWork(new ExampleWork());

            _exampleWorkRepositoryMock.Verify(m => m.Create(It.IsAny<ExampleWork>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DeleteDiploma_CorrectId_CallsDeleteAndSave()
        {
            _sut = new PhotoService(_exampleWorkRepositoryMock.Object, _diplomaRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.DeleteDiploma(int.MaxValue);

            _diplomaRepositoryMock.Verify(m => m.Delete(It.IsAny<int>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void DeleteExampleWork_CorrectId_CallsDeleteAndSave()
        {
            _sut = new PhotoService(_exampleWorkRepositoryMock.Object, _diplomaRepositoryMock.Object, _unitOfWorkMock.Object);

            _sut.DeleteExampleWork(int.MaxValue);

            _exampleWorkRepositoryMock.Verify(m => m.Delete(It.IsAny<int>()), Times.Once);
            _unitOfWorkMock.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
