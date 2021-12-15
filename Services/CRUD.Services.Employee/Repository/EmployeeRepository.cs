using AutoMapper;
using CRUD.Services.Employee.Data;
using CRUD.Services.Employee.Dtos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD.Services.Employee.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {

        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public EmployeeRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<EmployeeDto> CreateEmployee(EmployeeDto employeeDto)
        {
            Models.Employee employee = _mapper.Map<EmployeeDto, Models.Employee>(employeeDto);


            if (employee.Id<1)
            {
                _db.Employees.Add(employee);
            }
            
            await _db.SaveChangesAsync();

            return _mapper.Map<Models.Employee,EmployeeDto>(employee);


        }

        public async Task<bool> DeleteEmployee(int Id)
        {
            try
            {
                Models.Employee employee = await _db.Employees.FirstOrDefaultAsync(x => x.Id == Id);

                if (employee == null)
                {
                    return false;
                }
                _db.Employees.Remove(employee);
               await _db.SaveChangesAsync();

                return true;


            }
            catch (Exception e)
            {

                return false;
            }
        }

        public async Task<EmployeeDto> GetEmployeeById(int Id)
        {
            Models.Employee employee = await _db.Employees.Where(x=>x.Id==Id).FirstOrDefaultAsync();

            return _mapper.Map<EmployeeDto>(employee);
        }

        public async Task<IEnumerable<EmployeeDto>> GetEmployees()
        {
            List<Models.Employee> employeeList = await _db.Employees.ToListAsync();

            return _mapper.Map<List<EmployeeDto>>(employeeList);
        }

        public async Task<EmployeeDto> UpdateEmployee(EmployeeDto employeeDto)
        {

            Models.Employee employee = _mapper.Map<EmployeeDto, Models.Employee>(employeeDto);


            if (employee.Id > 0)
            {
                _db.Employees.Update(employee);
            }

            await _db.SaveChangesAsync();

            return _mapper.Map<Models.Employee, EmployeeDto>(employee);
        }
    }
}
