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
    public partial class EditQZ : Form
    {
        bool edit = false;
        public EditQZ()
        {
            InitializeComponent();
            quarantine_ZoneTableAdapter1.Fill(kursovaDataSet1.Quarantine_Zone);
            button1.Visible = false;
            button2.Visible = true;
        }
        public EditQZ(string name, string res) : this()
        {
            edit = true;
            textBox1.Text = name;
            textBox2.Text = res;

            button2.Visible = false;
            button1.Visible = true;

        }

        private void EditQZ_Load(object sender, EventArgs e)
        {
            this.quarantine_ZoneTableAdapter1.Fill(this.kursovaDataSet1.Quarantine_Zone);

        }
        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                quarantine_ZoneTableAdapter1.InsertQuery(textBox1.Text, textBox2.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                quarantine_ZoneTableAdapter1.UpdateQuery(textBox1.Text, textBox2.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }
    }
}
