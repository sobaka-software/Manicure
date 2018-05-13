using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using Manicure.BusinessLogic.Services.Abstract;
using Manicure.Common.General;
using Newtonsoft.Json;

namespace Manicure.BusinessLogic.Services.Concrete
{
    public class ArticleService : IArticleService
    {
        public IEnumerable<Article> Get()
        {
            IEnumerable<Article> articles;

            CheckFile();

            using (var sr = new StreamReader(HostingEnvironment.ApplicationPhysicalPath + "\\Data\\article.json"))
            {
                var json = sr.ReadToEnd();
                articles = JsonConvert.DeserializeObject<IEnumerable<Article>>(json);
            }

            return articles ?? new List<Article>();
        }

        public void Add(Article article)
        {
            var articles = Get().ToList();
            article.Id = Guid.NewGuid();

            articles.Add(article);

            WriteToFile(articles);
        }

        public void Update(Article article)
        {
            if (article.Id == Guid.Empty)
            {
                Add(article);
            }
            else
            {
                var articles = Get().ToList();
                var articleToUpdate = articles.FirstOrDefault(a => a.Id == article.Id);
                var articleNum = articles.IndexOf(articleToUpdate);

                articles[articleNum] = article;

                WriteToFile(articles);
            }
        }

        public void Delete(Guid id)
        {
            var articles = Get().ToList();
            var articleNum = articles.FindIndex(a => a.Id == id);

            articles.RemoveAt(articleNum);

            WriteToFile(articles);
        }

        private void CheckFile()
        {
            if (!File.Exists(HostingEnvironment.ApplicationPhysicalPath + "\\Data\\article.json"))
            {
                var file = File.Create(HostingEnvironment.ApplicationPhysicalPath + "\\Data\\article.json");
                file.Close();
            }
        }

        private void WriteToFile(IEnumerable<Article> articles)
        {
            using (var sr = new StreamWriter(HostingEnvironment.ApplicationPhysicalPath + "\\Data\\article.json"))
            {
                var json = JsonConvert.SerializeObject(articles);
                sr.Write(json);
            }
        }
    }
}