using CRUD.Services.Employee.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CRUD.Services.Employee.Repository
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeDto>> GetEmployees();

        Task<EmployeeDto> GetEmployeeById(int id);

        Task<EmployeeDto> CreateEmployee(EmployeeDto employee);

        Task<EmployeeDto> UpdateEmployee(EmployeeDto employee);

        Task<bool> DeleteEmployee(int id);


    }
}
