﻿using System.Collections.Generic;
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
            var reviews = _reviewClientService.Get();

            var allReviews = Mapper.Map<IEnumerable<ReviewClient>, IEnumerable<ReviewViewModel>>(reviews);

            return View(allReviews);
        }

        [HttpPost]
        [Route("add")]
        public ActionResult Add(ReviewViewModel userReview)
        {
            var reviewEntity = Mapper.Map<ReviewViewModel, ReviewClient>(userReview);

            _reviewClientService.Add(reviewEntity);

            return RedirectToAction("Get");
        }
    }
}