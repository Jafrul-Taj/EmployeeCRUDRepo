using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCRUDRepo.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public string Designation { get; set; }

        public string Department { get; set; }
    }
}
