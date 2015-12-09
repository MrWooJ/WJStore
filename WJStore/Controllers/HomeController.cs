using System.Web.Mvc;
using WJStore.Application.Interfaces;

namespace WJStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductAppService _productAppService;
        public HomeController(IProductAppService productAppService)
        {
            _productAppService = productAppService;
        }

        public ActionResult Index()
        {
            // Get most popular products
            var products = _productAppService.GetTopSellingProducts(5);

            return View(products);
        }
    }
}