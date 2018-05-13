using System;
using System.Web.Mvc;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.General;

namespace Manicure.Web.Controllers
{
    [RoutePrefix("article")]
    public class ArticleController : Controller
    {
        private readonly IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = articleService;
        }

        [Route("")]
        public ActionResult Get()
        {
            var articles = _articleService.Get();

            return View(articles);
        }
        
        [Route("update")]
        public ActionResult Update(Article article)
        {
            _articleService.Update(article);

            return RedirectToAction("Get");
        }

        [Route("delete")]
        public ActionResult Delete(Guid id)
        {
            _articleService.Delete(id);

            return RedirectToAction("Get");
        }
    }
}