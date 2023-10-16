using BLL.interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WebApplication4.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly IUnitOfWork unitOfWork;

        public DepartmentController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<IActionResult> Index()
        {
            var department = await unitOfWork.departmentRepo.GetALL();
            await unitOfWork.complete();

            return View(department);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Department department)
        {
            if (ModelState.IsValid)
            {
                await unitOfWork.departmentRepo.AddT(department);
                await unitOfWork.complete();

                return RedirectToAction("Index");
            }
            return View(department);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var dept = await unitOfWork.departmentRepo.TGetByID(id.Value);
            await unitOfWork.complete();

            if (dept is null)
                return NotFound();
            return View(dept);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id is null)
                return BadRequest();
            var dept = await unitOfWork.departmentRepo.TGetByID(id.Value);
            await unitOfWork.complete();

            if (dept is null)
                return NotFound();
            return View(dept);
        }

        [HttpPost]
        public IActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                unitOfWork.departmentRepo.UpdateT(department);
                unitOfWork.complete();

                return RedirectToAction("Index");
            }
            return View(department);
        }

        public IActionResult Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var dept = unitOfWork.departmentRepo.TGetByID(id.Value);
            unitOfWork.complete();

            if (dept is null)
                return NotFound();
            return View(dept);
        }

        [HttpPost]
        public IActionResult Delete(Department department)
        {
            unitOfWork.departmentRepo.DeleteT(department);
            unitOfWork.complete();

            return RedirectToAction("Index");
        }
    }
}