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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public const string ConnectionString = @"Data Source=DESKTOP-7HK7ORN\SQLSERVER;Initial Catalog=Kursova;Integrated Security=True";
        private void Main_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Street". При необходимости она может быть перемещена или удалена.
            this.streetTableAdapter.Fill(this.kursovaDataSet.Street);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Region". При необходимости она может быть перемещена или удалена.
            this.regionTableAdapter.Fill(this.kursovaDataSet.Region);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Attraction". При необходимости она может быть перемещена или удалена.
            this.attractionTableAdapter.Fill(this.kursovaDataSet.Attraction);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Mayor". При необходимости она может быть перемещена или удалена.
            this.mayorTableAdapter.Fill(this.kursovaDataSet.Mayor);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.City". При необходимости она может быть перемещена или удалена.
            this.cityTableAdapter.Fill(this.kursovaDataSet.City);
            cityTableAdapter.Update(kursovaDataSet);
            mayorTableAdapter.Update(kursovaDataSet);
            regionTableAdapter.Update(kursovaDataSet);
            attractionTableAdapter.Update(kursovaDataSet);
            streetTableAdapter.Update(kursovaDataSet);
            if (!Admin.IsAdmin)
            {
                dataGridView1.ReadOnly = true;
                dataGridView2.ReadOnly = true;
                dataGridView3.ReadOnly = true;
                dataGridView4.ReadOnly = true;
                dataGridView5.ReadOnly = true;
                button1.Visible = false;
                button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
            }
            //Zapros(ConnectionString, dataGridView1);
        }
        private void ZaprosDelete(string ConnectionString, string zapros)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                cityTableAdapter.Update(kursovaDataSet);

            }
            catch (Exception)
            {
                MessageBox.Show("Скорее всего добавили внешний ключ несовпадающий");
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                mayorTableAdapter.Update(kursovaDataSet);

            }
            catch (Exception)
            {
                MessageBox.Show("Скорее всего добавили внешний ключ несовпадающий");
            }
        }
        private void dataGridView3_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                attractionTableAdapter.Update(kursovaDataSet);

            }
            catch (Exception)
            {
                MessageBox.Show("Скорее всего добавили внешний ключ несовпадающий");
            }
        }
        private void dataGridView4_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                regionTableAdapter.Update(kursovaDataSet);

            }
            catch (Exception)
            {
                MessageBox.Show("Скорее всего добавили внешний ключ несовпадающий");
            }
        }
        private void dataGridView5_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                streetTableAdapter.Update(kursovaDataSet);

            }
            catch (Exception)
            {
                MessageBox.Show("Скорее всего добавили внешний ключ несовпадающий");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM CITY WHERE City_Name = '{dataGridView1.CurrentRow.Cells[0].Value.ToString()}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити місто ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                cityTableAdapter.Fill(kursovaDataSet.City);
                kursovaDataSet.AcceptChanges();
            }
            else
            {
                return;
            }
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM MAYOR WHERE Mayor_Id = '{Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value)}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити місто ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                mayorTableAdapter.Fill(kursovaDataSet.Mayor);
                kursovaDataSet.AcceptChanges();
            }
            else
            {
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM ATTRACTION WHERE Attraction_Id = '{Convert.ToInt32(dataGridView3.CurrentRow.Cells[0].Value)}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити пам'ятку ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                attractionTableAdapter.Fill(kursovaDataSet.Attraction);
                kursovaDataSet.AcceptChanges();
            }
            else
            {
                return;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM REGION WHERE Region_Name = '{dataGridView4.CurrentRow.Cells[0].Value.ToString()}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити область ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                regionTableAdapter.Fill(kursovaDataSet.Region);
                kursovaDataSet.AcceptChanges();
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM REGION WHERE Street_Id = '{Convert.ToInt32(dataGridView5.CurrentRow.Cells[0].Value)}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити область ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                streetTableAdapter.Fill(kursovaDataSet.Street);
                kursovaDataSet.AcceptChanges();
            }
            else
            {
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int price = Convert.ToInt32(comboBox1.SelectedItem);
            string zapros = $"SELECT * FROM CITY WHERE City_Price_Level = '{price}'";
            ZaprosFilter(ConnectionString, zapros, dataGridView1);

        }
        private void ZaprosFilter(string ConnectionString, string zapros, DataGridView dataGridView)
        {
            
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView.DataSource = dt;


                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //string zapros = $"SELECT * FROM CITY";
            //try
            //{
            //    SqlConnection sqlconn = new SqlConnection(ConnectionString);
            //    sqlconn.Open();
            //    SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
            //    DataTable dt = new DataTable();
            //    oda.Fill(dt);
            //    dataGridView1.DataSource = dt;


            //    sqlconn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(@"Error: " + ex.Message);
            //}
            dataGridView1.DataSource = cityBindingSource;

            

        }
        private void Zapros(string ConnectionString, string zapros, DataGridView dataGridView1)
        {
            try
            {
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                dataGridView1.DataSource = dt;


                sqlconn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Error: " + ex.Message);
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.Rows.Count -1; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(textBox1.Text))
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                    break;
                }                
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            //cityTableAdapter.Update(kursovaDataSet);
            //string zapros = $"SELECT * FROM CITY WHERE City_Name LIKE '%{textBox1.Text}%'";
            //Zapros(ConnectionString, zapros, dataGridView1);

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //string zapros = $"SELECT * FROM MAYOR WHERE Mayor_Last_Name LIKE '%{textBox2.Text}%'";
            //Zapros(ConnectionString, zapros, dataGridView2);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string gender = comboBox2.SelectedItem.ToString();
            string zapros = $"SELECT * FROM MAYOR WHERE Mayor_Gender = '{gender}'";
            ZaprosFilter(ConnectionString, zapros, dataGridView2);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //string zapros = $"SELECT * FROM Mayor";
            //try
            //{
            //    SqlConnection sqlconn = new SqlConnection(ConnectionString);
            //    sqlconn.Open();
            //    SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
            //    DataTable dt = new DataTable();
            //    oda.Fill(dt);
            //    dataGridView2.DataSource = dt;


            //    sqlconn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(@"Error: " + ex.Message);
            //}
            dataGridView2.DataSource = mayorBindingSource;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            string date1 = comboBox3.SelectedItem.ToString().Substring(0, 4);
            string date2 = comboBox3.SelectedItem.ToString().Substring(5, 4);
            string zapros = $"SELECT * FROM Attraction WHERE Attraction_Date_Of_Built BETWEEN '{date1}' AND '{date2}'";
            ZaprosFilter(ConnectionString, zapros, dataGridView3);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //string zapros = $"SELECT * FROM Attraction";
            //try
            //{
            //    SqlConnection sqlconn = new SqlConnection(ConnectionString);
            //    sqlconn.Open();
            //    SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
            //    DataTable dt = new DataTable();
            //    oda.Fill(dt);
            //    dataGridView3.DataSource = dt;


            //    sqlconn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(@"Error: " + ex.Message);
            //}
            dataGridView3.DataSource = attractionBindingSource;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            //string zapros = $"SELECT * FROM Attraction WHERE ATTRACTION_Name LIKE '%{textBox3.Text}%'";
            //Zapros(ConnectionString, zapros, dataGridView3);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            string zone = comboBox4.SelectedItem.ToString();
            string zapros = $"SELECT * FROM REGION WHERE Quarantine_Zone_Name = '{zone}'";
            ZaprosFilter(ConnectionString, zapros, dataGridView4);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //string zapros = $"SELECT * FROM REGION";
            //try
            //{
            //    SqlConnection sqlconn = new SqlConnection(ConnectionString);
            //    sqlconn.Open();
            //    SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
            //    DataTable dt = new DataTable();
            //    oda.Fill(dt);
            //    dataGridView4.DataSource = dt;


            //    sqlconn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(@"Error: " + ex.Message);
            //}
            dataGridView4.DataSource = regionBindingSource;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //string zapros = $"SELECT * FROM REGION WHERE Region_Name LIKE '%{textBox4.Text}%'";
            //Zapros(ConnectionString, zapros, dataGridView4);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            string part = comboBox5.SelectedItem.ToString();
            string zapros = $"SELECT * FROM STREET JOIN CITY ON Street.City_Name = City.City_Name JOIN REGION ON City.Region_Name = Region.Region_Name JOIN" +
                $" Part_Of_Ukraine ON Region.Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name WHERE Part_Of_Ukraine.Part_Of_Ukraine_Name = '{part}'";
            ZaprosFilter(ConnectionString, zapros, dataGridView5);
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {
            //string zapros = $"SELECT * FROM Street";
            //try
            //{
            //    SqlConnection sqlconn = new SqlConnection(ConnectionString);
            //    sqlconn.Open();
            //    SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
            //    DataTable dt = new DataTable();
            //    oda.Fill(dt);
            //    dataGridView5.DataSource = dt;


            //    sqlconn.Close();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(@"Error: " + ex.Message);
            //}
            dataGridView5.DataSource = streetBindingSource;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {

                if (dataGridView2.Rows[i].Cells[1].Value.ToString().Contains(textBox2.Text))
                {
                    dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[1];
                    break;
                }
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {

                if (dataGridView3.Rows[i].Cells[1].Value.ToString().Contains(textBox3.Text))
                {
                    dataGridView3.CurrentCell = dataGridView3.Rows[i].Cells[1];
                    break;
                }
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {

                if (dataGridView4.Rows[i].Cells[0].Value.ToString().Contains(textBox4.Text))
                {
                    dataGridView4.CurrentCell = dataGridView4.Rows[i].Cells[0];
                    break;
                }
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {

                if (dataGridView5.Rows[i].Cells[1].Value.ToString().Contains(textBox5.Text))
                {
                    dataGridView5.CurrentCell = dataGridView5.Rows[i].Cells[1];
                    break;
                }
            }
        }

        private void змІнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void містоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var st = new KursovaDataSet.CityDataTable();
            cityTableAdapter.FillBy(st, Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value));
            object[] row = st.Rows[0].ItemArray;
            var edt = new EditFormCity(row[0].ToString(), Convert.ToInt32(row[1]), row[2].ToString(), row[3].ToString(), Convert.ToInt32(row[4]), row[5].ToString(),
                row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString());
            edt.ShowDialog();
            cityTableAdapter.Fill(kursovaDataSet.City);
            kursovaDataSet.AcceptChanges();
        }
    }
}
