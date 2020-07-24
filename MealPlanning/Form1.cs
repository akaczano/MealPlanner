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
    public partial class Form1 : Form, RecipeEditor {

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
            cmbSection.Enabled = false;


            foreach (var type in Enum.GetValues(typeof(RecipeType))) {
                recipeType.Items.Add(type);
                shopType.Items.Add(type);
                if ((RecipeType)type != RecipeType.All) {
                    cmbRecipeType.Items.Add(type);
                }
            }
            recipeType.SelectedItem = RecipeType.All;
            shopType.SelectedItem = RecipeType.All;
            cmbRecipeType.SelectedItem = RecipeType.Dinner;
            cmbRecipeType.SelectedIndexChanged += RecipeTypeModified;
            cmbRecipeType.Enabled = false;

            foreach (var section in Enum.GetValues(typeof(StoreSection))) {
                cmbSection.Items.Add(section);
            }
            cmbSection.SelectedIndexChanged += StoreSectionChanged;

            InterfaceUtil.BuildRecipeDisplay(_recipeList, recipeSearch, sortButton, recipeType);
            InterfaceUtil.BuildRecipeDisplay(_shopList1, shopSearch, null, shopType);

            backgroundWorker1.DoWork += Save;
            backgroundWorker1.ProgressChanged += ProgressChanged;
        }

        private void ProgressChanged(object sender, ProgressChangedEventArgs e) {
            saveProgress.Value = e.ProgressPercentage;
        }

        private void _shopList2_DragDrop(object sender, DragEventArgs e) {
            Recipe recipe = _shopList1.Items.Find(r => r.Name == e.Data.GetData(DataFormats.Text).ToString());
            _shopList2.Add(recipe);
        }

        private void _shopList2_DragOver(object sender, DragEventArgs e) {
            e.Effect = DragDropEffects.Move;
        }


        private void ingredientSearch_TextChanged(object sender, EventArgs e) {
            _ingredientList.FilterText = ingredientSearch.Text;
        }

        private void NewIngredient(object sender, EventArgs e) {
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
                cmbSection.Enabled = true;
                cmbSection.SelectedItem = newIngredient.Section;
            }
            else {
                iNameField.Text = "";
                iNameField.Enabled = false;
                ingredientUOM.Enabled = false;
                cmbSection.Enabled = false;
                removeIngredient.Enabled = false;
            }
            selectionChanging = false;
        }

        private void IngredientNameChanged(object sender, EventArgs e) {
            if (iNameField.Text.Length > 0 && !_ingredientList.Items.Any(i => i.Name == iNameField.Text)) {
                if (_ingredientList.SelectedItem != null && !selectionChanging) {
                    _ingredientList.UpdateDisplayText(_ingredientList.SelectedItem, iNameField.Text);
                    _ingredientList.SelectedItem.Name = iNameField.Text;
                }
            }
        }

        private void IngredientUOMClassChanged(object sender, EventArgs e) {
            if (_ingredientList.SelectedItem != null && !selectionChanging) {
                _ingredientList.SelectedItem.UOMClass = (UOMClass)ingredientUOM.SelectedItem;
            }
        }

        private void FormLoad(object sender, EventArgs e) {
            if (File.Exists("ingredients.txt")) {
                string[] lines = File.ReadAllLines("ingredients.txt");
                foreach (string line in lines) {
                    string[] fields = line.Split('|');
                    Ingredient ingredient = new Ingredient() {
                        Name = fields[0],
                        UOMClass = (UOMClass)int.Parse(fields[1]),
                        Section = (StoreSection)int.Parse(fields[2])
                    };
                    Console.WriteLine("{0}:{1}", line, ingredient.Name);
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

        private void OnFormClosed(object sender, EventArgs e) {
            Save(null, null);
        }

        private void Save(object sender, DoWorkEventArgs e) {
            double totalProgress = _ingredientList.Items.Count + _recipeList.Items.Count * 2;
            double currentProgress = 0;
            StringBuilder builder = new StringBuilder();
            foreach (Ingredient i in _ingredientList.Items) {
                Console.WriteLine(i);
                Console.WriteLine(string.Format("{0}|{1}|{2}", i.Name, (int)i.UOMClass, (int)i.Section));
                builder.Append(string.Format("{0}|{1}|{2}\n", i.Name, (int)i.UOMClass, (int)i.Section));
                currentProgress++;
                if (backgroundWorker1.IsBusy) {
                    backgroundWorker1.ReportProgress((int)(currentProgress / totalProgress * 100));
                }
            }
            File.WriteAllText("ingredients.txt", builder.ToString());

            StringBuilder recipeBuilder = new StringBuilder();

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
                recipeBuilder.Append(line + "\n");
                currentProgress += 2;
                if (backgroundWorker1.IsBusy) {
                    backgroundWorker1.ReportProgress((int)(currentProgress / totalProgress * 100));
                }

            }
            File.WriteAllText("recipes.txt", recipeBuilder.ToString());
        }

        private void RecipeNameChanged(object sender, EventArgs e) {
            if (_recipeList.SelectedItem != null && !selectionChanging) {
                if (rNameField.Text.Length > 0 && !_recipeList.Items.Any(r => r.Name == rNameField.Text)) {
                    _recipeList.UpdateDisplayText(_recipeList.SelectedItem, rNameField.Text);
                    _recipeList.SelectedItem.Name = rNameField.Text;
                }
            }
        }

        private void RecipeAddIngredient(object sender, EventArgs e) {
            IngredientDialog dialog = new IngredientDialog(this);
            dialog.AddIngredients(_ingredientList.Items);
            dialog.Location = this.Location;
            dialog.ShowDialog();
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

        private void NewRecipe(object sender, EventArgs e) {
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

        private void RemoveRecipe(object sender, EventArgs e) {
            if (_recipeList.SelectedItem != null) {
                DialogResult result = MessageBox.Show("Are you sure you want to delete " +
                    _recipeList.SelectedItem.Name,
                    "Confirm delete", MessageBoxButtons.OKCancel);
                if (result == DialogResult.OK) {
                    _recipeList.Remove(_recipeList.SelectedItem);
                    rNameField.Text = "";
                    dataGridView1.Rows.Clear();
                    rNameField.Enabled = false;
                    addIngredient.Enabled = false;
                    delIngredient.Enabled = false;
                }
            }
        }

        private void RecipeRemoveIngredient(object sender, EventArgs e) {
            if (_recipeList.SelectedItem != null && dataGridView1.SelectedRows.Count > 0) {
                int index = dataGridView1.SelectedRows[0].Index;
                _recipeList.SelectedItem.Ingredients.RemoveAt(index);
                dataGridView1.Rows.RemoveAt(index);
            }
        }

        private void RemoveIngredient(object sender, EventArgs e) {
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


        private void RefreshShopRecipes(object sender, EventArgs e) {
            _shopList1.Clear();
            _shopList2.Clear();
            foreach (Recipe r in _recipeList.Items) {
                _shopList1.Add(r);
            }
        }

        private void GenerateShoppingList(object sender, EventArgs e) {

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

            IEnumerable<StoreSection> sections = shoppingList.Select(x => x.Key.Section).Distinct();
            foreach (StoreSection section in sections) {

                builder.Append(string.Format("<h4>{0}<h4>", section.ToString()));
                builder.Append("<ul>");
                IEnumerable<KeyValuePair<Ingredient, double>> list = shoppingList.Where(y => y.Key.Section == section)
                    .ToList();
                foreach (KeyValuePair<Ingredient, double> pair in list.OrderBy(x => x.Key.Name)) {
                    string label = "";
                    double current = pair.Value;
                    for (int i = 0; i < UOM.GetUOMs(pair.Key.UOMClass).Length; i++) {
                        UOM uom = UOM.GetUOMs(pair.Key.UOMClass)[i];
                        int quantity = (int)(current / uom.ConversionFactor);

                        current -= quantity * uom.ConversionFactor;
                        if (i == (UOM.GetUOMs(pair.Key.UOMClass).Length - 1) && current > 0.01) {
                            quantity++;
                        }
                        if (quantity > 0) {
                            label += quantity + " " + uom.Abbreviation + ", ";
                        }
                    }
                    label = label.Substring(0, label.Length - 2);
                    builder.Append(string.Format("<li>{0}: {1}</li>", pair.Key.Name, label));
                }
                builder.Append("</ul>");
            }

            webBrowser1.DocumentText = builder.ToString();
            saveButton.Enabled = true;
        }

        private void SaveShoppingList(object sender, EventArgs e) {
            saveFileDialog1.ShowDialog();
            string fileName = saveFileDialog1.FileName;
            if (!fileName.EndsWith(".html")) {
                fileName += ".html";
            }
            File.WriteAllText(fileName, webBrowser1.DocumentText);
        }

        private void RemoveShopRecipe(object sender, EventArgs e) {
            _shopList2.Remove(_shopList2.SelectedItem);
        }

        private void ShopListSelected(Recipe old, Recipe ne) {
            if (ne != null) {
                listRemove.Enabled = true;
            }
        }



        private void SortIngredients(object sender, EventArgs e) {
            _ingredientList.Sort((a, b) => a.Name.CompareTo(b.Name));
        }


        private void RecipeTypeModified(object sender, EventArgs args) {
            if (_recipeList.SelectedItem != null && !selectionChanging) {
                _recipeList.SelectedItem.Type = (RecipeType)cmbRecipeType.SelectedItem;
            }
        }

        private void StoreSectionChanged(object sender, EventArgs e) {
            if (_ingredientList.SelectedItem != null && !selectionChanging) {
                _ingredientList.SelectedItem.Section = (StoreSection)cmbSection.SelectedItem;
            }
        }

        private void EditPreferences(object sender, EventArgs e) {
            SettingsForm settingsForm = new SettingsForm(new UserPreferences());
            settingsForm.Width = 350;
            settingsForm.Height = 500;
            settingsForm.ShowWindow();
        }

        private void ShowMealList(object sender, EventArgs e) {
            StringBuilder builder = new StringBuilder();
            foreach (RecipeType type in _shopList2.Items.Select(r => r.Type).Distinct()) {
                IEnumerable<Recipe> list = _shopList2.Items.Where(r => r.Type == type)
                    .OrderBy(r => r.Name);
                builder.Append(string.Format("<h3>{0}</h3>", type.ToString()));
                foreach (Recipe recipe in list) {
                    builder.Append(string.Format("{0}<br>", recipe.Name));
                }
            }
            webBrowser1.DocumentText = builder.ToString();
        }

        private void SaveClicked(object sender, EventArgs e) {
            if (!backgroundWorker1.IsBusy) {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e) {

        }

        private void Form1_Shown(object sender, EventArgs e) {

        }

        public void AddIngredient(Ingredient ingredient, UOM uom, double qty) {            
            if (ingredient != null)
            {
                dataGridView1.Rows.Add();
                int index = dataGridView1.Rows.Count - 1;
                dataGridView1[0, index].Value = ingredient.Name;
                dataGridView1[2, index].Value = uom.Name;
                dataGridView1[1, index].Value = qty;
                _recipeList.SelectedItem.Ingredients.Add((ingredient, uom, qty));
            }
        }

    }

    public interface RecipeEditor {
        void AddIngredient(Ingredient ingredient, UOM uom, double qty);
    }
}
