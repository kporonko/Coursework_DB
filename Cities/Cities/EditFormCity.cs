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
    public partial class EditFormCity : Form
    {
        public EditFormCity()
        {
            InitializeComponent();
            cityTableAdapter.Fill(this.kursovaDataSet.City);
            regionTableAdapter.Fill(this.kursovaDataSet.Region);
            
            
        }
        public EditFormCity(string name, int pop, string area, string date, int level, string height, string web, string fact, string weather, string rname): this()
        {
            this.regionTableAdapter.Fill(this.kursovaDataSet.Region);
            this.cityTableAdapter.Fill(this.kursovaDataSet.City);

            textBox1.Text = name;
            textBox2.Text = pop.ToString();
            textBox3.Text = area;
            textBox4.Text = date;


            comboBox2.Text = level.ToString();
            textBox6.Text = web;
            textBox7.Text = fact;
            textBox8.Text = weather;
            comboBox1.Text = rname;
            comboBox1.SelectedText = rname;
            comboBox1.SelectedValue = rname;
        }
        private void EditFormCity_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Region". При необходимости она может быть перемещена или удалена.
            this.regionTableAdapter.Fill(this.kursovaDataSet.Region);
            this.cityTableAdapter.Fill(this.kursovaDataSet.City);


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
