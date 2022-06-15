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
    public partial class EditPart : Form
    {
        bool edit = false;
        public EditPart()
        {
            InitializeComponent();
            part_Of_UkraineTableAdapter1.Fill(kursovaDataSet1.Part_Of_Ukraine);
            button1.Visible = false;
            button2.Visible = true;
        }
        public EditPart(string name, int pop, string info) : this()
        {
            edit = true;
            textBox1.Text = name;
            textBox2.Text = pop.ToString();
            textBox3.Text = info;
            button2.Visible = false;
            button1.Visible = true;

        }

        private void EditPart_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                part_Of_UkraineTableAdapter1.InsertQuery(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                part_Of_UkraineTableAdapter1.UpdateQuery(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }
    }
}
