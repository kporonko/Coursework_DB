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
    public partial class Picture : Form
    {
        public Picture(string name)
        {
            
            InitializeComponent();
            if(name == "Харків")
            {
                pictureBox1.Image = Properties.Resources._1025929240;
            }
            else if(name == "Одеса")
            {
                pictureBox1.Image = Properties.Resources.picturepicture_15741979933266112278035_32336 ;

            }
            else if (name == "Київ")
            {
                pictureBox1.Image = Properties.Resources._7c632743_9a05_4f4a_8056_7c99a3719dbf;

            }

        }
        public Picture()
        {
            InitializeComponent();

        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
