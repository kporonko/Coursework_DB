using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace Cities
{
    public partial class Form1 : Form
    {
        //readonly MaterialSkin.MaterialSkinManager materialSkinManager;
        public Form1()
        {
            InitializeComponent();
            //materialSkinManager = MaterialSkin.MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkin.MaterialSkinManager.Themes.LIGHT;
            //materialSkinManager.ColorScheme = new MaterialSkin.ColorScheme(MaterialSkin.Primary.Indigo500, MaterialSkin.Primary.Indigo700, MaterialSkin.Primary.Yellow600, MaterialSkin.Accent.Pink200, MaterialSkin.TextShade.BLACK);
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
