using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("review")]
    public class ReviewController : Controller
    {
        private readonly IReviewClientService _reviewClientService;

        public ReviewController(IReviewClientService reviewClientService)
        {
            _reviewClientService = reviewClientService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            var reviews = _reviewClientService.Get().ToList();

            var allReviews = Mapper.Map<IEnumerable<ReviewClient>, IEnumerable<ReviewViewModel>>(reviews);

            return View(allReviews);
        }

        [HttpPost]
        [Route("add")]
        [Authorize(Roles = "Client")]
        public ActionResult Add(ReviewViewModel userReview)
        {
            var reviewEntity = Mapper.Map<ReviewViewModel, ReviewClient>(userReview);

            _reviewClientService.Add(reviewEntity, User.Identity.Name);

            return RedirectToAction("Get");
        }

        [HttpGet]
        [Route("delete")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Delete(int id)
        {
            _reviewClientService.Delete(id);

            return RedirectToAction("Get");
        }
    }
}