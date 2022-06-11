using EmployeeCRUDRepo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDRepo.IService
{
    public interface IEmployeeService 
    {
        public List<EmployeeModel> GetEmployeeModels();

        public EmployeeModel GetEmployeeModelByEmployeeId(int id);

        public void InsertEmployee(EmployeeModel employeeModel);

        public void UpdateEmployeeModel(EmployeeModel employeeModel);

        public void RemoveEmploye(int id);
    }
}
