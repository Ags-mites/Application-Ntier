namespace PresentationLayer.Facturacion
{
    partial class Ciudad
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
            Cliente = new Button();
            button1 = new Button();
            txtNombreCiudad = new TextBox();
            txtCodigoCiudad = new TextBox();
            label15 = new Label();
            label16 = new Label();
            comboBoxCodigoEditar = new ComboBox();
            button7 = new Button();
            txtNombreCiudadEditar = new TextBox();
            groupBox5 = new GroupBox();
            label18 = new Label();
            groupBox7 = new GroupBox();
            label19 = new Label();
            button8 = new Button();
            txtBuscarCiudad = new TextBox();
            label12 = new Label();
            groupBox8 = new GroupBox();
            comboBoxNombreEliminar = new ComboBox();
            button9 = new Button();
            label13 = new Label();
            button11 = new Button();
            button10 = new Button();
            groupBox9 = new GroupBox();
            button13 = new Button();
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
            dataGridView2 = new DataGridView();
            groupBox2 = new GroupBox();
            groupBox5.SuspendLayout();
            groupBox7.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox9.SuspendLayout();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            groupBox2.SuspendLayout();
            SuspendLayout();
            // 
            // Cliente
            // 
            Cliente.Location = new Point(8, 3);
            Cliente.Name = "Cliente";
            Cliente.Size = new Size(75, 23);
            Cliente.TabIndex = 3;
            Cliente.Text = "Cliente";
            Cliente.UseVisualStyleBackColor = true;
            Cliente.Click += Cliente_Click;
            // 
            // button1
            // 
            button1.Location = new Point(134, 86);
            button1.Name = "button1";
            button1.Size = new Size(113, 23);
            button1.TabIndex = 8;
            button1.Text = "Crear Cuenta";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // txtNombreCiudad
            // 
            txtNombreCiudad.Location = new Point(110, 57);
            txtNombreCiudad.Name = "txtNombreCiudad";
            txtNombreCiudad.Size = new Size(137, 23);
            txtNombreCiudad.TabIndex = 5;
            // 
            // txtCodigoCiudad
            // 
            txtCodigoCiudad.Location = new Point(110, 28);
            txtCodigoCiudad.Name = "txtCodigoCiudad";
            txtCodigoCiudad.Size = new Size(137, 23);
            txtCodigoCiudad.TabIndex = 4;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(15, 65);
            label15.Name = "label15";
            label15.Size = new Size(51, 15);
            label15.TabIndex = 1;
            label15.Text = "Nombre";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(15, 35);
            label16.Name = "label16";
            label16.Size = new Size(46, 15);
            label16.TabIndex = 0;
            label16.Text = "Código";
            // 
            // comboBoxCodigoEditar
            // 
            comboBoxCodigoEditar.FormattingEnabled = true;
            comboBoxCodigoEditar.Location = new Point(111, 26);
            comboBoxCodigoEditar.Name = "comboBoxCodigoEditar";
            comboBoxCodigoEditar.Size = new Size(127, 23);
            comboBoxCodigoEditar.TabIndex = 11;
            // 
            // button7
            // 
            button7.Location = new Point(120, 86);
            button7.Name = "button7";
            button7.Size = new Size(118, 23);
            button7.TabIndex = 8;
            button7.Text = "Editar Cuenta";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click_1;
            // 
            // txtNombreCiudadEditar
            // 
            txtNombreCiudadEditar.Location = new Point(111, 57);
            txtNombreCiudadEditar.Name = "txtNombreCiudadEditar";
            txtNombreCiudadEditar.Size = new Size(127, 23);
            txtNombreCiudadEditar.TabIndex = 5;
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button1);
            groupBox5.Controls.Add(txtNombreCiudad);
            groupBox5.Controls.Add(txtCodigoCiudad);
            groupBox5.Controls.Add(label15);
            groupBox5.Controls.Add(label16);
            groupBox5.Location = new Point(255, 102);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(247, 114);
            groupBox5.TabIndex = 33;
            groupBox5.TabStop = false;
            groupBox5.Text = "Agregar Ciudad";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(15, 65);
            label18.Name = "label18";
            label18.Size = new Size(51, 15);
            label18.TabIndex = 1;
            label18.Text = "Nombre";
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(comboBoxCodigoEditar);
            groupBox7.Controls.Add(button7);
            groupBox7.Controls.Add(txtNombreCiudadEditar);
            groupBox7.Controls.Add(label18);
            groupBox7.Controls.Add(label19);
            groupBox7.Location = new Point(543, 110);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(255, 111);
            groupBox7.TabIndex = 37;
            groupBox7.TabStop = false;
            groupBox7.Text = "Editar ciudad";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(15, 35);
            label19.Name = "label19";
            label19.Size = new Size(46, 15);
            label19.TabIndex = 0;
            label19.Text = "Código";
            // 
            // button8
            // 
            button8.Location = new Point(120, 69);
            button8.Name = "button8";
            button8.Size = new Size(118, 23);
            button8.TabIndex = 8;
            button8.Text = "Buscar Cuenta";
            button8.UseVisualStyleBackColor = true;
            button8.Click += button8_Click_1;
            // 
            // txtBuscarCiudad
            // 
            txtBuscarCiudad.Location = new Point(111, 27);
            txtBuscarCiudad.Name = "txtBuscarCiudad";
            txtBuscarCiudad.Size = new Size(127, 23);
            txtBuscarCiudad.TabIndex = 4;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(15, 35);
            label12.Name = "label12";
            label12.Size = new Size(51, 15);
            label12.TabIndex = 0;
            label12.Text = "Nombre";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(button8);
            groupBox8.Controls.Add(txtBuscarCiudad);
            groupBox8.Controls.Add(label12);
            groupBox8.Location = new Point(1105, 123);
            groupBox8.Name = "groupBox8";
            groupBox8.Size = new Size(253, 98);
            groupBox8.TabIndex = 40;
            groupBox8.TabStop = false;
            groupBox8.Text = "Buscar ciudad";
            // 
            // comboBoxNombreEliminar
            // 
            comboBoxNombreEliminar.FormattingEnabled = true;
            comboBoxNombreEliminar.Location = new Point(111, 26);
            comboBoxNombreEliminar.Name = "comboBoxNombreEliminar";
            comboBoxNombreEliminar.Size = new Size(126, 23);
            comboBoxNombreEliminar.TabIndex = 10;
            // 
            // button9
            // 
            button9.Location = new Point(119, 55);
            button9.Name = "button9";
            button9.Size = new Size(118, 23);
            button9.TabIndex = 8;
            button9.Text = "Eliminar Cuenta";
            button9.UseVisualStyleBackColor = true;
            button9.Click += button9_Click_1;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(15, 29);
            label13.Name = "label13";
            label13.Size = new Size(51, 15);
            label13.TabIndex = 1;
            label13.Text = "Nombre";
            // 
            // button11
            // 
            button11.Location = new Point(1155, 391);
            button11.Name = "button11";
            button11.Size = new Size(188, 23);
            button11.TabIndex = 41;
            button11.Text = "Pantalla Compleja";
            button11.UseVisualStyleBackColor = true;
            button11.Click += button11_Click_1;
            // 
            // button10
            // 
            button10.Location = new Point(1155, 431);
            button10.Name = "button10";
            button10.Size = new Size(188, 23);
            button10.TabIndex = 27;
            button10.Text = "imprimir";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click_1;
            // 
            // groupBox9
            // 
            groupBox9.Controls.Add(comboBoxNombreEliminar);
            groupBox9.Controls.Add(button9);
            groupBox9.Controls.Add(label13);
            groupBox9.Location = new Point(835, 118);
            groupBox9.Name = "groupBox9";
            groupBox9.Size = new Size(252, 103);
            groupBox9.TabIndex = 39;
            groupBox9.TabStop = false;
            groupBox9.Text = "Eliminar ciudad";
            // 
            // button13
            // 
            button13.Location = new Point(89, 3);
            button13.Name = "button13";
            button13.Size = new Size(75, 23);
            button13.TabIndex = 4;
            button13.Text = "Ciudad";
            button13.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            panel3.BackColor = Color.White;
            panel3.Controls.Add(button13);
            panel3.Controls.Add(Cliente);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(232, 46);
            panel3.Name = "panel3";
            panel3.Size = new Size(1138, 32);
            panel3.TabIndex = 31;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F);
            label3.ForeColor = SystemColors.InactiveCaptionText;
            label3.Location = new Point(1057, 4);
            label3.Name = "label3";
            label3.Size = new Size(69, 15);
            label3.TabIndex = 2;
            label3.Text = "Facturación";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.GradientActiveCaption;
            panel2.Controls.Add(button6);
            panel2.Controls.Add(button5);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Location = new Point(0, 44);
            panel2.Name = "panel2";
            panel2.Size = new Size(234, 578);
            panel2.TabIndex = 30;
            // 
            // button6
            // 
            button6.Location = new Point(26, 504);
            button6.Name = "button6";
            button6.Size = new Size(188, 23);
            button6.TabIndex = 9;
            button6.Text = "Salir";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
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
            panel1.Location = new Point(0, -12);
            panel1.Name = "panel1";
            panel1.Size = new Size(1370, 59);
            panel1.TabIndex = 29;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(1166, 21);
            label2.Name = "label2";
            label2.Size = new Size(61, 21);
            label2.TabIndex = 1;
            label2.Text = "Admin";
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
            menuStrip1.Size = new Size(1370, 24);
            menuStrip1.TabIndex = 28;
            menuStrip1.Text = "menuStrip1";
            // 
            // dataGridView2
            // 
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Location = new Point(15, 35);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.Size = new Size(817, 239);
            dataGridView2.TabIndex = 1;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(dataGridView2);
            groupBox2.Location = new Point(255, 297);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(848, 291);
            groupBox2.TabIndex = 34;
            groupBox2.TabStop = false;
            groupBox2.Text = "Ciudades Registradas";
            // 
            // Ciudad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 610);
            Controls.Add(groupBox5);
            Controls.Add(groupBox7);
            Controls.Add(groupBox8);
            Controls.Add(button11);
            Controls.Add(button10);
            Controls.Add(groupBox9);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            Controls.Add(groupBox2);
            Name = "Ciudad";
            Text = "Ciudad";
            Load += Ciudad_Load;
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox9.ResumeLayout(false);
            groupBox9.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel2.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            groupBox2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
            this.selectTypeCreate = new System.Windows.Forms.ComboBox();
            this.selectStatusCreate = new System.Windows.Forms.ComboBox();
        }

        #endregion

        private Button Cliente;
        private Button button1;
        private TextBox txtNombreCiudad;
        private TextBox txtCodigoCiudad;
        private Label label15;
        private Label label16;
        private ComboBox comboBoxCodigoEditar;
        private Button button7;
        private TextBox txtNombreCiudadEditar;
        private GroupBox groupBox5;
        private Label label18;
        private GroupBox groupBox7;
        private Label label19;
        private Button button8;
        private TextBox txtBuscarCiudad;
        private Label label12;
        private GroupBox groupBox8;
        private ComboBox comboBoxNombreEliminar;
        private Button button9;
        private Label label13;
        private Button button11;
        private Button button10;
        private GroupBox groupBox9;
        private Button button13;
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
        private DataGridView dataGridView2;
        private GroupBox groupBox2;
        private System.Windows.Forms.ComboBox selectTypeCreate;
        private System.Windows.Forms.ComboBox selectStatusCreate;
    }
}