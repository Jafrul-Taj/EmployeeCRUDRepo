using EmployeeCRUDRepo.Entities;
using EmployeeCRUDRepo.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDRepo.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeContext _context;
        public EmployeeRepository(EmployeeContext context)
        {
            _context = context;
        }

        public Employee GetEmployeeModelByEmployeeId(int Id)
        {
            return _context.Employees.Where(ch => ch.Id == Id).FirstOrDefault<Employee>();
            //return _context.Employees.Find(EmployeeId);
            //throw new NotImplementedException();
        }

        public List<Employee> GetEmployees()
        {
            return _context.Employees.ToList<Employee>();
           
        }

        public bool InsertEmployeeIntoDatabase(Employee employee)
        {
            try
            {
                _context.Employees.Add(employee);
                _context.SaveChanges();
                return true;
            }catch(Exception e)
            {
                return false;
            }
        }

        public void UpdateEmployeeIntoDatabase(Employee employee)
        {
            _context.Update(employee);
            _context.SaveChanges();
        }

        public void RemoveEmploye(Employee employee)
        {
            _context.Remove(employee);
            _context.SaveChanges();
        }
    }
}
