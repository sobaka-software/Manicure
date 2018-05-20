using System.IO;
using System.Web;
using Manicure.BusinessLogic.Authentication;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Auth;
using Manicure.Common.Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Manicure.Tests.BusinessLogic
{
    [TestClass]
    public class AuthProviderTests
    {
        private HttpRequest _httpRequest;
        private StringWriter _stringWriter;
        private HttpResponse _httpResponse;
        private HttpContext _httpContext;
        private Mock<IUserService> _userServiceMock;
        private IAuthProvider _sut;

        [TestInitialize]
        public void Init()
        {
            _httpRequest = new HttpRequest("", "http://testauth", "");
            _stringWriter = new StringWriter();
            _httpResponse = new HttpResponse(_stringWriter);
            _httpContext = new HttpContext(_httpRequest, _httpResponse);
            HttpContext.Current = _httpContext;
            _userServiceMock = new Mock<IUserService>();
            _userServiceMock.Setup(x => x.GetBy(It.IsAny<string>(),
                    It.IsAny<string>()))
                .Returns(new User
                {
                    UserId = 1,
                    Login = "test",
                    Password = "test",
                    Role = "Client"
                });
        }

        [TestMethod]
        public void Authenticate_CorrectUser_ReturnsUser()
        {
            _sut = new AuthProvider(_userServiceMock.Object);

            var result = _sut.Authenticate(new Login());

            Assert.AreEqual("test", result.Login);
            Assert.AreEqual("test", result.Password);
        }
    }
}
