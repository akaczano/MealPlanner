using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanning {
    class Recipe {

        public string Name { get; set; }
        public List<(Ingredient, UOM, double)> Ingredients { get; set; }

        public Recipe() {
            Ingredients = new List<(Ingredient, UOM, double)>();
        }

        public override string ToString() {
            return Name;
        }

    }
}
