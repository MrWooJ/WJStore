using System.Linq;
using System.Web.Mvc;
using WJStore.Application.Interfaces;
using WJStore.Domain.Entities;

namespace WJStore.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StoreManagerController : Controller
    {
        private readonly IProductAppService _productAppService;
        private readonly IOwnerAppService _ownerAppService;
        private readonly ICategoryAppService _categoryAppService;

        public StoreManagerController(IProductAppService productAppService, IOwnerAppService ownerAppService, ICategoryAppService categoryAppService)
        {
            _productAppService = productAppService;
            _ownerAppService = ownerAppService;
            _categoryAppService = categoryAppService;
        }

        //
        // GET: /StoreManager/

        public ViewResult Index()
        {
            var products = _productAppService.All();
            return View(products.ToList());
        }

        //
        // GET: /StoreManager/Details/5

        public ViewResult Details(int id)
        {
            var product = _productAppService.Get(id, @readonly: true);
            return View(product);
        }

        //
        // GET: /StoreManager/Create

        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(_categoryAppService.All(@readonly: true), "CategoryId", "Name");
            ViewBag.OwnerId = new SelectList(_ownerAppService.All(@readonly: true), "OwnerId", "Name");
            return View();
        } 

        //
        // POST: /StoreManager/Create

        [HttpPost]
        public ActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                var validationResult = _productAppService.Create(product);
                
                if (validationResult.IsValid) 
                    return RedirectToAction("Index");
                
                foreach (var error in validationResult.Errors)
                    ModelState.AddModelError("", error.Message);
            }

            ViewBag.CategoryId = new SelectList(_categoryAppService.All(@readonly: true), "CategoryId", "Name", product.CategoryId);
            ViewBag.OwnerId = new SelectList(_ownerAppService.All(@readonly: true), "OwnerId", "Name", product.OwnerId);
            return View(product);
        }
        
        //
        // GET: /StoreManager/Edit/5
 
        public ActionResult Edit(int id)
        {
            var product = _productAppService.Get(id, @readonly: true);
            ViewBag.CategoryId = new SelectList(_categoryAppService.All(@readonly: true), "CategoryId", "Name", product.CategoryId);
            ViewBag.OwnerId = new SelectList(_ownerAppService.All(@readonly: true), "OwnerId", "Name", product.OwnerId);
            return View(product);
        }

        //
        // POST: /StoreManager/Edit/5

        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var validationResult = _productAppService.Update(product);

                if (validationResult.IsValid)
                    return RedirectToAction("Index");

                foreach (var error in validationResult.Errors)
                    ModelState.AddModelError("", error.Message);

                return View(product);
            }
            ViewBag.CategoryId = new SelectList(_categoryAppService.All(@readonly: true), "CategoryId", "Name", product.CategoryId);
            ViewBag.OwnerId = new SelectList(_ownerAppService.All(@readonly: true), "OwnerId", "Name", product.OwnerId);
            return View(product);
        }

        //
        // GET: /StoreManager/Delete/5
 
        public ActionResult Delete(int id)
        {
            var product = _productAppService.Get(id, @readonly: true);
            return View(product);
        }

        //
        // POST: /StoreManager/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            var product = _productAppService.Get(id);
            _productAppService.Remove(product);

            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            _productAppService.Dispose();
            _ownerAppService.Dispose();
            _categoryAppService.Dispose();

            base.Dispose(disposing);
        }
    }
}