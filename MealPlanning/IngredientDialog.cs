using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealPlanning {
    public partial class IngredientDialog : Form {

        private EnhancedListView<Ingredient> _ingredientList;

        public (Ingredient, UOM, double) Value { get; set; }

        public IngredientDialog() {
            InitializeComponent();
            _ingredientList = new EnhancedListView<Ingredient>(true, false);
            _ingredientList.Font = new Font(FontFamily.GenericSansSerif, 10);
            _ingredientList.HoverColor = Color.LightBlue;
            dialogList.Controls.Add(_ingredientList);
            _ingredientList.ResizeToParent();
            _ingredientList.SelectionChanged += IngredientChanged;
            errorLabel.Text = "";
            cmbUOM.Enabled = false;
        }

        public void AddIngredients(IEnumerable<Ingredient> ingredients) {
            foreach (Ingredient ingr in ingredients) {
                _ingredientList.Add(ingr);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e) {
            _ingredientList.FilterText = searchBox.Text;
        }

        private void addButton_Click(object sender, EventArgs e) {
            if (_ingredientList.SelectedItem == null) {
                errorLabel.Text = "No ingredient selected";
                return;
            }
            double qty;
            if (double.TryParse(quantityField.Text, out qty)) {
                Value = (_ingredientList.SelectedItem, 
                    UOM.UOMList.Where(u => u.Name == ((UOM)cmbUOM.SelectedItem).Name).First(), qty);
                Close();
            }
            else {
                errorLabel.Text = "Invalid quantity";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e) {
            Close();
        }

        private void IngredientChanged(Ingredient old, Ingredient n) {
            cmbUOM.Items.Clear();
            cmbUOM.Items.AddRange(UOM.UOMList.Where(u => u.Class == n.UOMClass).ToArray());
            cmbUOM.SelectedIndex = 0;
            cmbUOM.Enabled = true;
        }
    }
}
