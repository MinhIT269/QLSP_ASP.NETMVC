using ElectroMVC.Data;
using Microsoft.AspNetCore.Mvc;

namespace ElectroMVC.Controllers
{
	[ViewComponent(Name ="_Category")]
	public class _CategoryViewComponent :ViewComponent
	{
        private readonly ElectroMVCContext _context;

        public _CategoryViewComponent(ElectroMVCContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var _catergory = _context.Category.ToList();

            return View("_Category", _catergory);
        }
    }
}
