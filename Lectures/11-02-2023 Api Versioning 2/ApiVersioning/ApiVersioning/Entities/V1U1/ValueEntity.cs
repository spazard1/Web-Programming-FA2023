using ApiVersioning.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiVersioning.Entities.V1U1
{
    public class ValueEntity
    {
        public ValueEntity()
        { 
        
        }

        public ValueEntity(ValueModel model)
        {
            this.Value = model.Value;
            this.Name = model.Name;
            this.Description = model.Description;
        }

        [Required]
        [MinLength(3)]
        public string? Value { get; set; }

        [Required]
        [MinLength(3)]
        public string? Name { get; set; }

        [Required]
        [MinLength(5)]
        public string? Description { get; set; }

        public ValueModel ToModel()
        {
            return new ValueModel()
            {
                Value = Value,
                Name = Name,
                Description = Description
            };
        }
    }
}
