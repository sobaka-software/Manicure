using System.Collections.Generic;
using Manicure.Common.Domain;

namespace Manicure.BusinessLogic.Services.Abstract
{
    public interface ICourseService
    {
        void Add(Course course);

        void Delete(int id);

        IEnumerable<Course> Get();

        void RequestCourse(CourseEntry course);

        void CourseDelete(int id);
    }
}