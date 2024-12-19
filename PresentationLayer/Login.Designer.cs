namespace PresentationLayer
{
    partial class Login
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
            button1 = new Button();
            txtUsername = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtPassword = new TextBox();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(202, 164);
            button1.Name = "button1";
            button1.Size = new Size(106, 23);
            button1.TabIndex = 0;
            button1.Text = "Iniciar Sesion";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // txtUsername
            // 
            txtUsername.Location = new Point(20, 45);
            txtUsername.Name = "txtUsername";
            txtUsername.Size = new Size(288, 23);
            txtUsername.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(20, 21);
            label1.Name = "label1";
            label1.Size = new Size(47, 15);
            label1.TabIndex = 2;
            label1.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 96);
            label2.Name = "label2";
            label2.Size = new Size(67, 15);
            label2.TabIndex = 3;
            label2.Text = "Contraseña";
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(20, 121);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(288, 23);
            txtPassword.TabIndex = 4;
            txtPassword.UseSystemPasswordChar = true;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(334, 211);
            Controls.Add(txtPassword);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtUsername);
            Controls.Add(button1);
            Name = "Login";
            Text = "Login";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox txtUsername;
        private Label label1;
        private Label label2;
        private TextBox txtPassword;
    }
}