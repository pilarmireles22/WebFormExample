using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebFormCrud.Repository;
using WebFormCrud.Model;
using System.Data;
namespace WebFormCrud.Service
{
    public class EmployeeService
    {
        private EmployeeRepository _repository;
      public  EmployeeService()
        {
            _repository = new EmployeeRepository();
            
        }
        public void CreateOrUpdateEmployee(Employee employee)
        {
            _repository.CreateOrUpdateEmployee(employee);
        }
        public void DeleteEmployeeByID( int employeeID)
        {
            _repository.DeleteEmployeeByID(employeeID);
        }
        public Employee GetEmployeeByID(int employeeID)
        {
            return _repository.GetEmployeeByID(employeeID);
        }
        public DataTable GetAllEmployees()
        {
            return _repository.GetAllEmployees();
        }
    }
}