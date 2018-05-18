using System.Collections.Generic;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.DataAccess.Abstract;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> _courseRepository;
        private readonly IRepository<CourseEntry> _courseEntryRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(
            IRepository<Course> courseRepository,
            IUnitOfWork unitOfWork,
            IRepository<CourseEntry> courseEntryRepository)
        {
            _courseRepository = courseRepository;
            _unitOfWork = unitOfWork;
            _courseEntryRepository = courseEntryRepository;
        }

        public void Add(Course course)
        {
            _courseRepository.Create(course);
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id)
        {
            var courseEntry = _courseEntryRepository.GetFirst(c => c.CourseId == id);

            _courseEntryRepository.Delete(courseEntry);
            _unitOfWork.SaveChanges();
        }

        public IEnumerable<Course> Get()
        {
            return _courseRepository.GetAll();
        }

        public void RequestCourse(CourseEntry course)
        {
            var courseToRequest = _courseRepository.GetFirst(c => c.CourseId == course.CourseId);

            course.IsPaid = courseToRequest.Cost > 0;

            _courseEntryRepository.Create(course);
            _unitOfWork.SaveChanges();
        }

        public void CourseDelete(int id)
        {
            _courseRepository.Delete(id: id);
            _unitOfWork.SaveChanges();
        }
    }
}