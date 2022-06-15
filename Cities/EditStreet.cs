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
    public partial class EditStreet : Form
    {
        bool edit = false;
        string cname;
        public EditStreet()
        {
            InitializeComponent();
            streetTableAdapter1.Fill(kursovaDataSet1.Street);
            button1.Visible = false;
            button2.Visible = true;
        }
        public EditStreet(int id, string name, string len, string mean, string cname) : this()
        {
            edit = true;
            textBox1.Text = id.ToString();
            textBox2.Text = name;
            textBox3.Text = len;
            textBox4.Text = mean;
            comboBox1.SelectedValue = cname;
            this.cname = cname;
            button2.Visible = false;
            button1.Visible = true;
            //label5.Text = 
        }

        private void EditStreet_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet1.City". При необходимости она может быть перемещена или удалена.
            this.cityTableAdapter.Fill(this.kursovaDataSet1.City);
            if (edit)
            {
                comboBox1.SelectedValue = cname;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                streetTableAdapter1.InsertQuery(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text);

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
                streetTableAdapter1.UpdateQuery(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, comboBox1.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }
    }
}
