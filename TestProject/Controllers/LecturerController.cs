using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolSystem.Data;
using SchoolSystem.Interfaces;
using SchoolSystem.Repository;
using SchoolSystem.ViewModel.Lecturers;

namespace SchoolSystem.Controllers
{
    public class LecturerController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILecturerRepository _lecturerRepository;

  

        public LecturerController(ApplicationDbContext context, ILecturerRepository lecturerRepository)
        {
            _context = context;
            _lecturerRepository = lecturerRepository;
        }
        // GET: LecturerController
        public async Task<IActionResult> Index(string created)
        {

            if (created != null)
            {
                ViewBag.created = "yes";
            }
            var Lecturers = await _lecturerRepository.GetAllLecturersAsync();
            return View(Lecturers);
        }



        [HttpGet]
        // GET: LecturerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LecturerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateLecturerVM model)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                   
                    await _lecturerRepository.CreateLecturerAsync(model);

                    return RedirectToAction(nameof(Index), new { created = "yes" });
                }
                return View();
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Details(int id)
        {


            var lecturer = await _lecturerRepository.GetLecturerByIdAsync(id);

            return View(lecturer);
        }


        // GET: LecturerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: LecturerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: LecturerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: LecturerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
