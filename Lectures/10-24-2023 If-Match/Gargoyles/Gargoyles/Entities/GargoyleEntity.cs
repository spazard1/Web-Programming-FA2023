using Gargoyles.Models;

namespace Gargoyles.Entities
{
    public class GargoyleEntity
    {
        public GargoyleEntity() { 
        
        }

        public GargoyleEntity(GargoyleModel model)
        {
            this.Name = model.Name;
            this.Color = model.Color;
            this.Age = model.Age;
        }

        public string? Name { get; set; }

        public string? Color { get; set; }

        public int Age { get; set; }

        public GargoyleModel ToModel()
        {
            return new GargoyleModel
            {
                Name = this.Name,
                Color = this.Color,
                Age = this.Age,
            };
        }
    }
}
