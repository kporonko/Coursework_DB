using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cities
{
    public partial class EditFormCity : Form
    {
        public bool edit;
        public EditFormCity()
        {
            InitializeComponent();
            cityTableAdapter.Fill(this.kursovaDataSet.City);
            regionTableAdapter.Fill(this.kursovaDataSet.Region);
            edit = false;
            button2.Visible = true;
            button1.Visible = false;
        }
        public EditFormCity(string name, int pop, string area, string date, int level, string height, string web, string fact, string weather, string rname): this()
        {
            this.regionTableAdapter.Fill(this.kursovaDataSet.Region);
            this.cityTableAdapter.Fill(this.kursovaDataSet.City);
            regionTableAdapter.Update(kursovaDataSet);
            cityTableAdapter.Update(kursovaDataSet);
            textBox1.Text = name;
            textBox2.Text = pop.ToString();
            textBox3.Text = area;
            textBox4.Text = date;

            textBox9.Text = height;
            comboBox2.Text = level.ToString();
            textBox6.Text = web;
            textBox7.Text = fact;
            textBox8.Text = weather;
            comboBox1.Text = rname;
            comboBox1.SelectedValue = rname;
            comboBox1.SelectedIndex = 2;
            label11.Text = rname;
            button2.Visible = false;
            button1.Visible = true;
        }
        private void EditFormCity_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Region". При необходимости она может быть перемещена или удалена.
            this.regionTableAdapter.Fill(this.kursovaDataSet.Region);
            this.cityTableAdapter.Fill(this.kursovaDataSet.City);
            comboBox1.SelectedValue = label11.Text;

        }
        public const string ConnectionString = @"Data Source=DESKTOP-7HK7ORN\SQLSERVER;Initial Catalog=Kursova;Integrated Security=True";
        public static string RegName(string name)
        {
            //SqlConnection cnn = new SqlConnection(ConnectionString);
            //if(cnn.State == ConnectionState.Closed)
            //{
            //    cnn.Open();
            //}
           
            //SqlCommand mycommand = new SqlCommand();
            //mycommand.CommandText = $"SELECT Region_Name From CITY WHERE City_Name = '{name}'";
            //string res = mycommand.ExecuteScalar().ToString();
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlDataAdapter oda = new SqlDataAdapter($"SELECT Region_Name From CITY WHERE City_Name = '{name}'", sqlconn);
            DataTable dt = new DataTable();
            oda.Fill(dt);

            return dt.Rows[0].ItemArray[0].ToString();

        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cityTableAdapter.UpdateQuery(textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text, textBox4.Text, Convert.ToInt32(comboBox2.Text), textBox9.Text, textBox6.Text, textBox7.Text, textBox8.Text, comboBox1.Text);
            this.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            if(comboBox2.Text == "" && comboBox1.Text == "")
            {
                int? res = 0;
                
                try
                {
                    if(textBox2.Text == "")
                    {
                        res = null;
                    }
                    else
                    {
                        res = Convert.ToInt32(textBox2.Text);
                    }
                    cityTableAdapter.InsertQuery(textBox1.Text, res, textBox3.Text, textBox4.Text,
                    null, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, comboBox1.Text);
                }
                catch (Exception)
                {

                    MessageBox.Show("Введіть назву регіону");
                }

            }
            else if(comboBox2.Text == "" && comboBox1.Text != "")
            {
                int? res = 0;
                if (textBox2.Text == "")
                {
                    res = null;
                }
                else
                {
                    res = Convert.ToInt32(textBox2.Text);
                }
                cityTableAdapter.InsertQuery(textBox1.Text, res, textBox3.Text, textBox4.Text,
                null, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, comboBox1.Text);
            }
            else if(comboBox2.Text != "" && comboBox1.Text == "")
            {
                try
                {
                    int? res = 0;
                    if (textBox2.Text == "")
                    {
                        res = null;
                    }
                    else
                    {
                        res = Convert.ToInt32(textBox2.Text);
                    }
                    cityTableAdapter.InsertQuery(textBox1.Text, res, textBox3.Text, textBox4.Text,
                    Convert.ToInt32(comboBox2.Text), textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, null);
                }
                catch (Exception)
                {

                    MessageBox.Show("Введіть назву регіону");
                }

            }
            else
            {
                int? res = 0;
                if (textBox2.Text == "")
                {
                    res = null;
                }
                else
                {
                    res = Convert.ToInt32(textBox2.Text);
                }
                cityTableAdapter.InsertQuery(textBox1.Text, res, textBox3.Text, textBox4.Text,
                null, textBox6.Text, textBox7.Text, textBox8.Text, textBox9.Text, comboBox1.Text);
            }

            this.Close();
        }
    }
}
