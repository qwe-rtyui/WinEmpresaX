namespace WinFormsKyotoDesk
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
            panelMenu = new System.Windows.Forms.Panel();
            panelLogo = new System.Windows.Forms.Panel();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            userControlClient1 = new UserControlClient();
            userControlProduct1 = new UserControlProduct();
            userControlReport1 = new UserControlReport();
            userControlSale1 = new UserControlSale();
            panel1 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            SuspendLayout();
            // 
            // panelMenu
            // 
            panelMenu.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Controls.Add(button4);
            panelMenu.Controls.Add(button3);
            panelMenu.Controls.Add(button2);
            panelMenu.Controls.Add(button1);
            panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            panelMenu.Location = new System.Drawing.Point(0, 0);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new System.Drawing.Size(220, 695);
            panelMenu.TabIndex = 2;
            // 
            // panelLogo
            // 
            panelLogo.BackColor = System.Drawing.Color.FromArgb(39, 39, 58);
            panelLogo.Controls.Add(label1);
            panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            panelLogo.Location = new System.Drawing.Point(0, 0);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new System.Drawing.Size(220, 50);
            panelLogo.TabIndex = 0;
            // 
            // button4
            // 
            button4.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button4.ForeColor = System.Drawing.Color.Transparent;
            button4.Location = new System.Drawing.Point(0, 203);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(220, 43);
            button4.TabIndex = 3;
            button4.Text = "Relatórios";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button3.ForeColor = System.Drawing.Color.White;
            button3.Location = new System.Drawing.Point(0, 154);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(220, 43);
            button3.TabIndex = 2;
            button3.Text = "Realizar Venda";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button2.ForeColor = System.Drawing.Color.White;
            button2.Location = new System.Drawing.Point(0, 105);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(220, 43);
            button2.TabIndex = 1;
            button2.Text = "Gerenciar Produtos";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            button1.ForeColor = System.Drawing.Color.White;
            button1.Location = new System.Drawing.Point(0, 56);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(220, 43);
            button1.TabIndex = 4;
            button1.Text = " Gerenciar Clientes";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // userControlClient1
            // 
            userControlClient1.Location = new System.Drawing.Point(226, 56);
            userControlClient1.Name = "userControlClient1";
            userControlClient1.Size = new System.Drawing.Size(1148, 570);
            userControlClient1.TabIndex = 3;
            userControlClient1.Visible = false;
            // 
            // userControlProduct1
            // 
            userControlProduct1.Location = new System.Drawing.Point(226, 56);
            userControlProduct1.Name = "userControlProduct1";
            userControlProduct1.Size = new System.Drawing.Size(1121, 534);
            userControlProduct1.TabIndex = 4;
            userControlProduct1.Visible = false;
            // 
            // userControlReport1
            // 
            userControlReport1.Location = new System.Drawing.Point(226, 56);
            userControlReport1.Name = "userControlReport1";
            userControlReport1.Size = new System.Drawing.Size(1262, 588);
            userControlReport1.TabIndex = 5;
            userControlReport1.Visible = false;
            // 
            // userControlSale1
            // 
            userControlSale1.Location = new System.Drawing.Point(226, 56);
            userControlSale1.Name = "userControlSale1";
            userControlSale1.Size = new System.Drawing.Size(1176, 604);
            userControlSale1.TabIndex = 6;
            userControlSale1.Visible = false;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(39, 39, 58);
            panel1.Dock = System.Windows.Forms.DockStyle.Top;
            panel1.Location = new System.Drawing.Point(220, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(1194, 50);
            panel1.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.Color.White;
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(115, 30);
            label1.TabIndex = 0;
            label1.Text = "Empresa X";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.White;
            ClientSize = new System.Drawing.Size(1414, 695);
            Controls.Add(panel1);
            Controls.Add(userControlSale1);
            Controls.Add(userControlReport1);
            Controls.Add(userControlProduct1);
            Controls.Add(userControlClient1);
            Controls.Add(panelMenu);
            Name = "Form1";
            Text = "Form1";
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            panelLogo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Button button1;        
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private UserControlClient userControlClient1;
        private UserControlProduct userControlProduct1;
        private UserControlReport userControlReport1;
        private UserControlSale userControlSale1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
    }
}
