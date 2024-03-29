﻿using DotnetList5Task2.Models.Shop;
using DotnetList5Task2.Models.Shop.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Xml.Linq;

namespace DotnetList5Task2.Controllers
{
    public class ArticlesController(IArticleRepository articleRepository) : Controller
    {
        private readonly IArticleRepository _articleRepository = articleRepository;

        // GET: ArticlesController
        public ActionResult Index()
        {
            var allArticles = _articleRepository.GetAll();
            var pricesSum = allArticles.Sum(art => art.Price);
            return View(new ArticlesList() { Articles = allArticles, PricesSum = pricesSum});
        }

        // GET: ArticlesController/Details/5
        public ActionResult Details(Guid id)
        {
            return View(_articleRepository.GetById(id));
        }

        // GET: ArticlesController/Create
        public ActionResult Create()
        {
            return View(new Article());
        }

        // POST: ArticlesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            Article article = new Article
            {
                Id = Guid.NewGuid(),
                Name = collection["Name"],
                Price = Convert.ToDecimal(collection["Price"]),
                ExpiryDate = DateOnly.Parse(collection["ExpiryDate"]),
                Categories = collection["Categories"]
            };
            _articleRepository.AddArticle(article);
            return RedirectToAction(nameof(Index));
        }

        // GET: ArticlesController/Edit/5
        public ActionResult Edit(Guid id)
        {
            return View(_articleRepository.GetById(id));
        }

        // POST: ArticlesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Guid id, IFormCollection collection)
        {
            Article article = new Article
            {
                Id = id,
                Name = collection["Name"],
                Price = Convert.ToDecimal(collection["Price"]),
                ExpiryDate = DateOnly.Parse(collection["ExpiryDate"]),
                Categories = collection["Categories"]
            };
            _articleRepository.UpdateArticle(article);
            return RedirectToAction(nameof(Details), new { id });
        }

        // GET: ArticlesController/Delete/5
        public ActionResult Delete(Guid id)
        {
            return View(_articleRepository.GetById(id));
        }

        // POST: ArticlesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(Guid id, IFormCollection collection)
        {
            _articleRepository.DeleteArticle(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
