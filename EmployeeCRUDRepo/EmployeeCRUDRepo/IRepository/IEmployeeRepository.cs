using EmployeeCRUDRepo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDRepo.IRepository
{
    public interface IEmployeeRepository 
    {
        public List<Employee> GetEmployees();

        public Employee GetEmployeeModelByEmployeeId(int empId);

        public bool InsertEmployeeIntoDatabase(Employee employee);


        public void UpdateEmployeeIntoDatabase(Employee employee);

        public void RemoveEmploye(Employee employee);


    }
}
