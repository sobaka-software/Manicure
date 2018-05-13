using System.Collections.Generic;
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
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            var reviews = _reviewService.Get();

            var allReviews = Mapper.Map<IEnumerable<ReviewClient>, IEnumerable<ReviewViewModel>>(reviews);

            return View(allReviews);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(ReviewViewModel userReview)
        {
            var reviewEntity = Mapper.Map<ReviewViewModel, ReviewClient>(userReview);

            _reviewService.Add(reviewEntity);

            return RedirectToAction("Get");
        }

        [HttpGet]
        [Route("remove")]
        public ActionResult Remove(int id)
        {
            _reviewService.Delete(id);

            return RedirectToAction("Get");
        }
    }
}