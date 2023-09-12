using Students.Models;
using System.ComponentModel.DataAnnotations;

namespace Students.Entities
{
    public class StudentEntity
    {
        public StudentEntity()
        {

        }

        public StudentEntity(StudentModel model)
        {
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
        }

        [Required]
        [MinLength(3)]
        public string? FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string? LastName { get; set; }

        public StudentModel ToModel()
        {
            return new StudentModel()
            {
                FirstName = FirstName,
                LastName = LastName
            };
        }
    }
}
