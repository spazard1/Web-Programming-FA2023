using ApiVersioning.Models;
using System.ComponentModel.DataAnnotations;

namespace ApiVersioning.Entities.V1U0
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
        }

        [Required]
        [MinLength(3)]
        public string? Value { get; set; }

        [Required]
        [MinLength(3)]
        public string? Name { get; set; }

        public ValueModel ToModel()
        {
            return new ValueModel()
            {
                Value = Value,
                Name = Name
            };
        }
    }
}
