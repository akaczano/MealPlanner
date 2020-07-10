using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealPlanning {
    public partial class Form1 : Form {

        private EnhancedListView<Recipe> _recipeList;
        private EnhancedListView<Ingredient> _ingredientList;
        private EnhancedListView<Recipe> _shopList1;
        private EnhancedListView<Recipe> _shopList2;
        private bool selectionChanging = false;

        public Form1() {
            InitializeComponent();

            _recipeList = new EnhancedListView<Recipe>(true, false);
            _recipeList.HoverColor = Color.LightBlue;
            _recipeList.Font = new Font(FontFamily.GenericSansSerif, 13);
            _recipeList.SelectionChanged += RecipeSelected;
            this.recipeListPanel.Controls.Add(_recipeList);
            _recipeList.ResizeToParent();

            _ingredientList = new EnhancedListView<Ingredient>(true, false);
            _ingredientList.HoverColor = Color.LightBlue;
            _ingredientList.Font = new Font(FontFamily.GenericSansSerif, 13);
            _ingredientList.SelectionChanged += IngredientSelected;
            ingredientListPanel.Controls.Add(_ingredientList);
            _ingredientList.ResizeToParent();


            foreach (UOMClass measurement in Enum.GetValues(typeof(UOMClass))) {
                ingredientUOM.Items.Add(measurement);
            }
            iNameField.Enabled = false;
            ingredientUOM.Enabled = false;
            rNameField.Enabled = false;
            addIngredient.Enabled = false;
            delIngredient.Enabled = false;
            removeIngredient.Enabled = false;
            removeRecipe.Enabled = false;


            _shopList1 = new EnhancedListView<Recipe>(false, true);
            _shopList2 = new EnhancedListView<Recipe>(true, false);
            _shopList1.Font = new Font(FontFamily.GenericSansSerif, 12);
            _shopList2.Font = new Font(FontFamily.GenericSansSerif, 12);
            _shopList1.AllowDrop = true;

            _shopList2.AllowDrop = true;
            _shopList2.DragEnter += _shopList2_DragOver;
            _shopList2.DragDrop += _shopList2_DragDrop;
            _shopList2.HoverColor = Color.LightBlue;
            _shopList2.SelectionChanged += ShopListSelected;

            recipePanel.Controls.Add(_shopList1);
            _shopList1.ResizeToParent();
            shoppingPanel.Controls.Add(_shopList2);
            _shopList2.ResizeToParent();
            saveButton.Enabled = false;
            listRemove.Enabled = false;


            foreach (var type in Enum.GetValues(typeof(RecipeType))) {
                recipeType.Items.Add(type);
                if ((RecipeType)type != RecipeType.All)
                {
                    cmbRecipeType.Items.Add(type);
                }
            }
            recipeType.SelectedItem = RecipeType.All;
            recipeType.SelectedIndexChanged += RecipeTypeChanged;
            cmbRecipeType.SelectedItem = RecipeType.Dinner;
            cmbRecipeType.SelectedIndexChanged += RecipeTypeModified;
            cmbRecipeType.Enabled = false;
        }

        private void _shopList2_DragDrop(object sender, DragEventArgs e) {
            Recipe recipe = _shopList1.Items.Find(r => r.Name == e.Data.GetData(DataFormats.Text).ToString());
            _shopList2.Add(recipe);
        }

        private void _shopList2_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }

        private void textBox1_TextChanged(object sender, EventArgs e) {
            _recipeList.FilterText = recipeSearch.Text;

        }

        private void ingredientSearch_TextChanged(object sender, EventArgs e) {
            _ingredientList.FilterText = ingredientSearch.Text;
        }

        private void newIngredient_Click(object sender, EventArgs e) {
            Ingredient ingredient = new Ingredient();
            ingredient.Name = "New Ingredient";
            int counter = 1;
            while (_ingredientList.Items.Any(x => x.Name == ingredient.Name)) {
                ingredient.Name = "New Ingredient " + counter;
                counter++;
            }
            _ingredientList.Add(ingredient);
            _ingredientList.SelectedItem = ingredient;
        }

        private void IngredientSelected(Ingredient oldIngredient, Ingredient newIngredient) {
            selectionChanging = true;
            if (newIngredient != null) {
                iNameField.Text = newIngredient.Name;
                iNameField.Enabled = true;
                ingredientUOM.Enabled = true;
                ingredientUOM.SelectedItem = newIngredient.UOMClass;
                removeIngredient.Enabled = true;
            }
            else {
                iNameField.Text = "";
                iNameField.Enabled = false;
                ingredientUOM.Enabled = false;
            }
            selectionChanging = false;
        }

        private void iNameField_TextChanged(object sender, EventArgs e) {
            if (iNameField.Text.Length > 0 && !_ingredientList.Items.Any(i => i.Name == iNameField.Text)) {
                if (_ingredientList.SelectedItem != null && !selectionChanging) {
                    _ingredientList.UpdateDisplayText(_ingredientList.SelectedItem, iNameField.Text);
                    _ingredientList.SelectedItem.Name = iNameField.Text;
                    _recipeList.Sort((a, b) => a.Name.CompareTo(b.Name));
                }
            }
        }

        private void ingredientUOM_SelectedIndexChanged(object sender, EventArgs e) {
            if (_ingredientList.SelectedItem != null && !selectionChanging) {
                _ingredientList.SelectedItem.UOMClass = (UOMClass)ingredientUOM.SelectedItem;
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
            if (File.Exists("ingredients.txt")) {
                string[] lines = File.ReadAllLines("ingredients.txt");
                foreach (string line in lines) {
                    string[] fields = line.Split('|');
                    Ingredient ingredient = new Ingredient() {
                        Name = fields[0],
                        UOMClass = (UOMClass)int.Parse(fields[1]),
                        Section = (StoreSection)int.Parse(fields[2])
                    };
                    _ingredientList.Add(ingredient);
                }
            }
            if (File.Exists("recipes.txt")) {
                string[] lines = File.ReadAllLines("recipes.txt");
                foreach (string line in lines) {
                    string[] fields = line.Split('|');
                    Recipe recipe = new Recipe();
                    recipe.Name = fields[0];
                    int skipCount = 1;
                    int typeVal;
                    if (fields.Length > 1 && int.TryParse(fields[1], out typeVal)) {
                        recipe.Type = (RecipeType)typeVal;
                        skipCount++;
                    }

                    foreach (string ingr in fields.Skip(skipCount)) {
                        string[] segments = ingr.Split('~');
                        Ingredient ingredient = _ingredientList.Items.Find(i => i.Name == segments[0]);
                        UOM uom = UOM.ValueOf(segments[1]);
                        double qty = double.Parse(segments[2]);
                        recipe.Ingredients.Add((ingredient, uom, qty));
                    }
                    _recipeList.Add(recipe);
                    _shopList1.Add(recipe);
                }

            }
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            using (StreamWriter writer = new StreamWriter(File.OpenWrite("ingredients.txt"))) {
                foreach (Ingredient i in _ingredientList.Items) {
                    writer.WriteLine(string.Format("{0}|{1}|{2}", i.Name, (int)i.UOMClass, (int)i.Section));
                }
            }
            using (StreamWriter writer = new StreamWriter("recipes.txt", false)) {
                
                foreach (Recipe r in _recipeList.Items) {
                    string line = r.Name + "|" + (int)r.Type;
                    foreach (var item in r.Ingredients) {
                        line += "|";
                        line += item.Item1.ToString();
                        line += "~";
                        line += item.Item2.ToString();
                        line += "~";
                        line += item.Item3.ToString();
                    }
                    writer.WriteLine(line);
                }
            }
        }

        private void rNameField_TextChanged(object sender, EventArgs e) {
            if (_recipeList.SelectedItem != null && !selectionChanging) {
                if (rNameField.Text.Length > 0 && !_recipeList.Items.Any(r => r.Name == rNameField.Text)) {
                    _recipeList.UpdateDisplayText(_recipeList.SelectedItem, rNameField.Text);
                    _recipeList.SelectedItem.Name = rNameField.Text;
                }
            }
        }

        private void addIngredient_Click(object sender, EventArgs e) {
            IngredientDialog dialog = new IngredientDialog();
            dialog.AddIngredients(_ingredientList.Items);
            dialog.ShowDialog();
            (Ingredient ingredient, UOM uom, double qty) = dialog.Value;
            if (ingredient != null) {
                dataGridView1.Rows.Add();
                int index = dataGridView1.Rows.Count - 1;
                dataGridView1[0, index].Value = ingredient.Name;
                dataGridView1[2, index].Value = uom.Name;
                dataGridView1[1, index].Value = qty;
                _recipeList.SelectedItem.Ingredients.Add(dialog.Value);
            }
        }

        private void RecipeSelected(Recipe oldRecipe, Recipe newRecipe) {
            selectionChanging = true;
            if (newRecipe != null) {
                rNameField.Text = newRecipe.Name;
                cmbRecipeType.SelectedItem = newRecipe.Type;
                rNameField.Enabled = true;
                addIngredient.Enabled = true;
                delIngredient.Enabled = true;
                removeRecipe.Enabled = true;
                cmbRecipeType.Enabled = true;
                dataGridView1.Rows.Clear();
                foreach ((Ingredient ingr, UOM uom, double qty) in newRecipe.Ingredients) {
                    dataGridView1.Rows.Add();
                    int index = dataGridView1.Rows.Count - 1;
                    dataGridView1[0, index].Value = ingr.Name;
                    dataGridView1[1, index].Value = qty;
                    dataGridView1[2, index].Value = uom.Name;
                }
            }
            else {
                rNameField.Text = "";
                rNameField.Enabled = false;
                cmbRecipeType.Enabled = false;
                dataGridView1.Rows.Clear();
                addIngredient.Enabled = false;
                delIngredient.Enabled = false;
                removeRecipe.Enabled = false;
            }
            selectionChanging = false;
        }

        private void newRecipe_Click(object sender, EventArgs e) {
            Recipe recipe = new Recipe() {
                Name = "New Recipe"
            };

            int counter = 1;
            while (_recipeList.Items.Any(x => x.Name == recipe.Name)) {
                recipe.Name = "New Recipe " + counter;
                counter++;
            }
            _recipeList.Add(recipe);           
            _recipeList.SelectedItem = recipe;
        }

        private void removeRecipe_Click(object sender, EventArgs e) {            
            if (_recipeList.SelectedItem != null) {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " + 
                    _recipeList.SelectedItem.Name,
                    "Confirm delete", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK)
                {
                    _recipeList.Remove(_recipeList.SelectedItem);
                    rNameField.Text = "";
                    dataGridView1.Rows.Clear();
                    rNameField.Enabled = false;
                    addIngredient.Enabled = false;
                    delIngredient.Enabled = false;
                }
            }
        }

        private void delIngredient_Click(object sender, EventArgs e) {
            if (_recipeList.SelectedItem != null && dataGridView1.SelectedRows.Count > 0) {
                int index = dataGridView1.SelectedRows[0].Index;
                _recipeList.SelectedItem.Ingredients.RemoveAt(index);
                dataGridView1.Rows.RemoveAt(index);
            }
        }

        private void removeIngredient_Click(object sender, EventArgs e) {
            if (_ingredientList.SelectedItem != null) {
                bool possible = true;
                foreach (Recipe r in _recipeList.Items) {
                    if (r.Ingredients.Any(x => x.Item1.Name == _ingredientList.SelectedItem.Name)) {
                        possible = false;
                    }
                }
                if (possible) {
                    _ingredientList.Remove(_ingredientList.SelectedItem);
                    iNameField.Text = "";
                    iNameField.Enabled = false;
                    ingredientUOM.Enabled = false;
                    removeIngredient.Enabled = false;
                }
                else {
                    MessageBox.Show("Cannot remove ingredient that is currently in use in recipes.", "Error");
                }
            }
        }

        private void shopSearch_TextChanged(object sender, EventArgs e) {
            _shopList1.FilterText = shopSearch.Text;
        }

        private void refreshButton_Click(object sender, EventArgs e) {
            _shopList1.Clear();
            _shopList2.Clear();
            foreach (Recipe r in _recipeList.Items) {                
                    _shopList1.Add(r);                
            }
        }

        private void generateButton_Click(object sender, EventArgs e) {

            Dictionary<Ingredient, double> shoppingList = new Dictionary<Ingredient, double>();

            foreach (Recipe recipe in _shopList2.Items) {
                foreach ((Ingredient ingr, UOM uom, double qty) in recipe.Ingredients) {
                    double converted = qty * uom.ConversionFactor;
                    if (!shoppingList.ContainsKey(ingr)) {
                        shoppingList[ingr] = converted;
                    }
                    else {
                        shoppingList[ingr] += converted;
                    }
                }
            }

            // 3 pounds, 5 ounces = 3.3125 lb
            StringBuilder builder = new StringBuilder();
            builder.Append("<h3>Shopping List</h3>");
            builder.Append("<ul>");
            foreach (KeyValuePair<Ingredient, double> pair in shoppingList.OrderBy(x => x.Key.Name)) {
                string label = "";
                double current = pair.Value;
                for  (int i = 0; i < UOM.GetUOMs(pair.Key.UOMClass).Length; i++) {
                    UOM uom = UOM.GetUOMs(pair.Key.UOMClass)[i];
                    int quantity = (int)(current / uom.ConversionFactor);

                    current -= quantity * uom.ConversionFactor;
                    if (i == (UOM.GetUOMs(pair.Key.UOMClass).Length - 1) && current > 0.01) {
                        quantity++;
                    }
                    if (quantity > 0)
                    {
                        label += quantity + " " + uom.Abbreviation + ", ";
                    }
                }
                label = label.Substring(0, label.Length - 2);
                builder.Append(string.Format("<li>{0}: {1}</li>", pair.Key.Name, label));
            }
            builder.Append("</ul>");
            webBrowser1.DocumentText = builder.ToString();
            saveButton.Enabled = true;
        }

        private void saveButton_Click(object sender, EventArgs e) {
            saveFileDialog1.ShowDialog();
            string fileName = saveFileDialog1.FileName;
            if (!fileName.EndsWith(".html")) {
                fileName += ".html";
            }
            File.WriteAllText(fileName, webBrowser1.DocumentText);
        }

        private void listRemove_Click(object sender, EventArgs e) {
            _shopList2.Remove(_shopList2.SelectedItem);
        }

        private void ShopListSelected(Recipe old, Recipe ne) {
            if (ne != null) {
                listRemove.Enabled = true;
            }   
        }



        private void SortIngredients(object sender, EventArgs e)
        {
            _ingredientList.Sort((a, b) => a.Name.CompareTo(b.Name));
        }

        private void RecipeTypeChanged(object sender, EventArgs e)
        {
            RecipeType newType = (RecipeType)recipeType.SelectedItem;
            if (newType != RecipeType.All)
            {
                _recipeList.Filter(r => r.Type == newType);
            }
            else {
                _recipeList.Filter(r => true);
            }
        }

        private void SortRecipes(object sender, EventArgs e)
        {
            _recipeList.Sort((a, b) => a.Name.CompareTo(b.Name));
        }

        private void RecipeTypeModified(object sender, EventArgs args) {
            if (_recipeList.SelectedItem != null && !selectionChanging)
            {
                _recipeList.SelectedItem.Type = (RecipeType)cmbRecipeType.SelectedItem;
            }
        }
    }
}
