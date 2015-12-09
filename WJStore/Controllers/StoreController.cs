using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WJStore.Application.Interfaces;
using WJStore.Models;

namespace WJStore.Controllers
{
    public class StoreController : Controller
    {
        private readonly ICategoryAppService _categoryAppService;
        private readonly IProductAppService _productAppService;

        public StoreController(ICategoryAppService categoryAppService, IProductAppService productAppService)
        {
            _categoryAppService = categoryAppService;
            _productAppService = productAppService;
        }

        //
        // GET: /Store/

        public ActionResult Index()
        {
            var categories = _categoryAppService.All(@readonly: true);

            return View(categories);
        }

        //
        // GET: /Store/Browse?category=Disco

        public ActionResult Browse(string category)
        {
            // Retrieve Category and its Associated Products from database
            var categoryModel = _categoryAppService.GetWithProducts(category);

            return View(categoryModel);
        }

        //
        // GET: /Store/Details/5

        public ActionResult Details(int id)
        {
            var product = _productAppService.Get(id, @readonly: true);

            return View(product);
        }

        //
        // GET: /Store/CategoryMenu

        [ChildActionOnly]
        public ActionResult CategoryMenu()
        {
            var categories = _categoryAppService.All(@readonly: true);

            return PartialView(categories);
        }

    }
}