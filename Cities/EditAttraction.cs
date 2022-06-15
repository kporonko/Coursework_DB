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
    public partial class EditAttraction : Form
    {
        bool edit = false;
        int idh;
        int ids;
        public const string ConnectionString = @"Data Source=DESKTOP-7HK7ORN\SQLSERVER;Initial Catalog=Kursova;Integrated Security=True";

        public EditAttraction()
        {
            InitializeComponent();
            attractionTableAdapter1.Fill(kursovaDataSet1.Attraction);
            button1.Visible = false;
            button2.Visible = true;
        }
        public EditAttraction(int attr_id, string attrName, string date, string meanin, string height, int house_id) : this()
        {
            edit = true;
            textBox1.Text = attr_id.ToString();
            textBox2.Text = attrName.ToString();
            textBox3.Text = date;
            textBox4.Text = meanin;
            textBox5.Text = height;
            
            button2.Visible = false;
            button1.Visible = true;
            
            idh = Convert.ToInt32(house_id);
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            string zapros = $"select house.street_id from house where house_id = {idh}";
            SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            string str = dt.Rows[0][0].ToString();
            ids = Convert.ToInt32(str);

            sqlconn.Close();

            //label5.Text = 
        }

        private void EditAttraction_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet1.House". При необходимости она может быть перемещена или удалена.
            this.houseTableAdapter.Fill(this.kursovaDataSet1.House);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet1.Street". При необходимости она может быть перемещена или удалена.
            this.streetTableAdapter.Fill(this.kursovaDataSet1.Street);

            if (edit)
            {
                comboBox1.SelectedValue = ids;
                comboBox2.SelectedValue = idh;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                attractionTableAdapter1.InsertQuery(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToInt32(comboBox2.SelectedValue));

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string str;
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                string zaprosToNorm = $"select * from street where street_name = '{comboBox1.Text}'";
                SqlDataAdapter oda = new SqlDataAdapter(zaprosToNorm, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                string idstr = dt.Rows[0][0].ToString();
                sqlconn.Close();


                string zapros = $"select house_id from house where house_number = {Convert.ToInt32(comboBox2.Text)} and street_id = {Convert.ToInt32(idstr)}";
                SqlDataAdapter oda2 = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt2 = new DataTable();
                oda2.Fill(dt2);
                try
                {
                     str = dt2.Rows[0][0].ToString();

                }
                catch (Exception)
                {
                    MessageBox.Show("Дому на такій вулиці не існує");
                    return;
                }
                


                sqlconn.Close();
                attractionTableAdapter1.UpdateQuery(Convert.ToInt32(textBox1.Text), textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text, Convert.ToInt32(str));
                attractionTableAdapter1.Update(kursovaDataSet1);
                this.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
        }
    }
}
