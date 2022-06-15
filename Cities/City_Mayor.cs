using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cities
{
    public partial class City_Mayor : Form
    {
        public City_Mayor()
        {
            InitializeComponent();
            button2.Visible = true;
            button1.Visible = false;
            edit = false;
            comboBox1.SelectedIndex = -1;
        }
        string id;
        string isact;
        bool edit;
        public City_Mayor(string name, int id, string isact)
        {
            InitializeComponent();

            textBox1.Text = name;

            this.id = id.ToString();
            this.isact = isact;
            button1.Visible = true;
            button2.Visible = false;

            edit = true;
        }

        private void City_Mayor_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.City_Mayor". При необходимости она может быть перемещена или удалена.
            this.city_MayorTableAdapter.Fill(this.kursovaDataSet.City_Mayor);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Mayor". При необходимости она может быть перемещена или удалена.
            this.mayorTableAdapter.Fill(this.kursovaDataSet.Mayor);
            if (edit == true)
            {
                comboBox1.SelectedValue = id;
                comboBox2.Text = isact;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string zapros = $"SELECT COUNT(City_Mayor.IsActive) FROM City_Mayor WHERE City_Name = '{textBox1.Text}' AND IsActive = 'true'";
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);

                if (Convert.ToInt32(dt.Rows[0][0]) == 1 && comboBox2.Text == "true")
                {
                    MessageBox.Show("У цього міста вже є активний мер");
                    sqlconn.Close();
                    return;
                }

                city_MayorTableAdapter.UpdateQuery(textBox1.Text, Convert.ToInt32(comboBox1.Text), comboBox2.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Скорее всего мер у города уже есть");
            }
            this.Close();

        }
        public const string ConnectionString = @"Data Source=DESKTOP-7HK7ORN\SQLSERVER;Initial Catalog=Kursova;Integrated Security=True";

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string zapros = $"SELECT COUNT(City_Mayor.IsActive) FROM City_Mayor WHERE City_Name = '{textBox1.Text}' AND IsActive = 'true'";
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);


                
                if (Convert.ToInt32(dt.Rows[0][0]) == 1 && comboBox2.Text == "true")
                {
                    MessageBox.Show("У цього міста вже є активний мер");
                    sqlconn.Close();
                    return;
                }
                sqlconn.Close();
                city_MayorTableAdapter.InsertQuery(textBox1.Text,Convert.ToInt32(comboBox1.Text), comboBox2.Text);

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }
    }
}
