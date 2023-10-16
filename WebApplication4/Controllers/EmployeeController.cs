using AutoMapper;
using BLL.interfaces;
using DAL.Migrations;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Helpers;
using WebApplication4.ViewModels;

namespace WebApplication4.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public EmployeeController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IActionResult> Index(string searchValue)
        {
            IEnumerable<Empolyee> Empolyee;
            if (string.IsNullOrEmpty(searchValue))
            {
                Empolyee = await unitOfWork.employeeRepo.GetALL();
                await unitOfWork.complete();
            }
            else
            {
                Empolyee = unitOfWork.employeeRepo.getitemByName(searchValue);
                await unitOfWork.complete();
            }
            var mapperEmployee = mapper.Map<IEnumerable<Empolyee>, IEnumerable<EmployeeVM>>(Empolyee);

            return View(mapperEmployee);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Departments = await unitOfWork.departmentRepo.GetALL();
            await unitOfWork.complete();

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeVM EmpolyeeVM)
        {
            if (ModelState.IsValid)
            {
                EmpolyeeVM.ImageName = DocumentSettings.UploadFile(EmpolyeeVM.Image, "Images");
                var mapperEmployee = mapper.Map<EmployeeVM, Empolyee>(EmpolyeeVM);
                await unitOfWork.employeeRepo.AddT(mapperEmployee);
                await unitOfWork.complete();

                TempData["Message"] = "Empolyee Is Created";
                return RedirectToAction("Index");
            }
            return View(EmpolyeeVM);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id is null)
                return BadRequest();
            var dept = await unitOfWork.employeeRepo.TGetByID(id.Value);
            await unitOfWork.complete();

            if (dept is null)
                return NotFound();
            var mapperEmployee = mapper.Map<Empolyee, EmployeeVM>(dept);
            await unitOfWork.complete();

            return View(dept);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Departments = await unitOfWork.departmentRepo.GetALL();

            if (id is null)
                return BadRequest();
            var dept = await unitOfWork.employeeRepo.TGetByID(id.Value);
            await unitOfWork.complete();

            var mapperEmployee = mapper.Map<Empolyee, EmployeeVM>(dept);

            if (dept is null)
                return NotFound();

            return View(mapperEmployee);
        }

        [HttpPost]
        public IActionResult Edit(EmployeeVM EmpolyeeVM)
        {
            if (ModelState.IsValid)
            {
                if (EmpolyeeVM.Image != null)
                {
                    EmpolyeeVM.ImageName = DocumentSettings.UploadFile(EmpolyeeVM.Image, "Images");
                }
                var mapperEmployee = mapper.Map<EmployeeVM, Empolyee>(EmpolyeeVM);
                unitOfWork.employeeRepo.UpdateT(mapperEmployee);
                unitOfWork.complete();

                return RedirectToAction("Index");
            }
            return View(EmpolyeeVM);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null)
                return BadRequest();
            var dept = await unitOfWork.employeeRepo.TGetByID(id.Value);
            var mapperEmployee = mapper.Map<Empolyee, EmployeeVM>(dept);

            if (dept is null)
                return NotFound();
            return View(mapperEmployee);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(EmployeeVM EmpolyeeVM)
        {
            var mapperEmployee = mapper.Map<EmployeeVM, Empolyee>(EmpolyeeVM);

            unitOfWork.employeeRepo.DeleteT(mapperEmployee);
            var result = await unitOfWork.complete();
            if (result > 0 && EmpolyeeVM.ImageName is not null)
            {
                DocumentSettings.DeleteFile(EmpolyeeVM.ImageName, "Images");
            }

            return RedirectToAction("Index");
        }
    }
}