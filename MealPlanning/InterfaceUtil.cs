using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealPlanning
{
    static class InterfaceUtil
    {
        public static void BuildRecipeDisplay(EnhancedListView<Recipe> recipeList, TextBox searchBox,
            Button sortButton, ComboBox recipeType) {
            if (searchBox != null) {
                searchBox.TextChanged += (sender, args) => {
                    recipeList.FilterText = searchBox.Text;
                };
            }
            if (sortButton != null) {
                sortButton.Click += (sender, args) => {
                    recipeList.Sort((a, b) => a.Name.CompareTo(b.Name));
                };
            }
            if (recipeType != null) {
                recipeType.SelectedIndexChanged += (sender, args) =>
                {
                    RecipeType newType = (RecipeType)recipeType.SelectedItem;
                    if (newType != RecipeType.All)
                    {
                        recipeList.Filter(r => r.Type == newType);
                    }
                    else
                    {
                        recipeList.Filter(r => true);
                    }
                };
            }
        }
    }
}
