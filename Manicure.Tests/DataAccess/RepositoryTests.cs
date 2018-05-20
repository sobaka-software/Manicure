using System.Data.Entity;
using System.Linq;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;
using Manicure.DataAccess.Concrete;
using Manicure.DataAccess.Context;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Manicure.Tests.DataAccess
{
    [TestClass]
    public class RepositoryTests
    {
        private const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ManicureTest;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        private DbContext _context;
        private DbSet<User> _dbSet;
        private IRepository<User> _sut;

        [TestInitialize]
        public void SetUp()
        {
            _context = new ManicureContext(ConnectionString);
            _dbSet = _context.Set<User>();
            for (var i = 1; i < 6; i++)
            {
                _dbSet.Add(new User { UserId = i });
            }
            _context.SaveChanges();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _context.Database.Delete();
        }

        [TestMethod]
        public void Create_CorrectUser_RecordsCount7()
        {
            _sut = new Repository<User>(_context);

            _sut.Create(new User());
            _context.SaveChanges();

            Assert.AreEqual(7, _dbSet.Count());
        }

        [TestMethod]
        public void Delete_CorrectId_RecordsCount5()
        {
            _sut = new Repository<User>(_context);

            _sut.Delete(1);
            _context.SaveChanges();

            Assert.AreEqual(5, _dbSet.Count());
        }

        [TestMethod]
        public void Any_CorrectId_ReturnsTrue()
        {
            _sut = new Repository<User>(_context);

            var result = _sut.Any(t => t.UserId == 1);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Where_RangeOfIdFrom1To3_RecordsCount3()
        {
            _sut = new Repository<User>(_context);

            var result = _sut.Get(t => t.UserId > 0 && t.UserId < 4);

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetFirst_Id1_ReturnsNotNull()
        {
            _sut = new Repository<User>(_context);

            var result = _sut.GetFirst(t => t.UserId == 1);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Update_CorrectUser_NameDifferent()
        {
            _sut = new Repository<User>(_context);
            var firstRecord = _dbSet.FirstOrDefault();
            var firstRecordName = _dbSet.FirstOrDefault().FirstName;

            firstRecord.FirstName = "test";

            _sut.Update(firstRecord);
            _context.SaveChanges();

            var updatedFirstRecord = _dbSet.FirstOrDefault();

            Assert.AreNotEqual(firstRecordName, updatedFirstRecord.FirstName);
        }

        [TestMethod]
        public void GetAll_RecordsCount6()
        {
            _sut = new Repository<User>(_context);

            var result = _sut.GetAll();

            Assert.AreEqual(6, result.Count());
        }
    }
}
