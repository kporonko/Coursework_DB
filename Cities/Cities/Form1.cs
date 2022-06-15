using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cities
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Admin.login == textBox1.Text && Admin.password == textBox2.Text)
            {
                Admin.IsAdmin = true;
            }
            else
            {
                Admin.IsAdmin = false;
            }

           Main main = new Main();
            this.Hide();
            main.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
