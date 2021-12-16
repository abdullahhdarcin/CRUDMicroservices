using CRUD.Services.Employee.Dtos;
using CRUD.Services.Employee.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services.Employee.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        protected ResponseDto _response;
        private IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            this._response = new ResponseDto();
        }


       [HttpGet]
       public async Task<object> Get()
        {
            try
            {
                IEnumerable<EmployeeDto> employeeDtos = await _employeeRepository.GetEmployees();
                _response.Result = employeeDtos;
            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
                
            }

            _response.DisplayMessage = "Request Success - All Employees Listed";

            return _response;
        }

        [HttpGet]
        [Route("{Id}")]
        public async Task<object> GetId(int Id)
        {
            try
            {
                EmployeeDto employeeDto = await _employeeRepository.GetEmployeeById(Id);
                _response.Result = employeeDto;
            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            _response.DisplayMessage = "Employee with " + Id + " ID's Listed";

            return _response;
        }


        [HttpPost]
        public async Task<object> Post( EmployeeDto employeeDto)
        {
            try
            {
                EmployeeDto model = await _employeeRepository.CreateEmployee(employeeDto);
                _response.Result = model;
            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            _response.DisplayMessage = "Employee Created";

            return _response;
        }

        [HttpPut]
        public async Task<object> Put(EmployeeDto employeeDto)
        {
            try
            {
                EmployeeDto model = await _employeeRepository.UpdateEmployee(employeeDto);
                _response.Result = model;
            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            _response.DisplayMessage = "Employee Updated";

            return _response;
        }

        [HttpDelete]
        public async Task<object> Delete(int Id)
        {
            try
            {
                bool isSuccess = await _employeeRepository.DeleteEmployee(Id);
                _response.Result = isSuccess;
            }
            catch (Exception e)
            {

                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { e.ToString() };
            }

            _response.DisplayMessage = "Employee Deleted";

            return _response;
        }

    }
}
