using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealPlanning {
    public class Recipe {

        public string Name { get; set; }
        public List<(Ingredient, UOM, double)> Ingredients { get; set; }

        public RecipeType Type { get; set; } = RecipeType.Dinner;

        public Recipe() {
            Ingredients = new List<(Ingredient, UOM, double)>();
        }

        public override string ToString() {
            return Name;
        }

    }

    public enum RecipeType { 
        Breakfast = 0,
        Lunch = 1,
        Dinner= 2,
        Dessert = 3,
        All = 4
    }
}
