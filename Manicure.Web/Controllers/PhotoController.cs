using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using AutoMapper;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.Domain;
using Manicure.Web.Models;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("photo")]
    public class PhotoController : Controller
    {
        private readonly IUserService _userService;
        private readonly IPhotoService _photoService;

        public PhotoController(IUserService userService, IPhotoService photoService)
        {
            _userService = userService;
            _photoService = photoService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            var photos = _photoService.Get();

            var photosToShow = Mapper.Map<IEnumerable<ExampleWork>, IEnumerable<GalleryViewModel>>(photos);

            return View(photosToShow);
        }

        [HttpPost]
        [Route("diploma/add")]
        public ActionResult AddDiploma(DiplomaViewModel diploma)
        {
            var user = _userService.GetCurrent(User.Identity.Name);

            foreach (var photo in diploma.Photos)
            {
                var diplomaToAdd = new Diploma
                {
                    MasterId = user.Master.MasterId
                };

                using (var binaryReader = new BinaryReader(photo.InputStream))
                {
                    diplomaToAdd.ScanDiploma = binaryReader.ReadBytes(photo.ContentLength);
                }

                _photoService.AddDiploma(diplomaToAdd);
            }

            return RedirectToAction("UserProfile", "User");
        }

        [HttpPost]
        [Route("example-work/add")]
        public ActionResult AddExampleWork(ExampleWorkViewModel exampleWork)
        {
            var user = _userService.GetCurrent(User.Identity.Name);

            var exampleWorkToAdd = Mapper.Map<ExampleWorkViewModel, ExampleWork>(exampleWork);

            exampleWorkToAdd.MasterId = user.Master.MasterId;

            using (var binaryReader = new BinaryReader(exampleWork.Photo.InputStream))
            {
                exampleWorkToAdd.Photo = binaryReader.ReadBytes(exampleWork.Photo.ContentLength);
            }

            _photoService.AddExampleWork(exampleWorkToAdd);

            return RedirectToAction("UserProfile", "User");
        }

        [HttpGet]
        [Route("example-work/delete")]
        public ActionResult DeleteExampleWork(int id)
        {
            _photoService.DeleteExampleWork(id);

            return RedirectToAction("UserProfile", "User");
        }

        [HttpGet]
        [Route("diploma/delete")]
        public ActionResult DeleteDiploma(int id)
        {
            _photoService.DeleteDiploma(id);

            return RedirectToAction("UserProfile", "User");
        }
    }
}