using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsKyotoDesk
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }        

        private void button1_Click(object sender, EventArgs e)
        {
            RemoveControl();
            var userControl = new UserControlClient();
            userControl.Location = new Point(226, 56);
            this.Controls.Add(userControl);
            userControl.Visible = true;
            button1.BackColor = Color.FromArgb(39, 39, 58);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            RemoveControl();
            var userControl = new UserControlProduct();
            userControl.Location = new Point(226, 56);
            this.Controls.Add(userControl);
            userControl.Visible = true;
            button2.BackColor = Color.FromArgb(39, 39, 58);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RemoveControl();
            var userControl = new UserControlSale();
            userControl.Location = new Point(226, 56);
            this.Controls.Add(userControl);
            userControl.Visible = true;
            button3.BackColor = Color.FromArgb(39, 39, 58);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            RemoveControl();
            var userControl = new UserControlReport();
            userControl.Location = new Point(226, 56);
            this.Controls.Add(userControl);
            userControl.Visible = true;
            button4.BackColor = Color.FromArgb(39, 39, 58);
        }

        //Remove os UsersControl da Tela
        private void RemoveControl()
        {
            foreach (Control control in this.Controls)
            {
                if (control is UserControl)
                {
                    this.Controls.Remove(control);
                }
            }
            button1.BackColor = Color.FromArgb(51, 51, 76);
            button2.BackColor = Color.FromArgb(51, 51, 76);
            button3.BackColor = Color.FromArgb(51, 51, 76);
            button4.BackColor = Color.FromArgb(51, 51, 76);
        }

    }
}
