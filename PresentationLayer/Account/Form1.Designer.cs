namespace PresentationLayer
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            menuStrip1 = new MenuStrip();
            contextMenuStrip1 = new ContextMenuStrip(components);
            oracleCommand1 = new Oracle.ManagedDataAccess.Client.OracleCommand();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            panel3 = new Panel();
            label3 = new Label();
            groupBox1 = new GroupBox();
            selectStatusCreate = new ComboBox();
            selectTypeCreate = new ComboBox();
            btnCreateAccount = new Button();
            txtNameCreate = new TextBox();
            txtCodCreate = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox3 = new GroupBox();
            selectCodEdit = new ComboBox();
            selectStatusEdit = new ComboBox();
            selectTypeEdit = new ComboBox();
            btnEditAccount = new Button();
            txtNameEdit = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            groupBox4 = new GroupBox();
            selectNameDelete = new ComboBox();
            btnEliminarAccount = new Button();
            label14 = new Label();
            groupBox6 = new GroupBox();
            searchBtn = new Button();
            txtNameSearch = new TextBox();
            label17 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1118, 24);
            menuStrip1.TabIndex = 5;
            menuStrip1.Text = "menuStrip1";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // oracleCommand1
            // 
            oracleCommand1.Transaction = null;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1118, 59);
            panel1.TabIndex = 6;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1034, 21);
            label2.Name = "label2";
            label2.Size = new Size(69, 21);
            label2.TabIndex = 1;
            label2.Text = "Usuario";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BorderStyle = BorderStyle.FixedSingle;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            label1.ForeColor = Color.Azure;
            label1.Location = new Point(26, 15);
            label1.Name = "label1";
            label1.Size = new Size(111, 27);
            label1.TabIndex = 0;
            label1.Text = "Dashboard";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(0, 56);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 578);
            panel2.TabIndex = 7;
            // 
            // button6
            // 
            button6.Location = new Point(26, 504);
            button6.Name = "button6";
            button6.Size = new Size(188, 23);
            button6.TabIndex = 9;
            button6.Text = "Salir";
            button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(26, 149);
            button5.Name = "button5";
            button5.Size = new Size(188, 23);
            button5.TabIndex = 11;
            button5.Text = "facturación";
            button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Location = new Point(26, 109);
            button4.Name = "button4";
            button4.Size = new Size(188, 23);
            button4.TabIndex = 10;
            button4.Text = "Selección";
            button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(26, 66);
            button3.Name = "button3";
            button3.Size = new Size(188, 23);
            button3.TabIndex = 9;
            button3.Text = "Nómina";
            button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(26, 22);
            button2.Name = "button2";
            button2.Size = new Size(188, 23);
            button2.TabIndex = 8;
            button2.Text = "Contabilidad";
            button2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label3);
            panel3.Location = new Point(232, 58);
            panel3.Name = "panel3";
            panel3.Size = new Size(886, 32);
            panel3.TabIndex = 8;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = SystemColors.InactiveCaptionText;
            label3.Location = new Point(796, 8);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 2;
            label3.Text = "Contabilidad";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(selectStatusCreate);
            groupBox1.Controls.Add(selectTypeCreate);
            groupBox1.Controls.Add(btnCreateAccount);
            groupBox1.Controls.Add(txtNameCreate);
            groupBox1.Controls.Add(txtCodCreate);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(255, 96);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(282, 207);
            groupBox1.TabIndex = 9;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear Cuenta";
            // 
            // selectStatusCreate
            // 
            selectStatusCreate.FormattingEnabled = true;
            selectStatusCreate.Location = new Point(127, 118);
            selectStatusCreate.Name = "selectStatusCreate";
            selectStatusCreate.Size = new Size(137, 23);
            selectStatusCreate.TabIndex = 10;
            // 
            // selectTypeCreate
            // 
            selectTypeCreate.FormattingEnabled = true;
            selectTypeCreate.Location = new Point(127, 86);
            selectTypeCreate.Name = "selectTypeCreate";
            selectTypeCreate.Size = new Size(137, 23);
            selectTypeCreate.TabIndex = 9;
            // 
            // btnCreateAccount
            // 
            btnCreateAccount.Location = new Point(151, 170);
            btnCreateAccount.Name = "btnCreateAccount";
            btnCreateAccount.Size = new Size(113, 23);
            btnCreateAccount.TabIndex = 8;
            btnCreateAccount.Text = "Crear Cuenta";
            btnCreateAccount.UseVisualStyleBackColor = true;
            btnCreateAccount.Click += button7_Click;
            // 
            // txtNameCreate
            // 
            txtNameCreate.Location = new Point(127, 57);
            txtNameCreate.Name = "txtNameCreate";
            txtNameCreate.Size = new Size(137, 23);
            txtNameCreate.TabIndex = 5;
            // 
            // txtCodCreate
            // 
            txtCodCreate.Location = new Point(127, 27);
            txtCodCreate.Name = "txtCodCreate";
            txtCodCreate.Size = new Size(137, 23);
            txtCodCreate.TabIndex = 4;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(15, 121);
            label7.Name = "label7";
            label7.Size = new Size(66, 15);
            label7.TabIndex = 3;
            label7.Text = "Disponible:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(15, 89);
            label6.Name = "label6";
            label6.Size = new Size(85, 15);
            label6.TabIndex = 2;
            label6.Text = "Tipo de cuenta";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 65);
            label5.Name = "label5";
            label5.Size = new Size(51, 15);
            label5.TabIndex = 1;
            label5.Text = "Nombre";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(15, 35);
            label4.Name = "label4";
            label4.Size = new Size(46, 15);
            label4.TabIndex = 0;
            label4.Text = "Código";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(255, 309);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(848, 291);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cuentas registradas";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(817, 263);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(selectCodEdit);
            groupBox3.Controls.Add(selectStatusEdit);
            groupBox3.Controls.Add(selectTypeEdit);
            groupBox3.Controls.Add(btnEditAccount);
            groupBox3.Controls.Add(txtNameEdit);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label9);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label11);
            groupBox3.Location = new Point(543, 96);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(277, 207);
            groupBox3.TabIndex = 11;
            groupBox3.TabStop = false;
            groupBox3.Text = "Editar cuenta";
            // 
            // selectCodEdit
            // 
            selectCodEdit.FormattingEnabled = true;
            selectCodEdit.Location = new Point(111, 26);
            selectCodEdit.Name = "selectCodEdit";
            selectCodEdit.Size = new Size(142, 23);
            selectCodEdit.TabIndex = 11;
            // 
            // selectStatusEdit
            // 
            selectStatusEdit.FormattingEnabled = true;
            selectStatusEdit.Location = new Point(111, 121);
            selectStatusEdit.Name = "selectStatusEdit";
            selectStatusEdit.Size = new Size(142, 23);
            selectStatusEdit.TabIndex = 10;
            // 
            // selectTypeEdit
            // 
            selectTypeEdit.FormattingEnabled = true;
            selectTypeEdit.Location = new Point(111, 91);
            selectTypeEdit.Name = "selectTypeEdit";
            selectTypeEdit.Size = new Size(142, 23);
            selectTypeEdit.TabIndex = 9;
            // 
            // btnEditAccount
            // 
            btnEditAccount.Location = new Point(135, 170);
            btnEditAccount.Name = "btnEditAccount";
            btnEditAccount.Size = new Size(118, 23);
            btnEditAccount.TabIndex = 8;
            btnEditAccount.Text = "Editar Cuenta";
            btnEditAccount.UseVisualStyleBackColor = true;
            btnEditAccount.Click += btnEditAccount_Click;
            // 
            // txtNameEdit
            // 
            txtNameEdit.Location = new Point(111, 57);
            txtNameEdit.Name = "txtNameEdit";
            txtNameEdit.Size = new Size(142, 23);
            txtNameEdit.TabIndex = 5;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(15, 124);
            label8.Name = "label8";
            label8.Size = new Size(66, 15);
            label8.TabIndex = 3;
            label8.Text = "Disponible:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(15, 94);
            label9.Name = "label9";
            label9.Size = new Size(85, 15);
            label9.TabIndex = 2;
            label9.Text = "Tipo de cuenta";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(15, 65);
            label10.Name = "label10";
            label10.Size = new Size(51, 15);
            label10.TabIndex = 1;
            label10.Text = "Nombre";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(15, 35);
            label11.Name = "label11";
            label11.Size = new Size(46, 15);
            label11.TabIndex = 0;
            label11.Text = "Código";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(selectNameDelete);
            groupBox4.Controls.Add(btnEliminarAccount);
            groupBox4.Controls.Add(label14);
            groupBox4.Location = new Point(826, 96);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(277, 103);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "Eliminar cuenta";
            // 
            // selectNameDelete
            // 
            selectNameDelete.FormattingEnabled = true;
            selectNameDelete.Location = new Point(111, 26);
            selectNameDelete.Name = "selectNameDelete";
            selectNameDelete.Size = new Size(142, 23);
            selectNameDelete.TabIndex = 10;
            // 
            // btnEliminarAccount
            // 
            btnEliminarAccount.Location = new Point(135, 65);
            btnEliminarAccount.Name = "btnEliminarAccount";
            btnEliminarAccount.Size = new Size(118, 23);
            btnEliminarAccount.TabIndex = 8;
            btnEliminarAccount.Text = "Eliminar Cuenta";
            btnEliminarAccount.UseVisualStyleBackColor = true;
            btnEliminarAccount.Click += btnEliminarAccount_Click;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(15, 29);
            label14.Name = "label14";
            label14.Size = new Size(51, 15);
            label14.TabIndex = 1;
            label14.Text = "Nombre";
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(searchBtn);
            groupBox6.Controls.Add(txtNameSearch);
            groupBox6.Controls.Add(label17);
            groupBox6.Location = new Point(826, 205);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(277, 98);
            groupBox6.TabIndex = 14;
            groupBox6.TabStop = false;
            groupBox6.Text = "Buscar cuenta";
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(135, 67);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(118, 23);
            searchBtn.TabIndex = 8;
            searchBtn.Text = "Buscar Cuenta";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // txtNameSearch
            // 
            txtNameSearch.Location = new Point(111, 27);
            txtNameSearch.Name = "txtNameSearch";
            txtNameSearch.Size = new Size(142, 23);
            txtNameSearch.TabIndex = 4;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(15, 35);
            label17.Name = "label17";
            label17.Size = new Size(51, 15);
            label17.TabIndex = 0;
            label17.Text = "Nombre";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 610);
            Controls.Add(groupBox6);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private MenuStrip menuStrip1;
        private ContextMenuStrip contextMenuStrip1;
        private Oracle.ManagedDataAccess.Client.OracleCommand oracleCommand1;
        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Panel panel3;
        private Label label3;
        private GroupBox groupBox1;
        private Button btnCreateAccount;
        private TextBox txtNameCreate;
        private TextBox txtCodCreate;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private ComboBox selectStatusCreate;
        private ComboBox selectTypeCreate;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private GroupBox groupBox3;
        private ComboBox selectStatusEdit;
        private ComboBox selectTypeEdit;
        private Button btnEditAccount;
        private TextBox txtNameEdit;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private GroupBox groupBox4;
        private Button btnEliminarAccount;
        private GroupBox groupBox6;
        private Button searchBtn;
        private TextBox txtNameSearch;
        private Label label17;
        private ComboBox selectNameDelete;
        private Label label14;
        private ComboBox selectCodEdit;
    }
}
