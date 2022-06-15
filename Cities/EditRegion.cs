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
    public partial class EditRegion : Form
    {
        bool edit = false;
        string qz;
        string part;
        public EditRegion()
        {
            InitializeComponent();
            regionTableAdapter1.Fill(kursovaDataSet.Region);
            button1.Visible = false;
            button2.Visible = true;
        }
        public EditRegion(string name, string area, string lang, string admc, string webs, string bud, string code, string counc, string namecounc, string qz, string part) : this()
        {
            edit = true;
            textBox1.Text = name;
            textBox2.Text = area;
            textBox3.Text = lang;
            textBox4.Text = admc;
            textBox5.Text = webs;
            textBox6.Text = bud;
            textBox7.Text = code;
            textBox8.Text = counc;
            textBox9.Text = namecounc;
            this.qz = qz;
            this.part = part;
            button2.Visible = false;
            button1.Visible = true;
            //label5.Text = 
        }

        private void EditRegion_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Part_Of_Ukraine". При необходимости она может быть перемещена или удалена.
            this.part_Of_UkraineTableAdapter.Fill(this.kursovaDataSet.Part_Of_Ukraine);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Quarantine_Zone". При необходимости она может быть перемещена или удалена.
            this.quarantine_ZoneTableAdapter.Fill(this.kursovaDataSet.Quarantine_Zone);
            if (edit)
            {
                comboBox1.SelectedValue = qz;
                comboBox2.SelectedValue = part;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                regionTableAdapter1.UpdateQuery(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text,textBox7.Text,textBox8.Text,textBox9.Text,comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString());

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                regionTableAdapter1.InsertQuery(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, comboBox1.SelectedValue.ToString(), comboBox2.SelectedValue.ToString());

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }
    }
}
