using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MealPlanning
{
    public partial class IngredientDialog : Form
    {

        private EnhancedListView<Ingredient> _ingredientList;
        private int _selectionIndex = -1;
        private RecipeEditor _editor;
        

        public IngredientDialog(RecipeEditor editor)
        {
            InitializeComponent();
            _ingredientList = new EnhancedListView<Ingredient>(true, false);
            _ingredientList.Font = new Font(FontFamily.GenericSansSerif, 10);
            _ingredientList.HoverColor = Color.LightBlue;
            dialogList.Controls.Add(_ingredientList);
            _ingredientList.ResizeToParent();
            _ingredientList.SelectionChanged += IngredientChanged;
            errorLabel.Text = "";
            cmbUOM.Enabled = false;
            _editor = editor;
        }

        public void AddIngredients(IEnumerable<Ingredient> ingredients)
        {
            foreach (Ingredient ingr in ingredients)
            {
                _ingredientList.Add(ingr);
            }
        }

        private void searchBox_TextChanged(object sender, EventArgs e)
        {
            _selectionIndex = -1;
            _ingredientList.SelectedItem = null;
            _ingredientList.FilterText = searchBox.Text;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            if (_ingredientList.SelectedItem == null)
            {
                errorLabel.Text = "No ingredient selected";
                return;
            }
            double qty;
            if (double.TryParse(quantityField.Text, out qty))
            {
                _editor.AddIngredient(_ingredientList.SelectedItem,
                     UOM.UOMList.Where(u => u.Name == ((UOM)cmbUOM.SelectedItem).Name).First(), qty);

                quantityField.Text = "";
            }
            else
            {
                errorLabel.Text = "Invalid quantity";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void IngredientChanged(Ingredient old, Ingredient n)
        {
            if (n != null)
            {
                cmbUOM.Items.Clear();
                cmbUOM.Items.AddRange(UOM.UOMList.Where(u => u.Class == n.UOMClass).ToArray());
                cmbUOM.SelectedIndex = 0;
                cmbUOM.Enabled = true;
            }
            else
            {
                cmbUOM.Items.Clear();
            }
        }

        private void IngredientDialog_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void searchBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {

            if (keyData == Keys.Down)
            {
                if (searchBox.Focused)
                {
                    if (_selectionIndex >= _ingredientList.DisplayCount - 1)
                    {
                        return true;
                    }
                    _selectionIndex++;
                    if (_selectionIndex < _ingredientList.Items.Count)
                    {
                        _ingredientList.Select(_selectionIndex);
                    }
                    else
                    {
                        _ingredientList.SelectedItem = null;
                    }
                    return true;
                }
            }
            else if (keyData == Keys.Up)
            {
                if (searchBox.Focused) { }
                if (_selectionIndex <= 0)
                {
                    return true;
                }
                _selectionIndex--;

                if (_selectionIndex >= 0)
                {
                    _ingredientList.Select(_selectionIndex);
                }
                else
                {
                    _ingredientList.SelectedItem = null;
                }
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
