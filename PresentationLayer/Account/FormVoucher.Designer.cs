namespace PresentationLayer
{
    partial class FormVoucher
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            groupBox5 = new GroupBox();
            dataGridView2 = new DataGridView();
            groupBox6 = new GroupBox();
            searchBtn = new Button();
            txtNameSearch = new TextBox();
            label17 = new Label();
            groupBox4 = new GroupBox();
            selectNameDelete = new ComboBox();
            btnEliminarAccount = new Button();
            label14 = new Label();
            groupBox3 = new GroupBox();
            dateVoucherEdit = new DateTimePicker();
            comboBox1 = new ComboBox();
            btnEditAccount = new Button();
            txtDescriptionEdit = new TextBox();
            label8 = new Label();
            label11 = new Label();
            txtTypeVoucherEdit = new TextBox();
            label10 = new Label();
            label9 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox1 = new GroupBox();
            dateVoucherCreate = new DateTimePicker();
            txtNumerationCreate = new TextBox();
            txtDescriptionCreate = new TextBox();
            label6 = new Label();
            btnCreateVoucher = new Button();
            txtTypeVoucherCreate = new TextBox();
            label7 = new Label();
            label5 = new Label();
            label4 = new Label();
            panel3 = new Panel();
            label3 = new Label();
            panel2 = new Panel();
            button6 = new Button();
            button5 = new Button();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            panel1 = new Panel();
            label2 = new Label();
            label1 = new Label();
            menuStrip1 = new MenuStrip();
            groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox6.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            groupBox1.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(dataGridView2);
            groupBox5.Location = new Point(255, 460);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(848, 160);
            groupBox5.TabIndex = 39;
            groupBox5.TabStop = false;
            groupBox5.Text = "Comprobantes registrados";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(15, 22);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(817, 126);
            dataGridView2.TabIndex = 0;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(searchBtn);
            groupBox6.Controls.Add(txtNameSearch);
            groupBox6.Controls.Add(label17);
            groupBox6.Location = new Point(826, 190);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(277, 98);
            groupBox6.TabIndex = 42;
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
            // groupBox4
            // 
            groupBox4.Controls.Add(selectNameDelete);
            groupBox4.Controls.Add(btnEliminarAccount);
            groupBox4.Controls.Add(label14);
            groupBox4.Location = new Point(826, 81);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(277, 103);
            groupBox4.TabIndex = 41;
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
            // groupBox3
            // 
            groupBox3.Controls.Add(dateVoucherEdit);
            groupBox3.Controls.Add(comboBox1);
            groupBox3.Controls.Add(btnEditAccount);
            groupBox3.Controls.Add(txtDescriptionEdit);
            groupBox3.Controls.Add(label8);
            groupBox3.Controls.Add(label11);
            groupBox3.Controls.Add(txtTypeVoucherEdit);
            groupBox3.Controls.Add(label10);
            groupBox3.Controls.Add(label9);
            groupBox3.Location = new Point(543, 81);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(277, 207);
            groupBox3.TabIndex = 40;
            groupBox3.TabStop = false;
            groupBox3.Text = "Editar cuenta";
            // 
            // dateVoucherEdit
            // 
            dateVoucherEdit.Location = new Point(71, 60);
            dateVoucherEdit.Name = "dateVoucherEdit";
            dateVoucherEdit.Size = new Size(200, 23);
            dateVoucherEdit.TabIndex = 15;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(129, 31);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(142, 23);
            comboBox1.TabIndex = 11;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
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
            // txtDescriptionEdit
            // 
            txtDescriptionEdit.Location = new Point(129, 118);
            txtDescriptionEdit.Multiline = true;
            txtDescriptionEdit.Name = "txtDescriptionEdit";
            txtDescriptionEdit.Size = new Size(142, 37);
            txtDescriptionEdit.TabIndex = 20;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 125);
            label8.Name = "label8";
            label8.Size = new Size(84, 15);
            label8.TabIndex = 19;
            label8.Text = "Observaciones";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(7, 63);
            label11.Name = "label11";
            label11.Size = new Size(38, 15);
            label11.TabIndex = 14;
            label11.Text = "Fecha";
            // 
            // txtTypeVoucherEdit
            // 
            txtTypeVoucherEdit.Location = new Point(129, 89);
            txtTypeVoucherEdit.Name = "txtTypeVoucherEdit";
            txtTypeVoucherEdit.Size = new Size(142, 23);
            txtTypeVoucherEdit.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 92);
            label10.Name = "label10";
            label10.Size = new Size(121, 15);
            label10.TabIndex = 15;
            label10.Text = "Tipo de comprobante";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(7, 35);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 16;
            label9.Text = "Numeración";
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView1);
            groupBox2.Location = new Point(255, 294);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(848, 160);
            groupBox2.TabIndex = 38;
            groupBox2.TabStop = false;
            groupBox2.Text = "Detalle de comprobantes";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(817, 126);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(dateVoucherCreate);
            groupBox1.Controls.Add(txtNumerationCreate);
            groupBox1.Controls.Add(txtDescriptionCreate);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(btnCreateVoucher);
            groupBox1.Controls.Add(txtTypeVoucherCreate);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Location = new Point(255, 81);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(282, 207);
            groupBox1.TabIndex = 37;
            groupBox1.TabStop = false;
            groupBox1.Text = "Crear comprobante";
            // 
            // dateVoucherCreate
            // 
            dateVoucherCreate.Location = new Point(73, 29);
            dateVoucherCreate.Name = "dateVoucherCreate";
            dateVoucherCreate.Size = new Size(200, 23);
            dateVoucherCreate.TabIndex = 14;
            // 
            // txtNumerationCreate
            // 
            txtNumerationCreate.Location = new Point(136, 89);
            txtNumerationCreate.Name = "txtNumerationCreate";
            txtNumerationCreate.Size = new Size(137, 23);
            txtNumerationCreate.TabIndex = 13;
            // 
            // txtDescriptionCreate
            // 
            txtDescriptionCreate.Location = new Point(136, 118);
            txtDescriptionCreate.Multiline = true;
            txtDescriptionCreate.Name = "txtDescriptionCreate";
            txtDescriptionCreate.Size = new Size(137, 37);
            txtDescriptionCreate.TabIndex = 12;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(9, 125);
            label6.Name = "label6";
            label6.Size = new Size(84, 15);
            label6.TabIndex = 11;
            label6.Text = "Observaciones";
            // 
            // btnCreateVoucher
            // 
            btnCreateVoucher.Location = new Point(160, 168);
            btnCreateVoucher.Name = "btnCreateVoucher";
            btnCreateVoucher.Size = new Size(113, 23);
            btnCreateVoucher.TabIndex = 8;
            btnCreateVoucher.Text = "Crear Cuenta";
            btnCreateVoucher.UseVisualStyleBackColor = true;
            btnCreateVoucher.Click += btnCreateVoucher_Click;
            // 
            // txtTypeVoucherCreate
            // 
            txtTypeVoucherCreate.Location = new Point(136, 60);
            txtTypeVoucherCreate.Name = "txtTypeVoucherCreate";
            txtTypeVoucherCreate.Size = new Size(137, 23);
            txtTypeVoucherCreate.TabIndex = 5;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(9, 92);
            label7.Name = "label7";
            label7.Size = new Size(73, 15);
            label7.TabIndex = 3;
            label7.Text = "Numeración";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(9, 63);
            label5.Name = "label5";
            label5.Size = new Size(121, 15);
            label5.TabIndex = 1;
            label5.Text = "Tipo de comprobante";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(9, 35);
            label4.Name = "label4";
            label4.Size = new Size(38, 15);
            label4.TabIndex = 0;
            label4.Text = "Fecha";
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(label3);
            panel3.Location = new Point(232, 43);
            panel3.Name = "panel3";
            panel3.Size = new Size(886, 32);
            panel3.TabIndex = 36;
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
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(0, 41);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 597);
            panel2.TabIndex = 35;
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
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(0, -3);
            panel1.Name = "panel1";
            panel1.Size = new Size(1118, 59);
            panel1.TabIndex = 34;
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
            // menuStrip1
            // 
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1118, 24);
            menuStrip1.TabIndex = 33;
            menuStrip1.Text = "menuStrip1";
            // 
            // FormVoucher
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 635);
            Controls.Add(groupBox5);
            Controls.Add(groupBox6);
            Controls.Add(groupBox4);
            Controls.Add(groupBox3);
            Controls.Add(groupBox2);
            Controls.Add(groupBox1);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Name = "FormVoucher";
            Text = "Voucher";
            Load += FormVoucher_Load;
            groupBox5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox groupBox5;
        private DataGridView dataGridView2;
        private GroupBox groupBox6;
        private Button searchBtn;
        private TextBox txtNameSearch;
        private Label label17;
        private GroupBox groupBox4;
        private ComboBox selectNameDelete;
        private Button btnEliminarAccount;
        private Label label14;
        private GroupBox groupBox3;
        private ComboBox comboBox1;
        private Button btnEditAccount;
        private TextBox txtDescriptionEdit;
        private Label label8;
        private Label label11;
        private TextBox txtTypeVoucherEdit;
        private Label label10;
        private Label label9;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private GroupBox groupBox1;
        private TextBox txtNumerationCreate;
        private TextBox txtDescriptionCreate;
        private Label label6;
        private Button btnCreateVoucher;
        private TextBox txtTypeVoucherCreate;
        private Label label7;
        private Label label5;
        private Label label4;
        private Panel panel3;
        private Label label3;
        private Panel panel2;
        private Button button6;
        private Button button5;
        private Button button4;
        private Button button3;
        private Button button2;
        private Panel panel1;
        private Label label2;
        private Label label1;
        private MenuStrip menuStrip1;
        private DateTimePicker dateVoucherCreate;
        private DateTimePicker dateVoucherEdit;
    }
}