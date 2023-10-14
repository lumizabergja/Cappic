
using Cappic.DataAccess.Repository.IRepository;
using Cappic.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cappic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LensController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public LensController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Lens> objCategoryList = _unitOfWork.Lens.GetAll().ToList();
            return View(objCategoryList);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Lens obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Lens.Add(obj);
                _unitOfWork.Save();
                TempData["success"] = "Lens created successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Lens? lensFromDb = _unitOfWork.Lens.Get(u => u.Id == id);

            if (lensFromDb == null)
            {
                return NotFound();
            }
            return View(lensFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Lens obj)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Lens.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Lens updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Lens? lensFromDb = _unitOfWork.Lens.Get(u => u.Id == id);

            if (lensFromDb == null)
            {
                return NotFound();
            }
            return View(lensFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Lens? obj = _unitOfWork.Lens.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            _unitOfWork.Lens.Remove(obj);
            _unitOfWork.Save();
            TempData["success"] = "Lens deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
