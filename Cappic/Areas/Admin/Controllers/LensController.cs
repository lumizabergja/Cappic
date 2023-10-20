
using Cappic.DataAccess.Repository.IRepository;
using Cappic.Models;
using Cappic.Models.ViewModels;
using Cappic.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Cappic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.AdminRole)]
    public class LensController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly IUnitOfWork _unitOfWork;
        public LensController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            _unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
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
        public IActionResult Create(Lens obj, IFormFile? file)
        {

            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\lens");
                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\images\lens\" + fileName;
                }
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
        public IActionResult Edit(Lens obj, IFormFile? file)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                    string productPath = Path.Combine(wwwRootPath, @"images\lens");

                    if (string.IsNullOrEmpty(obj.ImageUrl))
                    {
                        //Delete the old Image
                        var oldImagePath =
                            Path.Combine(wwwRootPath, obj.ImageUrl.TrimStart('\\'));

                        if (System.IO.File.Exists(oldImagePath))                                                                                 
                        {
                            System.IO.File.Delete(oldImagePath);
                        }
                    }

                    using (var fileStream = new FileStream(Path.Combine(productPath, fileName), FileMode.Create))
                    {
                        file.CopyTo(fileStream);
                    }
                    obj.ImageUrl = @"\images\lens\" + fileName;
                }
                _unitOfWork.Lens.Update(obj);
                _unitOfWork.Save();
                TempData["success"] = "Lens updated successfully";
                return RedirectToAction("Index");
            }
            return View();

        }

        public IActionResult Delete(int? id)
        {
            var lensToBeDeleted = _unitOfWork.Lens.Get(u => u.Id == id);
            if (lensToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            var oldImagePath =
                           Path.Combine(_webHostEnvironment.WebRootPath,
                           lensToBeDeleted.ImageUrl.TrimStart('\\'));

            if (System.IO.File.Exists(oldImagePath))
            {
                System.IO.File.Delete(oldImagePath);
            }

            _unitOfWork.Lens.Remove(lensToBeDeleted);
            _unitOfWork.Save();

            return Json(new { success = true, message = "Delete Successful" });
        }
        
        #region API CALLS

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Lens> objLensList = _unitOfWork.Lens.GetAll().ToList();
            return Json(new { data = objLensList });
        }

        #endregion
    }
}
