namespace Gargoyles.Models
{
    public class GargoyleModel
    {
        public string? Name { get; set; }

        public string? Color { get; set; }

        public int Age { get; set; }

        public DateTime Updated { get; set; }

        public string ETag()
        {
            return this.Updated.ToString();
        }
    }
}
