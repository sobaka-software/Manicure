using System.Collections.Generic;
using System.Web.Mvc;
using AutoMapper;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("course")]
    public class CourseController : Controller
    {
        private readonly ICourseService _courseService;
        private readonly IUserService _userService;

        public CourseController(ICourseService courseService, IUserService userService)
        {
            _courseService = courseService;
            _userService = userService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            var courses = _courseService.Get();

            var coursesToShow = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courses);

            return View(coursesToShow);
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Master")]
        public ActionResult Add(CourseViewModel course)
        {
            var courseToAdd = Mapper.Map<CourseViewModel, Course>(course);

            var user = _userService.GetCurrent(User.Identity.Name);

            courseToAdd.MasterId = user.Master.MasterId;

            _courseService.Add(courseToAdd);

            return RedirectToAction("Get", "Course");
        }

        [HttpGet]
        [Route("delete")]
        public ActionResult Delete(int id)
        {
            _courseService.Delete(id);

            return RedirectToAction("UserProfile", "User");
        }

        [HttpGet]
        [Route("master/delete")]
        [Authorize(Roles = "Master")]
        public ActionResult DeleteCourse(int id)
        {
            _courseService.CourseDelete(id);

            return RedirectToAction("Get", "Course");
        }

        [HttpGet]
        [Route("request")]
        public ActionResult RequestCourse(int id)
        {
            var user = _userService.GetCurrent(User.Identity.Name);

            var course = new CourseEntry
            {
                ClientId = user.Client.ClientId,
                CourseId = id,
            };

            _courseService.RequestCourse(course);

            return RedirectToAction("UserProfile", "User");
        }
    }
}