using Gargoyles.Models;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Gargoyles
{
    public class GargoyleDatabase
    {
        private Dictionary<string, GargoyleModel> gargoyles = new();

        public GargoyleModel Get(string name)
        {
            // note, i'm not doing null checking here, you should do that probably in your assignment.

            return gargoyles[name];
        }

        public void AddOrReplace(GargoyleModel model)
        {
            if (model?.Name == null)
            {
                return;
            }

            model.Updated = DateTime.UtcNow;
            this.gargoyles[model.Name] = model;
        }
    }
}
