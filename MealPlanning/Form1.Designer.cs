namespace MealPlanning {
    partial class Form1 {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.cmbRecipeType = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.recipeType = new System.Windows.Forms.ComboBox();
            this.removeRecipe = new System.Windows.Forms.Button();
            this.delIngredient = new System.Windows.Forms.Button();
            this.addIngredient = new System.Windows.Forms.Button();
            this.recipeListPanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.recipeSearch = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nameCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qtyCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uomCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rErrorLabel = new System.Windows.Forms.Label();
            this.rNameField = new System.Windows.Forms.TextBox();
            this.rNameLabel = new System.Windows.Forms.Label();
            this.newRecipe = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.button2 = new System.Windows.Forms.Button();
            this.removeIngredient = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.ingredientSearch = new System.Windows.Forms.TextBox();
            this.newIngredient = new System.Windows.Forms.Button();
            this.ingredientListPanel = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.ingredientUOM = new System.Windows.Forms.ComboBox();
            this.iNameField = new System.Windows.Forms.TextBox();
            this.iNameLabel = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listRemove = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.shopSearch = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.refreshButton = new System.Windows.Forms.Button();
            this.shoppingPanel = new System.Windows.Forms.Panel();
            this.recipePanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.generateButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createShoppingListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(1, 28);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(2);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(894, 493);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.cmbRecipeType);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.recipeType);
            this.tabPage1.Controls.Add(this.removeRecipe);
            this.tabPage1.Controls.Add(this.delIngredient);
            this.tabPage1.Controls.Add(this.addIngredient);
            this.tabPage1.Controls.Add(this.recipeListPanel);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.recipeSearch);
            this.tabPage1.Controls.Add(this.dataGridView1);
            this.tabPage1.Controls.Add(this.rErrorLabel);
            this.tabPage1.Controls.Add(this.rNameField);
            this.tabPage1.Controls.Add(this.rNameLabel);
            this.tabPage1.Controls.Add(this.newRecipe);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage1.Size = new System.Drawing.Size(886, 467);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Recipes";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // cmbRecipeType
            // 
            this.cmbRecipeType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbRecipeType.FormattingEnabled = true;
            this.cmbRecipeType.Location = new System.Drawing.Point(463, 84);
            this.cmbRecipeType.Name = "cmbRecipeType";
            this.cmbRecipeType.Size = new System.Drawing.Size(145, 26);
            this.cmbRecipeType.TabIndex = 27;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(464, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(31, 13);
            this.label7.TabIndex = 26;
            this.label7.Text = "Type";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(246, 385);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 25;
            this.button1.Text = "Sort";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.SortRecipes);
            // 
            // recipeType
            // 
            this.recipeType.FormattingEnabled = true;
            this.recipeType.Location = new System.Drawing.Point(342, 387);
            this.recipeType.Name = "recipeType";
            this.recipeType.Size = new System.Drawing.Size(100, 21);
            this.recipeType.TabIndex = 24;
            // 
            // removeRecipe
            // 
            this.removeRecipe.Location = new System.Drawing.Point(365, 420);
            this.removeRecipe.Margin = new System.Windows.Forms.Padding(2);
            this.removeRecipe.Name = "removeRecipe";
            this.removeRecipe.Size = new System.Drawing.Size(77, 30);
            this.removeRecipe.TabIndex = 21;
            this.removeRecipe.Text = "Remove";
            this.removeRecipe.UseVisualStyleBackColor = true;
            this.removeRecipe.Click += new System.EventHandler(this.removeRecipe_Click);
            // 
            // delIngredient
            // 
            this.delIngredient.Location = new System.Drawing.Point(665, 413);
            this.delIngredient.Margin = new System.Windows.Forms.Padding(2);
            this.delIngredient.Name = "delIngredient";
            this.delIngredient.Size = new System.Drawing.Size(152, 33);
            this.delIngredient.TabIndex = 20;
            this.delIngredient.Text = "Remove Ingredient";
            this.delIngredient.UseVisualStyleBackColor = true;
            this.delIngredient.Click += new System.EventHandler(this.delIngredient_Click);
            // 
            // addIngredient
            // 
            this.addIngredient.Location = new System.Drawing.Point(544, 413);
            this.addIngredient.Margin = new System.Windows.Forms.Padding(2);
            this.addIngredient.Name = "addIngredient";
            this.addIngredient.Size = new System.Drawing.Size(102, 33);
            this.addIngredient.TabIndex = 19;
            this.addIngredient.Text = "Add Ingredient";
            this.addIngredient.UseVisualStyleBackColor = true;
            this.addIngredient.Click += new System.EventHandler(this.addIngredient_Click);
            // 
            // recipeListPanel
            // 
            this.recipeListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recipeListPanel.Location = new System.Drawing.Point(3, 3);
            this.recipeListPanel.Margin = new System.Windows.Forms.Padding(2);
            this.recipeListPanel.Name = "recipeListPanel";
            this.recipeListPanel.Size = new System.Drawing.Size(449, 377);
            this.recipeListPanel.TabIndex = 18;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 397);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Search";
            // 
            // recipeSearch
            // 
            this.recipeSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipeSearch.Location = new System.Drawing.Point(17, 422);
            this.recipeSearch.Margin = new System.Windows.Forms.Padding(2);
            this.recipeSearch.Name = "recipeSearch";
            this.recipeSearch.Size = new System.Drawing.Size(188, 24);
            this.recipeSearch.TabIndex = 16;
            this.recipeSearch.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameCol,
            this.qtyCol,
            this.uomCol});
            this.dataGridView1.Location = new System.Drawing.Point(462, 115);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.Height = 16;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(386, 265);
            this.dataGridView1.TabIndex = 15;
            // 
            // nameCol
            // 
            this.nameCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameCol.HeaderText = "Ingredient";
            this.nameCol.MinimumWidth = 10;
            this.nameCol.Name = "nameCol";
            this.nameCol.ReadOnly = true;
            // 
            // qtyCol
            // 
            this.qtyCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.qtyCol.HeaderText = "Quantity";
            this.qtyCol.MinimumWidth = 10;
            this.qtyCol.Name = "qtyCol";
            this.qtyCol.ReadOnly = true;
            this.qtyCol.Width = 71;
            // 
            // uomCol
            // 
            this.uomCol.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.uomCol.HeaderText = "UOM";
            this.uomCol.MinimumWidth = 10;
            this.uomCol.Name = "uomCol";
            this.uomCol.ReadOnly = true;
            this.uomCol.Width = 57;
            // 
            // rErrorLabel
            // 
            this.rErrorLabel.AutoSize = true;
            this.rErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.rErrorLabel.Location = new System.Drawing.Point(215, 240);
            this.rErrorLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rErrorLabel.Name = "rErrorLabel";
            this.rErrorLabel.Size = new System.Drawing.Size(0, 13);
            this.rErrorLabel.TabIndex = 0;
            this.rErrorLabel.Visible = false;
            // 
            // rNameField
            // 
            this.rNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rNameField.Location = new System.Drawing.Point(462, 23);
            this.rNameField.Margin = new System.Windows.Forms.Padding(2);
            this.rNameField.Name = "rNameField";
            this.rNameField.Size = new System.Drawing.Size(388, 27);
            this.rNameField.TabIndex = 8;
            this.rNameField.TextChanged += new System.EventHandler(this.rNameField_TextChanged);
            // 
            // rNameLabel
            // 
            this.rNameLabel.AutoSize = true;
            this.rNameLabel.Location = new System.Drawing.Point(460, 8);
            this.rNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.rNameLabel.Name = "rNameLabel";
            this.rNameLabel.Size = new System.Drawing.Size(35, 13);
            this.rNameLabel.TabIndex = 7;
            this.rNameLabel.Text = "Name";
            // 
            // newRecipe
            // 
            this.newRecipe.Location = new System.Drawing.Point(246, 420);
            this.newRecipe.Margin = new System.Windows.Forms.Padding(2);
            this.newRecipe.Name = "newRecipe";
            this.newRecipe.Size = new System.Drawing.Size(86, 30);
            this.newRecipe.TabIndex = 1;
            this.newRecipe.Text = "New Recipe";
            this.newRecipe.UseVisualStyleBackColor = true;
            this.newRecipe.Click += new System.EventHandler(this.newRecipe_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.removeIngredient);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.ingredientSearch);
            this.tabPage2.Controls.Add(this.newIngredient);
            this.tabPage2.Controls.Add(this.ingredientListPanel);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.ingredientUOM);
            this.tabPage2.Controls.Add(this.iNameField);
            this.tabPage2.Controls.Add(this.iNameLabel);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage2.Size = new System.Drawing.Size(886, 467);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Ingredients";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(232, 347);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(115, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Sort";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SortIngredients);
            // 
            // removeIngredient
            // 
            this.removeIngredient.Location = new System.Drawing.Point(364, 378);
            this.removeIngredient.Margin = new System.Windows.Forms.Padding(2);
            this.removeIngredient.Name = "removeIngredient";
            this.removeIngredient.Size = new System.Drawing.Size(100, 30);
            this.removeIngredient.TabIndex = 21;
            this.removeIngredient.Text = "Remove";
            this.removeIngredient.UseVisualStyleBackColor = true;
            this.removeIngredient.Click += new System.EventHandler(this.removeIngredient_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 359);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Search";
            // 
            // ingredientSearch
            // 
            this.ingredientSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingredientSearch.Location = new System.Drawing.Point(18, 384);
            this.ingredientSearch.Margin = new System.Windows.Forms.Padding(2);
            this.ingredientSearch.Name = "ingredientSearch";
            this.ingredientSearch.Size = new System.Drawing.Size(188, 24);
            this.ingredientSearch.TabIndex = 19;
            this.ingredientSearch.TextChanged += new System.EventHandler(this.ingredientSearch_TextChanged);
            // 
            // newIngredient
            // 
            this.newIngredient.Location = new System.Drawing.Point(232, 378);
            this.newIngredient.Margin = new System.Windows.Forms.Padding(2);
            this.newIngredient.Name = "newIngredient";
            this.newIngredient.Size = new System.Drawing.Size(115, 30);
            this.newIngredient.TabIndex = 18;
            this.newIngredient.Text = "New Ingredient";
            this.newIngredient.UseVisualStyleBackColor = true;
            this.newIngredient.Click += new System.EventHandler(this.newIngredient_Click);
            // 
            // ingredientListPanel
            // 
            this.ingredientListPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ingredientListPanel.Location = new System.Drawing.Point(3, 3);
            this.ingredientListPanel.Margin = new System.Windows.Forms.Padding(2);
            this.ingredientListPanel.Name = "ingredientListPanel";
            this.ingredientListPanel.Size = new System.Drawing.Size(512, 338);
            this.ingredientListPanel.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(527, 74);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "UOM Class";
            // 
            // ingredientUOM
            // 
            this.ingredientUOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ingredientUOM.FormattingEnabled = true;
            this.ingredientUOM.Location = new System.Drawing.Point(527, 96);
            this.ingredientUOM.Margin = new System.Windows.Forms.Padding(2);
            this.ingredientUOM.Name = "ingredientUOM";
            this.ingredientUOM.Size = new System.Drawing.Size(190, 24);
            this.ingredientUOM.TabIndex = 11;
            this.ingredientUOM.SelectedIndexChanged += new System.EventHandler(this.ingredientUOM_SelectedIndexChanged);
            // 
            // iNameField
            // 
            this.iNameField.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.iNameField.Location = new System.Drawing.Point(527, 37);
            this.iNameField.Margin = new System.Windows.Forms.Padding(2);
            this.iNameField.Name = "iNameField";
            this.iNameField.Size = new System.Drawing.Size(349, 27);
            this.iNameField.TabIndex = 10;
            this.iNameField.TextChanged += new System.EventHandler(this.iNameField_TextChanged);
            // 
            // iNameLabel
            // 
            this.iNameLabel.AutoSize = true;
            this.iNameLabel.Location = new System.Drawing.Point(524, 15);
            this.iNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.iNameLabel.Name = "iNameLabel";
            this.iNameLabel.Size = new System.Drawing.Size(35, 13);
            this.iNameLabel.TabIndex = 9;
            this.iNameLabel.Text = "Name";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listRemove);
            this.tabPage3.Controls.Add(this.saveButton);
            this.tabPage3.Controls.Add(this.webBrowser1);
            this.tabPage3.Controls.Add(this.shopSearch);
            this.tabPage3.Controls.Add(this.label6);
            this.tabPage3.Controls.Add(this.refreshButton);
            this.tabPage3.Controls.Add(this.shoppingPanel);
            this.tabPage3.Controls.Add(this.recipePanel);
            this.tabPage3.Controls.Add(this.label2);
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.generateButton);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(2);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(2);
            this.tabPage3.Size = new System.Drawing.Size(886, 467);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Shopping List";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // listRemove
            // 
            this.listRemove.Location = new System.Drawing.Point(280, 334);
            this.listRemove.Margin = new System.Windows.Forms.Padding(2);
            this.listRemove.Name = "listRemove";
            this.listRemove.Size = new System.Drawing.Size(119, 24);
            this.listRemove.TabIndex = 14;
            this.listRemove.Text = "Remove";
            this.listRemove.UseVisualStyleBackColor = true;
            this.listRemove.Click += new System.EventHandler(this.listRemove_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(636, 367);
            this.saveButton.Margin = new System.Windows.Forms.Padding(2);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(79, 33);
            this.saveButton.TabIndex = 13;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(508, 18);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(2);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(10, 10);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(375, 305);
            this.webBrowser1.TabIndex = 12;
            // 
            // shopSearch
            // 
            this.shopSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.shopSearch.Location = new System.Drawing.Point(62, 334);
            this.shopSearch.Margin = new System.Windows.Forms.Padding(2);
            this.shopSearch.Name = "shopSearch";
            this.shopSearch.Size = new System.Drawing.Size(144, 23);
            this.shopSearch.TabIndex = 11;
            this.shopSearch.TextChanged += new System.EventHandler(this.shopSearch_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(14, 339);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Search";
            // 
            // refreshButton
            // 
            this.refreshButton.Location = new System.Drawing.Point(12, 375);
            this.refreshButton.Margin = new System.Windows.Forms.Padding(2);
            this.refreshButton.Name = "refreshButton";
            this.refreshButton.Size = new System.Drawing.Size(74, 25);
            this.refreshButton.TabIndex = 9;
            this.refreshButton.Text = "Refresh";
            this.refreshButton.UseVisualStyleBackColor = true;
            this.refreshButton.Click += new System.EventHandler(this.refreshButton_Click);
            // 
            // shoppingPanel
            // 
            this.shoppingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.shoppingPanel.Location = new System.Drawing.Point(248, 43);
            this.shoppingPanel.Margin = new System.Windows.Forms.Padding(2);
            this.shoppingPanel.Name = "shoppingPanel";
            this.shoppingPanel.Size = new System.Drawing.Size(192, 281);
            this.shoppingPanel.TabIndex = 8;
            // 
            // recipePanel
            // 
            this.recipePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.recipePanel.Location = new System.Drawing.Point(12, 43);
            this.recipePanel.Margin = new System.Windows.Forms.Padding(2);
            this.recipePanel.Name = "recipePanel";
            this.recipePanel.Size = new System.Drawing.Size(192, 281);
            this.recipePanel.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(263, 14);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Shopping List";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Recipes";
            // 
            // generateButton
            // 
            this.generateButton.Location = new System.Drawing.Point(280, 373);
            this.generateButton.Margin = new System.Windows.Forms.Padding(2);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(119, 27);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Create shopping list";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(3, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(894, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createShoppingListToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // createShoppingListToolStripMenuItem
            // 
            this.createShoppingListToolStripMenuItem.Name = "createShoppingListToolStripMenuItem";
            this.createShoppingListToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.createShoppingListToolStripMenuItem.Text = "Preferences";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 525);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Meal Planner";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Button newRecipe;        
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createShoppingListToolStripMenuItem;
        private System.Windows.Forms.TextBox rNameField;
        private System.Windows.Forms.Label rNameLabel;
        private System.Windows.Forms.TextBox iNameField;
        private System.Windows.Forms.Label iNameLabel;
        private System.Windows.Forms.Label rErrorLabel;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn qtyCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn uomCol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox recipeSearch;
        private System.Windows.Forms.Panel recipeListPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox ingredientUOM;
        private System.Windows.Forms.Panel ingredientListPanel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox ingredientSearch;
        private System.Windows.Forms.Button newIngredient;
        private System.Windows.Forms.Button addIngredient;
        private System.Windows.Forms.Button removeRecipe;
        private System.Windows.Forms.Button delIngredient;
        private System.Windows.Forms.Button removeIngredient;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox shopSearch;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button refreshButton;
        private System.Windows.Forms.Panel shoppingPanel;
        private System.Windows.Forms.Panel recipePanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button listRemove;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox recipeType;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox cmbRecipeType;
        private System.Windows.Forms.Label label7;
    }
}

