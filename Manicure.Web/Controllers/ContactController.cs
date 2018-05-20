using System.Web.Mvc;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.General;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("contact")]
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        [Route("")]
        public ActionResult Get()
        {
            var contact = _contactService.Get();

            return View(contact);
        }

        [HttpPost]
        [Route("update")]
        [Authorize(Roles = "Administrator")]
        public ActionResult Update(Contact contact)
        {
            _contactService.Update(contact);

            return RedirectToAction("Get");
        }
    }
}