using System.ComponentModel.DataAnnotations;

namespace CRUD.Services.Employee.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        public string Surname { get; set; }

        public string City { get; set; }

        [Required]
        public string Phone { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Position { get; set; }


    }
}
