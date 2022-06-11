using EmployeeCRUDRepo.IRepository;
using EmployeeCRUDRepo.IService;
using EmployeeCRUDRepo.Repository;
using EmployeeCRUDRepo.Service;
using EmployeeCRUDRepo.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDRepo.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService) => _employeeService = employeeService;
        public IActionResult Index()
        {
            return View(_employeeService.GetEmployeeModels());
        }

        public IActionResult AddOrEdit(int id)
        {
            if (id == 0)
            {
                return View(new EmployeeModel());
            }
            else
            {
                var employeeModel = _employeeService.GetEmployeeModelByEmployeeId(id);
                return View(employeeModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddOrEdit([Bind("Id", "EmployeeId", "EmployeeName", "Designation", "Department")] EmployeeModel employeeModel)
        {
            if (ModelState.IsValid)
            {
                if (employeeModel.Id == 0)
                {
                    _employeeService.InsertEmployee(employeeModel);
                }
                else
                {
                    _employeeService.UpdateEmployeeModel(employeeModel);
                }
            }
            return RedirectToAction("Index", "Employee");
        }
        public IActionResult Delete(int id)
        {
            _employeeService.RemoveEmploye(id);
            return RedirectToAction("Index", "Employee");
        }
    }
}
