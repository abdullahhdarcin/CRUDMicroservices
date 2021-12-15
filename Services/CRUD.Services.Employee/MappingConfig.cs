using AutoMapper;
using CRUD.Services.Employee.Dtos;

namespace CRUD.Services.Employee
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMap()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<EmployeeDto, Models.Employee>();
                config.CreateMap<Models.Employee, EmployeeDto>();
            });

            return mappingConfig;
        }

    }
}
