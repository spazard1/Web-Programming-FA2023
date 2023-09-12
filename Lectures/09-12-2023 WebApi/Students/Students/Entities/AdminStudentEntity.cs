﻿using Students.Models;
using System.ComponentModel.DataAnnotations;

namespace Students.Entities
{
    public class AdminStudentEntity
    {
        public AdminStudentEntity()
        {

        }

        public AdminStudentEntity(StudentModel model)
        {
            this.FirstName = model.FirstName;
            this.LastName = model.LastName;
            this.Grade = model.Grade;
        }

        [Required]
        [MinLength(3)]
        public string? FirstName { get; set; }

        [Required]
        [MinLength(3)]
        public string? LastName { get; set; }

        public string? Grade { get; set; }

        public StudentModel ToModel()
        {
            return new StudentModel()
            {
                FirstName = FirstName,
                LastName = LastName,
                Grade = Grade
            };
        }
    }
}
