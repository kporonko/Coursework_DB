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
    public partial class EditFormMayor : Form
    {
        public EditFormMayor()
        {
            InitializeComponent();
            mayorTableAdapter1.Fill(kursovaDataSet1.Mayor);
            button1.Visible = false;
            button2.Visible = true;
        }
        public EditFormMayor(int id, string ln, string fn, string otch, string gen, string date, string info) : this()
        {
            textBox1.Text = id.ToString();
            textBox2.Text = ln;
            textBox3.Text = fn;
            textBox4.Text = otch;
            if(gen == "М")
            {
                comboBox2.SelectedIndex = 0;

            }
            else if (gen == "Ж")
            {
                comboBox2.SelectedIndex = 1;

            }
            //comboBox2.Text = gen;
            textBox6.Text = date;
            textBox9.Text = info;
            mayorTableAdapter1.Fill(kursovaDataSet1.Mayor);
            button2.Visible = false;
            button1.Visible = true;
        }
        private void EditFormMayor_Load(object sender, EventArgs e)
        {

        }

        private void EditFormMayor_Load_1(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                mayorTableAdapter1.UpdateQuery(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, comboBox2.Text, textBox6.Text, textBox9.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                mayorTableAdapter1.InsertQuery(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, comboBox2.Text, textBox6.Text, textBox9.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");

            }
            this.Close();
        }
    }
}
