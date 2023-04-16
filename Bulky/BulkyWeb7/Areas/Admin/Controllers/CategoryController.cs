using BulkyBook.DataAccess7.Repository.IRepository;
using BulkyBook.Models7;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb7.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

		}


        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _unitOfWork.Category.GetAll();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category objCategory)
        {
            if (objCategory.Name == objCategory.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "Name and Display Order cannot be the same");
            }

            if (ModelState.IsValid)
            {
                _unitOfWork.Category.Add(objCategory);
				_unitOfWork.Save();
                TempData["success"] = "Category created succesfully";
                return RedirectToAction("Index");
            }
            return View(objCategory);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _unitOfWork.Category.Get(x => x.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category objCategory)
        {
            if (ModelState.IsValid)
            {
				_unitOfWork.Category.Update(objCategory);
				_unitOfWork.Save();
                TempData["success"] = "Category edited succesfully";
                return RedirectToAction("Index");
            }
            return View(objCategory);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _unitOfWork.Category.Get(x => x.Id == id);

            if (category == null)
                return NotFound();

            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? category = _unitOfWork.Category.Get(x => x.Id == id);

            if (category == null)
                return NotFound();

            _unitOfWork.Category.Remove(category);
			_unitOfWork.Save();
            TempData["success"] = "Category deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
