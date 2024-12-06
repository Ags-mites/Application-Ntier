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
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            button7 = new Button();
            textBox6 = new TextBox();
            textBox5 = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            groupBox2 = new GroupBox();
            dataGridView1 = new DataGridView();
            groupBox3 = new GroupBox();
            comboBox3 = new ComboBox();
            comboBox4 = new ComboBox();
            button1 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            label10 = new Label();
            label11 = new Label();
            groupBox4 = new GroupBox();
            comboBox5 = new ComboBox();
            button8 = new Button();
            label14 = new Label();
            label15 = new Label();
            textBox4 = new TextBox();
            groupBox6 = new GroupBox();
            button10 = new Button();
            textBox7 = new TextBox();
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
            label1.Click += label1_Click;
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
            button6.Location = new Point(26, 535);
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
            groupBox1.Controls.Add(comboBox2);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(button7);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(textBox5);
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
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(127, 118);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(137, 23);
            comboBox2.TabIndex = 10;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(127, 86);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(137, 23);
            comboBox1.TabIndex = 9;
            // 
            // button7
            // 
            button7.Location = new Point(151, 170);
            button7.Name = "button7";
            button7.Size = new Size(113, 23);
            button7.TabIndex = 8;
            button7.Text = "Crear Cuenta";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(127, 57);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(137, 23);
            textBox6.TabIndex = 5;
            // 
            // textBox5
            // 
            textBox5.Location = new Point(127, 27);
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(137, 23);
            textBox5.TabIndex = 4;
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
            groupBox2.Location = new Point(255, 356);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(848, 264);
            groupBox2.TabIndex = 10;
            groupBox2.TabStop = false;
            groupBox2.Text = "Cuentas registradas";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(15, 22);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(817, 236);
            dataGridView1.TabIndex = 0;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(comboBox3);
            groupBox3.Controls.Add(comboBox4);
            groupBox3.Controls.Add(button1);
            groupBox3.Controls.Add(textBox1);
            groupBox3.Controls.Add(textBox2);
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
            // comboBox3
            // 
            comboBox3.FormattingEnabled = true;
            comboBox3.Location = new Point(111, 121);
            comboBox3.Name = "comboBox3";
            comboBox3.Size = new Size(142, 23);
            comboBox3.TabIndex = 10;
            // 
            // comboBox4
            // 
            comboBox4.FormattingEnabled = true;
            comboBox4.Location = new Point(111, 91);
            comboBox4.Name = "comboBox4";
            comboBox4.Size = new Size(142, 23);
            comboBox4.TabIndex = 9;
            // 
            // button1
            // 
            button1.Location = new Point(135, 170);
            button1.Name = "button1";
            button1.Size = new Size(118, 23);
            button1.TabIndex = 8;
            button1.Text = "Editar Cuenta";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(111, 57);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(142, 23);
            textBox1.TabIndex = 5;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(111, 27);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(142, 23);
            textBox2.TabIndex = 4;
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
            groupBox4.Controls.Add(comboBox5);
            groupBox4.Controls.Add(button8);
            groupBox4.Controls.Add(textBox4);
            groupBox4.Controls.Add(label14);
            groupBox4.Controls.Add(label15);
            groupBox4.Location = new Point(826, 96);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(277, 144);
            groupBox4.TabIndex = 12;
            groupBox4.TabStop = false;
            groupBox4.Text = "Eliminar cuenta";
            // 
            // comboBox5
            // 
            comboBox5.FormattingEnabled = true;
            comboBox5.Location = new Point(111, 62);
            comboBox5.Name = "comboBox5";
            comboBox5.Size = new Size(142, 23);
            comboBox5.TabIndex = 10;
            // 
            // button8
            // 
            button8.Location = new Point(135, 109);
            button8.Name = "button8";
            button8.Size = new Size(118, 23);
            button8.TabIndex = 8;
            button8.Text = "Editar Cuenta";
            button8.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(15, 65);
            label14.Name = "label14";
            label14.Size = new Size(51, 15);
            label14.TabIndex = 1;
            label14.Text = "Nombre";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(15, 35);
            label15.Name = "label15";
            label15.Size = new Size(46, 15);
            label15.TabIndex = 0;
            label15.Text = "Código";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(111, 27);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(142, 23);
            textBox4.TabIndex = 4;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(button10);
            groupBox6.Controls.Add(textBox7);
            groupBox6.Controls.Add(label17);
            groupBox6.Location = new Point(826, 246);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(277, 115);
            groupBox6.TabIndex = 14;
            groupBox6.TabStop = false;
            groupBox6.Text = "Buscar cuenta";
            // 
            // button10
            // 
            button10.Location = new Point(135, 67);
            button10.Name = "button10";
            button10.Size = new Size(118, 23);
            button10.TabIndex = 8;
            button10.Text = "Editar Cuenta";
            button10.UseVisualStyleBackColor = true;
            // 
            // textBox7
            // 
            textBox7.Location = new Point(111, 27);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(142, 23);
            textBox7.TabIndex = 4;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(15, 35);
            label17.Name = "label17";
            label17.Size = new Size(46, 15);
            label17.TabIndex = 0;
            label17.Text = "Código";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1118, 632);
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
        private Button button7;
        private TextBox textBox6;
        private TextBox textBox5;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label4;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private GroupBox groupBox2;
        private DataGridView dataGridView1;
        private GroupBox groupBox3;
        private ComboBox comboBox3;
        private ComboBox comboBox4;
        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label label8;
        private Label label9;
        private Label label10;
        private Label label11;
        private GroupBox groupBox4;
        private ComboBox comboBox5;
        private Button button8;
        private TextBox textBox4;
        private Label label14;
        private Label label15;
        private GroupBox groupBox6;
        private Button button10;
        private TextBox textBox7;
        private Label label17;
    }
}
