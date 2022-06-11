using EmployeeCRUDRepo.Entities;
using EmployeeCRUDRepo.IRepository;
using EmployeeCRUDRepo.IService;
using EmployeeCRUDRepo.Repository;
using EmployeeCRUDRepo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDRepo.Service
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _repository;

        public EmployeeService(IEmployeeRepository repository)
        {
            _repository = repository;
        }
        public List<EmployeeModel> GetEmployeeModels()
        {

            var employees = _repository.GetEmployees();
            var employeeModels = new List<EmployeeModel>();
            foreach (var e in employees)
            {
                var emp = new EmployeeModel();
                emp.Id = e.Id;
                emp.EmployeeId = e.EmployeeId;
                emp.EmployeeName = e.EmployeeName;
                emp.Designation = e.Designation;
                emp.Department = e.Department;
                employeeModels.Add(emp);
            }
            return employeeModels;
        }

        public EmployeeModel GetEmployeeModelByEmployeeId(int id)
        {
            var e = _repository.GetEmployeeModelByEmployeeId(id);
            var emp = new EmployeeModel();
            emp.EmployeeId = e.EmployeeId;
            emp.EmployeeName = e.EmployeeName;
            emp.Designation = e.Designation;
            emp.Department = e.Department;
            return emp;
        }

        public void InsertEmployee(EmployeeModel e)
        {
            var emp = new Employee();
            emp.EmployeeId = e.EmployeeId;
            emp.EmployeeName = e.EmployeeName;
            emp.Designation = e.Designation;
            emp.Department = e.Department;
            _repository.InsertEmployeeIntoDatabase(emp);
            //throw new NotImplementedException();
        }
        public void UpdateEmployeeModel(EmployeeModel e)
        {
            var emp = _repository.GetEmployeeModelByEmployeeId(e.Id);
            emp.EmployeeId = e.EmployeeId;
            emp.EmployeeName = e.EmployeeName;
            emp.Designation = e.Designation;
            emp.Department = e.Department;
            _repository.UpdateEmployeeIntoDatabase(emp);
        }

        public void RemoveEmploye(int id)
        {
            var emp = _repository.GetEmployeeModelByEmployeeId(id);
            _repository.RemoveEmploye(emp);
        }
    }
}
