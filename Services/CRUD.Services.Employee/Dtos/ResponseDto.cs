using System.Collections.Generic;

namespace CRUD.Services.Employee.Dtos
{
    public class ResponseDto
    {
        public bool IsSuccess { get; set; }

        public object Result { get; set; }

        public string DisplayMessage { get; set; }

        public List<string> ErrorMessages { get; set; }

    }
}
