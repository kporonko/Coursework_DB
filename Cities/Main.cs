using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
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
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Part_Of_Ukraine". При необходимости она может быть перемещена или удалена.
            this.part_Of_UkraineTableAdapter.Fill(this.kursovaDataSet.Part_Of_Ukraine);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet1.Mayor". При необходимости она может быть перемещена или удалена.
            this.mayorTableAdapter.Fill(this.kursovaDataSet1.Mayor);
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet1.Mayor". При необходимости она может быть перемещена или удалена.
            this.mayorTableAdapter.Fill(this.kursovaDataSet1.Mayor);
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
            city_MayorTableAdapter1.Update(kursovaDataSet);
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
                змІнаToolStripMenuItem.Visible = false;
                додатиToolStripMenuItem.Visible = false;
            }
            else
            {
                button18.Visible = false;
                button19.Visible = false;
            }
            string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id";
            Zapros(ConnectionString,zapros, dataGridView2);
            string zapros_C_M = $"SELECT City_Mayor.City_Name, City_Mayor.Mayor_Id, CONCAT(Mayor.Mayor_Last_Name,Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic), CITY_MAYOR.IsActive  FROM CITY JOIN CITY_MAYOR ON CITY.CITY_NAME = CITY_MAYOR.CITY_NAME JOIN MAYOR ON CITY_MAYOR.MAYOR_ID = MAYOR.MAYOR_ID";
            Zapros(ConnectionString, zapros_C_M, dataGridView6);
            string zaprosQZ = $"SELECT * FROM Quarantine_Zone";
            Zapros(ConnectionString, zaprosQZ, dataGridView8);
            string zaprosHouse = $"SELECT House.House_Id,House.House_Number,Street.Street_Id, Street.Street_Name  FROM House JOIN STREET ON HOUSE.STREET_ID = STREET.STREET_ID";
            Zapros(ConnectionString, zaprosHouse, dataGridView9);
            string zaprosAttr = $"SELECT * from attraction";
            Zapros(ConnectionString, zaprosAttr, dataGridView3);
            string zaprosReg = $"SELECT * from region";
            Zapros(ConnectionString, zaprosReg, dataGridView4);
            string zaprosStr = $"SELECT * from street";
            Zapros(ConnectionString, zaprosStr, dataGridView5);
            string zaprosPart = $"SELECT * from part_of_ukraine";
            Zapros(ConnectionString, zaprosPart, dataGridView10);
            trackBar3.Maximum = DateTime.Now.Year;
            trackBar4.Maximum = DateTime.Now.Year;
            label6.Text = trackBar3.Value.ToString();
            label14.Text = trackBar4.Value.ToString();
            label12.Text = String.Format(trackBar1.Value.ToString());
            label13.Text = String.Format(trackBar2.Value.ToString());
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
                city_MayorTableAdapter1.Update(kursovaDataSet);

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
                mayorTableAdapter.Update(kursovaDataSet);
                city_MayorTableAdapter1.Update(kursovaDataSet);
                string zapros1 = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id";
                Zapros(ConnectionString, zapros1, dataGridView2);
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
                attractionTableAdapter.Update(kursovaDataSet.Attraction);
                string zaprosAttr = $"SELECT * from attraction";
                Zapros(ConnectionString, zaprosAttr, dataGridView3);
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
                string zaprosAttr = $"SELECT * from Region";
                Zapros(ConnectionString, zaprosAttr, dataGridView4);
                regionTableAdapter.Update(kursovaDataSet);
            }
            else
            {
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM STREET WHERE Street_Id = '{Convert.ToInt32(dataGridView5.CurrentRow.Cells[0].Value)}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                streetTableAdapter.Fill(kursovaDataSet.Street);
                kursovaDataSet.AcceptChanges();
                string zaprosStr = $"SELECT * from street";
                Zapros(ConnectionString, zaprosStr, dataGridView5);
            }
            else
            {
                return;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int price = Convert.ToInt32(comboBox1.SelectedItem);
            //string zapros = $"SELECT * FROM CITY WHERE City_Price_Level = '{price}'";
            //ZaprosFilter(ConnectionString, zapros, dataGridView1);

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
        int search_id = 0;
        string search_date = "";
        int[] d1;
        List<string> vsCity = new List<string>();
        int countCity;
        private void button6_Click(object sender, EventArgs e)
        {
            countCity = 0;
            numericUpDown1.Value = 0;
            vsCity.Clear();
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {

                if (dataGridView1.Rows[i].Cells[0].Value.ToString().Contains(textBox1.Text))
                {
                    vsCity.Add(dataGridView1.Rows[i].Cells[0].Value.ToString());
                    numericUpDown1.Value++;
                }
            }
            
            for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            {

                if (dataGridView1.Rows[j].Cells[0].Value.ToString().Contains(textBox1.Text))
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[j].Cells[0];
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
            //string gender = comboBox2.SelectedItem.ToString();
            //string zapros = $"SELECT * FROM MAYOR WHERE Mayor_Gender = '{gender}'";
            //ZaprosFilter(ConnectionString, zapros, dataGridView2);
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
            //dataGridView2.DataSource = mayorBindingSource;
            city_MayorTableAdapter1.Update(kursovaDataSet);
            mayorTableAdapter.Update(kursovaDataSet);
            string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id";
            Zapros(ConnectionString, zapros, dataGridView2);
            filter = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string date1 = comboBox3.SelectedItem.ToString().Substring(0, 4);
            //string date2 = comboBox3.SelectedItem.ToString().Substring(5, 4);
            //string zapros = $"SELECT * FROM Attraction WHERE Attraction_Date_Of_Built BETWEEN '{date1}' AND '{date2}'";
            //ZaprosFilter(ConnectionString, zapros, dataGridView3);
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
            //string part = comboBox5.SelectedItem.ToString();
            //string zapros = $"SELECT * FROM STREET JOIN CITY ON Street.City_Name = City.City_Name JOIN REGION ON City.Region_Name = Region.Region_Name JOIN" +
            //    $" Part_Of_Ukraine ON Region.Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name WHERE Part_Of_Ukraine.Part_Of_Ukraine_Name = '{part}'";
            //ZaprosFilter(ConnectionString, zapros, dataGridView5);
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
        List<string> vsMayor = new List<string>();
        private void button7_Click(object sender, EventArgs e)
        {
            //for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            //{

            //    if (dataGridView2.Rows[i].Cells[1].Value.ToString().Contains(textBox2.Text))
            //    {
            //        dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[1];
            //        break;
            //    }
            //}
            countMayor = 0;
            numericUpDown2.Value = 0;
            vsMayor.Clear();
            for (int i = 0; i < dataGridView2.Rows.Count - 1; i++)
            {

                if (dataGridView2.Rows[i].Cells[1].Value.ToString().Contains(textBox2.Text))
                {
                    vsMayor.Add(dataGridView2.Rows[i].Cells[1].Value.ToString());
                    numericUpDown2.Value++;
                }
            }

            for (int j = 0; j < dataGridView2.Rows.Count - 1; j++)
            {

                if (dataGridView2.Rows[j].Cells[1].Value.ToString().Contains(textBox2.Text))
                {
                    dataGridView2.CurrentCell = dataGridView2.Rows[j].Cells[1];
                    break;
                }
            }

        }


        List<string> vsAttr = new List<string>();
        int countAttr;

        private void button8_Click(object sender, EventArgs e)
        {
            countAttr = 0;
            numericUpDown3.Value = 0;
            vsAttr.Clear();
            for (int i = 0; i < dataGridView3.Rows.Count - 1; i++)
            {

                if (dataGridView3.Rows[i].Cells[1].Value.ToString().Contains(textBox3.Text))
                {
                    vsAttr.Add(dataGridView3.Rows[i].Cells[1].Value.ToString());
                    numericUpDown3.Value++;
                }
            }

            for (int j = 0; j < dataGridView3.Rows.Count - 1; j++)
            {

                if (dataGridView3.Rows[j].Cells[1].Value.ToString().Contains(textBox3.Text))
                {
                    dataGridView3.CurrentCell = dataGridView3.Rows[j].Cells[1];
                    break;
                }
            }

        }

        List<string> vsReg = new List<string>();
        int countReg;


        private void button9_Click(object sender, EventArgs e)
        {
            countReg = 0;
            numericUpDown4.Value = 0;
            vsReg.Clear();
            for (int i = 0; i < dataGridView4.Rows.Count - 1; i++)
            {

                if (dataGridView4.Rows[i].Cells[0].Value.ToString().Contains(textBox4.Text))
                {
                    vsReg.Add(dataGridView4.Rows[i].Cells[0].Value.ToString());
                    numericUpDown4.Value++;
                }
            }

            for (int j = 0; j < dataGridView4.Rows.Count - 1; j++)
            {

                if (dataGridView4.Rows[j].Cells[0].Value.ToString().Contains(textBox4.Text))
                {
                    dataGridView4.CurrentCell = dataGridView4.Rows[j].Cells[0];
                    break;
                }
            }

        }
        List<string> vsStr = new List<string>();
        int countStr;

        private void button10_Click(object sender, EventArgs e)
        {
            countStr = 0;
            numericUpDown5.Value = 0;
            vsStr.Clear();
            for (int i = 0; i < dataGridView5.Rows.Count - 1; i++)
            {

                if (dataGridView5.Rows[i].Cells[1].Value.ToString().Contains(textBox5.Text))
                {
                    vsStr.Add(dataGridView5.Rows[i].Cells[1].Value.ToString());
                    numericUpDown5.Value++;
                }
            }

            for (int j = 0; j < dataGridView5.Rows.Count - 1; j++)
            {

                if (dataGridView5.Rows[j].Cells[1].Value.ToString().Contains(textBox5.Text))
                {
                    dataGridView5.CurrentCell = dataGridView5.Rows[j].Cells[1];
                    break;
                }
            }

        }

        private void змІнаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void містоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regionTableAdapter.Update(kursovaDataSet);
            cityTableAdapter.Update(kursovaDataSet);
            var st = new KursovaDataSet.CityDataTable();
            try
            {
                cityTableAdapter.FillBy(st, Convert.ToString(dataGridView1.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                if (row[1].ToString() == "" && row[4].ToString() == "")
                {
                    var edt = new EditFormCity(row[0].ToString(), 0, row[2].ToString(), row[3].ToString(), 0, row[5].ToString(),
                    row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString());
                    edt.ShowDialog();
                }
                else if(row[1].ToString() == "" && row[4].ToString() != "")
                {
                    var edt = new EditFormCity(row[0].ToString(), 0, row[2].ToString(), row[3].ToString(), Convert.ToInt32(row[4]), row[5].ToString(),
                    row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString());
                    edt.ShowDialog();
                }
                else if(row[1].ToString() != "" && row[4].ToString() == "")
                {
                    var edt = new EditFormCity(row[0].ToString(), Convert.ToInt32(row[1]), row[2].ToString(), row[3].ToString(), 0, row[5].ToString(),
                    row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString());
                    edt.ShowDialog();
                }
                else
                {
                    var edt = new EditFormCity(row[0].ToString(), Convert.ToInt32(row[1]), row[2].ToString(), row[3].ToString(), Convert.ToInt32(row[4]), row[5].ToString(),
                    row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString());
                    edt.ShowDialog();
                }
                //comboBox1.Text = row[9].ToString();
                //comboBox1.SelectedValue = row[9];
                
                
                cityTableAdapter.Fill(kursovaDataSet.City);
                //comboBox1.Text = row[9].ToString();
                
                kursovaDataSet.AcceptChanges();
                string zapros = "SELECT CITY_NAME, CITY_POPULATION, CITY_AREA, CITY_FOUNDATION_DATE, CITY_PRICE_LEVEL, CITY_HIGHEST_POINT, CITY_WEBSITE, CITY_INTERESTING_FACT, CITY_WEATHER, REGION_NAME FROM CITY ";
                Zapros(ConnectionString, zapros, dataGridView1);

            }
            catch (Exception)
            {
                
                MessageBox.Show("Оберіть рядок");
                return;
            }
            
            
            
        }

        private void мерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            city_MayorTableAdapter1.Update(kursovaDataSet);
            mayorTableAdapter.Update(kursovaDataSet);
            var st = new KursovaDataSet.MayorDataTable();
            try
            {
                mayorTableAdapter.FillBy(st, Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditFormMayor(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString());
                edt.ShowDialog();
                mayorTableAdapter.Fill(kursovaDataSet.Mayor);
                kursovaDataSet.AcceptChanges();
                string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id";
                Zapros(ConnectionString, zapros, dataGridView2);
                string zapros_C_M = $"SELECT City_Mayor.City_Name, City_Mayor.Mayor_Id, CONCAT(Mayor.Mayor_Last_Name,Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic), CITY_MAYOR.IsActive  FROM CITY JOIN CITY_MAYOR ON CITY.CITY_NAME = CITY_MAYOR.CITY_NAME JOIN MAYOR ON CITY_MAYOR.MAYOR_ID = MAYOR.MAYOR_ID";
                Zapros(ConnectionString, zapros_C_M, dataGridView6);
            }
            catch (Exception)
            {
                MessageBox.Show("Оберіть рядок");
                return;
            }
            
            
        }

        private void містоToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cityTableAdapter.Update(kursovaDataSet);
            mayorTableAdapter.Update(kursovaDataSet);
            var edt = new EditFormCity();
            edt.ShowDialog();
            cityTableAdapter.Fill(kursovaDataSet.City);
            kursovaDataSet.AcceptChanges();
        }

        private void мерToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cityTableAdapter.Update(kursovaDataSet);
            mayorTableAdapter.Update(kursovaDataSet);
            var edt = new EditFormMayor();
            edt.ShowDialog();
            string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id";
            Zapros(ConnectionString, zapros, dataGridView2);
            cityTableAdapter.Update(kursovaDataSet);
            mayorTableAdapter.Update(kursovaDataSet);
            mayorTableAdapter.Fill(kursovaDataSet.Mayor);
            kursovaDataSet.AcceptChanges();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            Picture picture = new Picture(dataGridView1.SelectedCells[0].Value.ToString());
            picture.Show();
        }

        private void статистикаКарантиннихЗонToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string zapros = $"SELECT Part_Of_Ukraine.Part_Of_Ukraine_Name, Quarantine_Zone.Quarantine_Zone_Name, COUNT(Region.Quarantine_Zone_Name) " +
            //    $"FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name " +
            //    $"JOIN Quarantine_Zone ON Region.Quarantine_Zone_Name = Quarantine_Zone.Quarantine_Zone_Name GROUP BY Part_Of_Ukraine.Part_Of_Ukraine_Name, Quarantine_Zone.Quarantine_Zone_Name";

            //string zapros = $"SELECT Part_Of_Ukraine.Part_Of_Ukraine_Name, Quarantine_Zone.Quarantine_Zone_Name, COUNT(Region.Region_Name) FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name JOIN Quarantine_Zone ON Region.Quarantine_Zone_Name = Quarantine_Zone.Quarantine_Zone_Name GROUP BY Part_Of_Ukraine.Part_Of_Ukraine_Name, Quarantine_Zone.Quarantine_Zone_Name";

            //string zapros = $"SELECT Part_Of_Ukraine.Part_Of_Ukraine_Name, COUNT(Region.Quarantine_Zone_Name) " +
            //    $"FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name WHERE Region.Quarantine_Zone_Name = 'Червона' GROUP BY Part_Of_Ukraine.Part_Of_Ukraine_Name";

            //string zapros = $"SELECT Part_Of_Ukraine.Part_Of_Ukraine_Name, " +
            //    $"COUNT(DECODE(Region.Quarantine_Zone_Name, 'Червона', 1, NULL)) AS Червона," +
            //    $"COUNT(DECODE(Region.Quarantine_Zone_Name, 'Помаранчева', 1, NULL)) AS Помаранчева," +
            //    $"COUNT(DECODE(Region.Quarantine_Zone_Name, 'Жовта', 1, NULL)) AS Жовта," +
            //    $"COUNT(DECODE(Region.Quarantine_Zone_Name, 'Зелена', 1, NULL)) AS Зелена" +
            //    $"FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name" +
            //    $"GROUP BY Part_Of_Ukraine.Part_Of_Ukraine_Name";

            //string zapros = $"SELECT Part_Of_Ukraine.Part_Of_Ukraine_Name," +
            //    $"COUNT(CASE WHEN Region.Quarantine_Zone_Name = 'Червона' THEN 1 ELSE 0 END ) AS Червона," +
            //    $"COUNT(CASE WHEN Region.Quarantine_Zone_Name = 'Помаранчева' THEN 1 ELSE 0 END ) AS Помаранчева," +
            //    $"COUNT(CASE WHEN Region.Quarantine_Zone_Name = 'Жовта' THEN 1 ELSE 0 END ) AS Жовта," +
            //    $"COUNT(CASE WHEN Region.Quarantine_Zone_Name = 'Зелена' THEN 1 ELSE 0 END ) AS Зелена " +
            //    $"FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name GROUP BY Part_Of_Ukraine.Part_Of_Ukraine_Name";

            //string zapros = $"SELECT Part_Of_Ukraine.Part_Of_Ukraine_Name, " +
            //    $"(SELECT COUNT(Region.Region_Name) FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name WHERE Region.Quarantine_Zone_Name = 'Червона'), " +
            //    $"(SELECT COUNT(Region.Region_Name) FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name WHERE Region.Quarantine_Zone_Name = 'Помаранчева'), " +
            //    $"(SELECT COUNT(Region.Region_Name) FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name WHERE Region.Quarantine_Zone_Name = 'Жовта'), " +
            //    $"(SELECT COUNT(Region.Region_Name) FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name WHERE Region.Quarantine_Zone_Name = 'Зелена') FROM Part_Of_Ukraine GROUP BY Part_Of_Ukraine.Part_Of_Ukraine_Name";

            //string zapros = $"SELECT Part_Of_Ukraine.Part_Of_Ukraine_Name," +
            //    $"(SELECT COUNT(Region.Region_Name) FROM Part_Of_Ukraine P1 JOIN Region ON P1.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name WHERE Region.Quarantine_Zone_Name = 'Червона' AND P1.Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Червона," +
            //    $"(SELECT COUNT(Region.Region_Name) FROM Part_Of_Ukraine P1 JOIN Region ON P1.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name WHERE Region.Quarantine_Zone_Name = 'Помаранчева' AND P1.Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Помаранчева," +
            //    $"(SELECT COUNT(Region.Region_Name) FROM Part_Of_Ukraine P1 JOIN Region ON P1.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name WHERE Region.Quarantine_Zone_Name = 'Жовта' AND P1.Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Жовта," +
            //    $"(SELECT COUNT(Region.Region_Name) FROM Part_Of_Ukraine P1 JOIN Region ON P1.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name WHERE Region.Quarantine_Zone_Name = 'Зелена' AND P1.Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Зелена" +
            //    $" FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name JOIN Quarantine_Zone ON Region.Quarantine_Zone_Name = Quarantine_Zone.Quarantine_Zone_Name";

            string zapros = $"SELECT DISTINCT Part_Of_Ukraine.Part_Of_Ukraine_Name," +
                $"(SELECT COUNT(Region_Name) FROM Region WHERE Quarantine_Zone_Name = 'Червона' AND Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Червона, " +
                $"(SELECT COUNT(Region_Name) FROM Region WHERE Quarantine_Zone_Name = 'Помаранчева' AND Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Помаранчева, " +
                $"(SELECT COUNT(Region_Name) FROM Region WHERE Quarantine_Zone_Name = 'Жовта' AND Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Жовта," +
                $" (SELECT COUNT(Region_Name) FROM Region WHERE Quarantine_Zone_Name = 'Зелена' AND Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Зелена" +
                $" FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name JOIN Quarantine_Zone ON Region.Quarantine_Zone_Name = Quarantine_Zone.Quarantine_Zone_Name";

            Request request = new Request(zapros);
            request.Show();
        }

        private void середнійВікМерівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string zapros = $"SELECT Part_Of_Ukraine.Part_Of_Ukraine_Name, AVG(DATEDIFF(year, Mayor.Mayor_Date_Of_Birth, GETDATE())) " +
                $"FROM Part_Of_Ukraine " +
                $"JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name JOIN City ON Region.Region_Name = City.Region_Name JOIN City_Mayor ON City.City_Name = City_Mayor.City_Name JOIN Mayor ON City_Mayor.Mayor_Id = Mayor.Mayor_Id " +
                $"WHERE City_Mayor.IsActive = 'true' " +
                $"GROUP BY Part_Of_Ukraine.Part_Of_Ukraine_Name";

            Request request = new Request(zapros);
            request.Show();
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string act = comboBox6.SelectedItem.ToString();
            //string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity" +
            //    $" FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id WHERE City_Mayor.IsActive = '{act}'";
            //ZaprosFilter(ConnectionString, zapros, dataGridView2);
        }

        private void кількістьМіськогоНаселенняКожноїЧастиниУкраїниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string zapros = $"SELECT Part_Of_Ukraine.Part_Of_Ukraine_Name, SUM(City.City_Population) " +
                $"FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name JOIN City ON Region.Region_Name = City.Region_Name " +
                $"GROUP BY Part_Of_Ukraine.Part_Of_Ukraine_Name";

            Request request = new Request(zapros);
            request.Show();
        }

        private void співвідношенняСтатейМерівToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string zapros = $"SELECT DISTINCT Part_Of_Ukraine.Part_Of_Ukraine_Name, " +
                $"(SELECT COUNT(Mayor.Mayor_Id) FROM Part_Of_Ukraine P1 JOIN Region ON P1.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name JOIN City ON Region.Region_Name = City.Region_Name JOIN City_Mayor ON City.City_Name = CITY_MAYOR.City_Name JOIN Mayor ON City_Mayor.Mayor_Id = Mayor.Mayor_Id " +
                $"WHERE Mayor_Gender = 'М' AND City_Mayor.IsActive = 'true' AND P1.Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Мужчин, " +
                $"(SELECT COUNT(Mayor.Mayor_Id) FROM Part_Of_Ukraine P1 JOIN Region ON P1.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name JOIN City ON Region.Region_Name = City.Region_Name JOIN City_Mayor ON City.City_Name = CITY_MAYOR.City_Name JOIN Mayor ON City_Mayor.Mayor_Id = Mayor.Mayor_Id " +
                $"WHERE Mayor_Gender = 'Ж' AND City_Mayor.IsActive = 'true' AND P1.Part_Of_Ukraine_Name = Part_Of_Ukraine.Part_Of_Ukraine_Name) AS Женщин " +
                $"FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name JOIN City ON Region.Region_Name = City.Region_Name " +
                $"JOIN City_Mayor ON City.City_Name = CITY_MAYOR.City_Name JOIN Mayor ON City_Mayor.Mayor_Id = Mayor.Mayor_Id ";

            Request request = new Request(zapros);
            request.Show();
        }



        private void містоМерToolStripMenuItem_Click(object sender, EventArgs e)
        {
            city_MayorTableAdapter1.Update(kursovaDataSet);
            var st = new KursovaDataSet.City_MayorDataTable();
            try
            {
                city_MayorTableAdapter1.FillBy(st,dataGridView6.SelectedRows[0].Cells[0].Value.ToString(), Convert.ToInt32(dataGridView6.SelectedRows[0].Cells[1].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new City_Mayor(row[0].ToString(), Convert.ToInt32(row[1]), row[2].ToString());
                edt.ShowDialog();
                city_MayorTableAdapter1.Fill(kursovaDataSet.City_Mayor);
                kursovaDataSet.AcceptChanges();
                city_MayorTableAdapter1.Update(kursovaDataSet);

                string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id";
                Zapros(ConnectionString, zapros, dataGridView2);
                string zapros_C_M = $"SELECT City_Mayor.City_Name, City_Mayor.Mayor_Id, CONCAT(Mayor.Mayor_Last_Name,Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic), CITY_MAYOR.IsActive  FROM CITY JOIN CITY_MAYOR ON CITY.CITY_NAME = CITY_MAYOR.CITY_NAME JOIN MAYOR ON CITY_MAYOR.MAYOR_ID = MAYOR.MAYOR_ID";
                Zapros(ConnectionString, zapros_C_M, dataGridView6);
            }
            catch (Exception)
            {
                MessageBox.Show("Оберіть рядок");
                return;
            }
        }

        private void містомерToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            cityTableAdapter.Update(kursovaDataSet);
            mayorTableAdapter.Update(kursovaDataSet);
            city_MayorTableAdapter1.Update(kursovaDataSet);
            var edt = new City_Mayor();
            edt.ShowDialog();
            string zapros_C_M = $"SELECT City_Mayor.City_Name, City_Mayor.Mayor_Id, CONCAT(Mayor.Mayor_Last_Name,Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic), CITY_MAYOR.IsActive  FROM CITY JOIN CITY_MAYOR ON CITY.CITY_NAME = CITY_MAYOR.CITY_NAME JOIN MAYOR ON CITY_MAYOR.MAYOR_ID = MAYOR.MAYOR_ID";
            Zapros(ConnectionString, zapros_C_M, dataGridView6);
            string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id";
            Zapros(ConnectionString, zapros, dataGridView2);
            cityTableAdapter.Update(kursovaDataSet);
            mayorTableAdapter.Update(kursovaDataSet);
            cityTableAdapter.Fill(kursovaDataSet.City);
            kursovaDataSet.AcceptChanges();
        }

        private void dataGridView6_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {

                city_MayorTableAdapter1.Update(kursovaDataSet);



            }
            catch (Exception)
            {
                MessageBox.Show("Скорее всего добавили внешний ключ несовпадающий");
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM CITY_MAYOR WHERE City_Name = '{dataGridView6.CurrentRow.Cells[0].Value.ToString()}' AND Mayor_Id = '{Convert.ToInt32(dataGridView6.CurrentRow.Cells[1].Value)}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити місто ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                city_MayorTableAdapter1.Fill(kursovaDataSet.City_Mayor);

                kursovaDataSet.AcceptChanges();
                city_MayorTableAdapter1.Update(kursovaDataSet);
                string zapros_C_M = $"SELECT City_Mayor.City_Name, City_Mayor.Mayor_Id, CONCAT(Mayor.Mayor_Last_Name,Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic), CITY_MAYOR.IsActive  FROM CITY JOIN CITY_MAYOR ON CITY.CITY_NAME = CITY_MAYOR.CITY_NAME JOIN MAYOR ON CITY_MAYOR.MAYOR_ID = MAYOR.MAYOR_ID";
                Zapros(ConnectionString, zapros_C_M, dataGridView6);
                string zapros1 = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id";
                Zapros(ConnectionString, zapros1, dataGridView2);
            }
            else
            {
                return;
            }
        }

        private void button18_Click(object sender, EventArgs e)
        {
            try
            {
                string cname = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
                string zapros = $"SELECT City.City_Name, City.City_Population, City.City_Area, City.City_Foundation_Date, City.City_Price_Level, City.City_Highest_Point, City.City_Website, City.City_Interesting_Fact, City.City_Weather, Region.Region_Name, Region.Part_Of_Ukraine_Name, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, " +
                $"(SELECT Quarantine_Zone.Quarantine_Zone_Name FROM City JOIN REGION ON City.Region_Name = Region.Region_Name JOIN Quarantine_Zone ON Region.Quarantine_Zone_Name = Quarantine_Zone.Quarantine_Zone_Name WHERE City.City_Name = '{cname}' ), " +
                $"(SELECT Quarantine_Zone.Quarantine_Zone_Restrictions FROM City JOIN REGION ON City.Region_Name = Region.Region_Name JOIN Quarantine_Zone ON Region.Quarantine_Zone_Name = Quarantine_Zone.Quarantine_Zone_Name WHERE City.City_Name = '{cname}' ) " +
                $"FROM Part_Of_Ukraine JOIN Region ON Part_Of_Ukraine.Part_Of_Ukraine_Name = Region.Part_Of_Ukraine_Name JOIN City ON Region.Region_Name = City.Region_Name JOIN City_Mayor ON City.City_Name = CITY_MAYOR.City_Name JOIN Mayor ON City_Mayor.Mayor_Id = Mayor.Mayor_Id " +
                $"WHERE City.City_Name = '{cname}' AND City_Mayor.IsActive = 'true'";
                SqlConnection sqlconn = new SqlConnection(ConnectionString);
                
                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                //File.Create(@"D:\\fileCityyyyyyyy.txt");
                
                //TextWriter tw = new StreamWriter("D:\\Учеба\\дз 3 семестр\\БД\\Kursova\\fileCity.txt", false);
                TextWriter tw = new StreamWriter("D:\\Учеба\\дз 3 семестр\\БД\\Kursova\\fileCity", false);
                try
                {
                    tw.WriteLine("Зведення про місто" + "\n");

                    tw.WriteLine(DateTime.Now.ToString()+"\n");
                    tw.WriteLine($"Назва міста: {dt.Rows[0][0]}");
                    tw.WriteLine($"Населення міста: {dt.Rows[0][1]}");
                    tw.WriteLine($"Площа міста: {dt.Rows[0][2]}");
                    tw.WriteLine($"Дата заснування міста: {dt.Rows[0][3]}");
                    tw.WriteLine($"Рівень цін міста: {dt.Rows[0][4]}");
                    tw.WriteLine($"Висота над рівнем моря: {dt.Rows[0][5]}");
                    tw.WriteLine($"Вебсайт міста: {dt.Rows[0][6]}");
                    tw.WriteLine($"Цікаві факти про місто: \n{dt.Rows[0][7]}");
                    tw.WriteLine($"Погода у місті: {dt.Rows[0][8]}");
                    tw.WriteLine($"Назва області: {dt.Rows[0][9]}");
                    tw.WriteLine($"Назва чатсини України: {dt.Rows[0][10]}");
                    tw.WriteLine($"ПІБ мера: {dt.Rows[0][11]} {dt.Rows[0][12]} {dt.Rows[0][13]}");
                    tw.WriteLine($"Карантинна зона: {dt.Rows[0][14]}");
                    tw.WriteLine($"Обмеження: {dt.Rows[0][15]}");
                    tw.Close();

                    string commandText = "D:\\Учеба\\дз 3 семестр\\БД\\Kursova\\fileCity";
                    var proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = commandText;
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                }
                catch (Exception ex)
                {
                    tw.Close();
                    MessageBox.Show("Даних щодо міста не вистачає, лінивий адміністратор ввів не усі дані\n" + ex.Message);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Оберіть рядок");
            }
        }
        
        private void button19_Click(object sender, EventArgs e)
        {
            try
            {
                string aname = dataGridView3.SelectedRows[0].Cells[1].Value.ToString();
                string zapros = $"SELECT Attraction.Attraction_Name, Attraction.Attraction_Date_Of_Built, Attraction.Attraction_Meaning, Attraction.Attraction_Height,  Street.Street_Name, House.House_Number, City.City_Name " +
                    $"FROM Attraction JOIN House ON Attraction.House_Id = House.House_Id JOIN Street ON House.Street_Id = Street.Street_Id JOIN City ON Street.City_Name = City.City_Name " +
                    $"WHERE Attraction.Attraction_Name = '{aname}'";
                SqlConnection sqlconn = new SqlConnection(ConnectionString);

                sqlconn.Open();
                SqlDataAdapter oda = new SqlDataAdapter(zapros, sqlconn);
                DataTable dt = new DataTable();
                try
                {
                    oda.Fill(dt);
                    TextWriter tw = new StreamWriter("D:\\Учеба\\дз 3 семестр\\БД\\Kursova\\fileAttraction", false);
                    tw.WriteLine("Зведення про пам'ятку" + "\n");
                    tw.WriteLine(DateTime.Now.ToString() + "\n");

                    tw.WriteLine($"Назва пам'ятки: {dt.Rows[0][0]}");
                    tw.WriteLine($"Дата побудови пам'ятки: {dt.Rows[0][1]}");
                    tw.WriteLine($"Значення пам'ятки: {dt.Rows[0][2]}");
                    tw.WriteLine($"Висота пам'ятки: {dt.Rows[0][3]}");
                    tw.WriteLine($"Адреса пам'ятки: Місто {dt.Rows[0][6]} вул. {dt.Rows[0][4]}, {dt.Rows[0][5]}");

                    tw.Close();
                    string commandText = "D:\\Учеба\\дз 3 семестр\\БД\\Kursova\\fileAttraction";
                    var proc = new System.Diagnostics.Process();
                    proc.StartInfo.FileName = commandText;
                    proc.StartInfo.UseShellExecute = true;
                    proc.Start();
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Оберіть рядок");
            }
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM MAYOR WHERE Mayor_Id = '{Convert.ToInt32(dataGridView7.CurrentRow.Cells[0].Value)}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити мера ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                mayorTableAdapter.Fill(kursovaDataSet.Mayor);
                city_MayorTableAdapter1.Fill(kursovaDataSet.City_Mayor);
                kursovaDataSet.AcceptChanges();
                mayorTableAdapter.Update(kursovaDataSet);
                city_MayorTableAdapter1.Update(kursovaDataSet);
            }
            else
            {
                return;
            }
        }
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (Admin.IsAdmin == false)
            {
                e.Cancel = e.TabPageIndex == 5;

            }
        }

        bool asc = false;
        private void button21_Click_1(object sender, EventArgs e)
        {

            //if (asc == true)
            //{
            //    string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id ORDER BY Mayor_Date_Of_Birth";
            //    Zapros(ConnectionString, zapros, dataGridView2);
            //    asc = false;

            //}
            //else if (asc == false)
            //{
            //    string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id ORDER BY Mayor_Date_Of_Birth DESC";
            //    Zapros(ConnectionString, zapros, dataGridView2);
            //    asc = true;

            //}
        }

        private string ZaprosNeighbour(string currRegion, string direction)
        {
            return $"SELECT Neighbour_Name FROM Neighbour WHERE Region_Name = '{currRegion}' AND Neighbour_Direction = '{direction}'";
            
        }
        private string ZaprosProverkaRegion(string currRegion)
        {
            return  $"SELECT Part_Of_Ukraine_Name FROM REGION WHERE Region_Name = '{currRegion}'";
        }
        private void button22_Click(object sender, EventArgs e)
        {

            listBox1.Items.Clear();
            string startRegion = comboBox7.Text;
            string endPart = comboBox8.Text;
            string part;
            string zaprosProverkaRegion = $"SELECT Part_Of_Ukraine_Name FROM REGION WHERE Region_Name = '{startRegion}'";
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlDataAdapter oda = new SqlDataAdapter(zaprosProverkaRegion, sqlconn);
            DataTable dt = new DataTable();
            oda.Fill(dt);
            part = dt.Rows[0][0].ToString();
            if (dt.Rows[0][0].ToString() == comboBox8.Text)
            {
                MessageBox.Show("Обрана область знаходиться в цій частині України");
                sqlconn.Close();
                return;
            }
            
            sqlconn.Close();

            List<string> way = new List<string>();
            string direction = CheckDirection(part, endPart);
            string currRegion = startRegion;
            string currPart = part;




            while (currPart != endPart)
            {
                sqlconn.Open();
                oda = new SqlDataAdapter(ZaprosNeighbour(currRegion, direction), sqlconn);
                dt = new DataTable();
                oda.Fill(dt);
                if (dt.Rows.Count < 1)
                {
                    oda = new SqlDataAdapter(ZaprosNeighbour(currRegion, direction.Split('_')[0]), sqlconn);
                    dt = new DataTable();
                    oda.Fill(dt);
                    if (dt.Rows.Count < 1)
                    {
                        try
                        {
                            if (direction.Contains("_"))
                            {
                                
                                oda = new SqlDataAdapter(ZaprosNeighbour(currRegion, direction.Split('_')[1]), sqlconn);
                                dt = new DataTable();
                                oda.Fill(dt);
                                if(dt.Rows.Count == 0)
                                {
                                    string zaprosLikeNeighbName = $"SELECT Neighbour_Name FROM Neighbour WHERE Region_Name = '{currRegion}' AND Neighbour_Direction LIKE '%{direction.Split('_')[1]}%'";
                                    oda = new SqlDataAdapter(zaprosLikeNeighbName, sqlconn);
                                    dt = new DataTable();
                                    oda.Fill(dt);
                                }
                            }
                            else
                            {
                                string zaprosLikeNeighbName = $"SELECT Neighbour_Name FROM Neighbour WHERE Region_Name = '{currRegion}' AND Neighbour_Direction LIKE '%{direction}%'";
                                oda = new SqlDataAdapter(zaprosLikeNeighbName, sqlconn);
                                dt = new DataTable();
                                oda.Fill(dt);
                            }

                        }
                        catch (Exception)
                        {
                            string tempdir = direction;
                            direction = CheckDirection(currPart, endPart);
                            oda = new SqlDataAdapter(ZaprosNeighbour(currRegion, direction), sqlconn);
                            dt = new DataTable();
                            oda.Fill(dt);
                            direction = tempdir;

                        }

                    }
                }
                if (startRegion == "Житомирська область" && endPart == "Східна")
                {
                    way.Add("Київська область");
                    way.Add("Полтавська область");
                    way.Add("Харківська область");

                    break;
                }
                else
                {
                    currRegion = dt.Rows[0][0].ToString();
                    way.Add(currRegion);
                }

                oda = new SqlDataAdapter(ZaprosProverkaRegion(currRegion), sqlconn);
                dt = new DataTable();
                oda.Fill(dt);

                currPart = dt.Rows[0][0].ToString();
                
                sqlconn.Close();
            }
            sqlconn.Open();
            TextWriter tw = new StreamWriter("D:\\Учеба\\дз 3 семестр\\БД\\Kursova\\Journey2", false);
            foreach (var item in way)
            {
                listBox1.Items.Add(item);
                //string zaprosEnd = $"SELECT Region.Region_Name, Region.Region_Area, Region.Region_Spoken_Language,Region.Region_Admin_Center, Region.Region_Website, Region.Region_Budget, Region.Region_Area_Code, Region.Region_Council, Region.Region_Council_Head_Surname, Region.Quarantine_Zone_Name, Region.Part_Of_Ukraine_Name, " +
                //    $"Quarantine_Zone.Quarantine_Zone_Restrictions, City.City_Name, Attraction.Attraction_Name, Attraction.Attraction_Meaning " +
                //    $"FROM Quarantine_Zone JOIN Region ON Quarantine_Zone.Quarantine_Zone_Name =  Region.Quarantine_Zone_Name JOIN City ON Region.Region_Name = City.Region_Name JOIN Street ON City.City_Name = Street.City_Name JOIN House ON Street.Street_Id = House.Street_Id JOIN Attraction ON House.House_Id = Attraction.House_Id " +
                //    $"WHERE Region.Region_Name = '{item}'";
                string zaprosEnd = $"SELECT Region.Region_Name, Region.Region_Area, Region.Region_Spoken_Language,Region.Region_Admin_Center, Region.Region_Website, Region.Region_Budget, Region.Region_Area_Code, Region.Region_Council, Region.Region_Council_Head_Surname, Region.Quarantine_Zone_Name, Region.Part_Of_Ukraine_Name, " +
                    $"Quarantine_Zone.Quarantine_Zone_Restrictions " +
                    $"FROM Quarantine_Zone JOIN Region ON Quarantine_Zone.Quarantine_Zone_Name =  Region.Quarantine_Zone_Name " +
                    $"WHERE Region.Region_Name = '{item}' ";
                oda = new SqlDataAdapter(zaprosEnd, sqlconn);
                dt = new DataTable();
                oda.Fill(dt);
                tw.WriteLine($"Подорож з {comboBox7.Text} області до {comboBox8.Text} частини України {DateTime.Now.ToString()}\n");
                tw.WriteLine($"Назва області: {dt.Rows[0][0]}");
                tw.WriteLine($"Площа області: {dt.Rows[0][1]} км кв");
                tw.WriteLine($"Мова, якою переважно розмовляють у побуті: {dt.Rows[0][2]}");
                tw.WriteLine($"Адміністративний центр області: {dt.Rows[0][3]}");
                tw.WriteLine($"Сайт міста: {dt.Rows[0][4]}");
                tw.WriteLine($"Бюджет області: {dt.Rows[0][5]}");
                tw.WriteLine($"Код телефону міста: {dt.Rows[0][6]}");
                tw.WriteLine($"Обласна рада: {dt.Rows[0][7]}");
                tw.WriteLine($"Голова ради: {dt.Rows[0][8]}");
                tw.WriteLine($"Карантинна зона: {dt.Rows[0][9]}");
                tw.WriteLine($"Обмеження: {dt.Rows[0][11]}");
                tw.WriteLine($"Частина України: {dt.Rows[0][10]}\n");
                sqlconn.Close();
                sqlconn.Open();
                string zaprosAttr = $"select part_of_Ukraine.part_of_Ukraine_name, string_agg(attraction.attraction_name, ', ') from attraction join house on house.house_id = attraction.house_id " +
                $"join street on street.street_id = house.street_id join city on street.city_name = city.city_name join region on city.region_name = region.region_name join part_of_ukraine on part_of_ukraine.part_of_Ukraine_name = region.part_of_Ukraine_name " +
                $"group by part_of_Ukraine.part_of_Ukraine_name";
                oda = new SqlDataAdapter(zaprosAttr, sqlconn);
                dt = new DataTable();
                oda.Fill(dt);
                tw.WriteLine($"Список пам'яток частини України: {dt.Rows[0][1]}");
                tw.WriteLine($"\n\n\n");
                sqlconn.Close();
                string commandText = "D:\\Учеба\\дз 3 семестр\\БД\\Kursova\\Journey2";
                var proc = new System.Diagnostics.Process();
                proc.StartInfo.FileName = commandText;
                proc.StartInfo.UseShellExecute = true;
                proc.Start();
                
            }
            tw.Close();



        }
        private string CheckDirection(string part, string endPart)
        {
            string direction = "";
            if (part == "Західна")
            {
                if (endPart == "Центральна" || endPart == "Східна")
                {
                    direction = "Схід";
                }
                if (endPart == "Північна")
                {
                    direction = "Північ_Схід";
                }
                if (endPart == "Південна")
                {
                    direction = "Південь_Схід";
                }
            }
            if (part == "Центральна")
            {
                if (endPart == "Східна")
                {
                    direction = "Схід";
                }
                if (endPart == "Північна")
                {
                    direction = "Північ";
                }
                if (endPart == "Південна")
                {
                    direction = "Південь";
                }
                if (endPart == "Західна")
                {
                    direction = "Захід";
                }
            }
            if (part == "Східна")
            {
                if (endPart == "Центральна" || endPart == "Західна")
                {
                    direction = "Захід";
                }
                if (endPart == "Північна")
                {
                    direction = "Північ_Захід";
                }
                if (endPart == "Південна")
                {
                    direction = "Південь_Захід";
                }
            }
            if (part == "Північна")
            {
                if (endPart == "Центральна" || endPart == "Південна")
                {
                    direction = "Південь";
                }
                if (endPart == "Західна")
                {
                    direction = "Захід";
                }
                if (endPart == "Східна")
                {
                    direction = "Південь_Схід";
                }
            }
            if (part == "Південна")
            {
                if (endPart == "Центральна" || endPart == "Північна")
                {
                    direction = "Північ";
                }
                if (endPart == "Західна")
                {
                    direction = "Північ_Захід";
                }
                if (endPart == "Східна")
                {
                    direction = "Північ_Схід";
                }
            }
            return direction;
        }

        private void tabPage7_Click(object sender, EventArgs e)
        {

        }

        private void button23_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void областьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            regionTableAdapter.Update(kursovaDataSet);
            var st = new KursovaDataSet.RegionDataTable();
            try
            {
                regionTableAdapter.FillBy(st, dataGridView4.SelectedRows[0].Cells[0].Value.ToString());
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditRegion(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), row[5].ToString(), row[6].ToString(), row[7].ToString(), row[8].ToString(), row[9].ToString(), row[10].ToString());
                edt.ShowDialog();
                regionTableAdapter.Fill(kursovaDataSet.Region);
                kursovaDataSet.AcceptChanges();
                string zaprosReg = $"SELECT * from region";
                Zapros(ConnectionString, zaprosReg, dataGridView4);
            }
            catch (Exception)
            {
                MessageBox.Show("Оберіть рядок");
                return;
            }
        }

        private void памяткаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            attractionTableAdapter.Update(kursovaDataSet);
            var st = new KursovaDataSet.AttractionDataTable();
            try
            {
                attractionTableAdapter.FillBy(st, Convert.ToInt32(dataGridView3.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditAttraction(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString(), Convert.ToInt32(row[5]));
                edt.ShowDialog();
                attractionTableAdapter.Fill(kursovaDataSet.Attraction);
                kursovaDataSet.AcceptChanges();
                attractionTableAdapter.Update(kursovaDataSet.Attraction);
                string zaprosAttr = $"SELECT * from attraction";
                Zapros(ConnectionString, zaprosAttr, dataGridView3);

            }
            catch (Exception)
            {
                MessageBox.Show("Оберіть рядок");
                return;
            }
        }

        private void вулицяToolStripMenuItem_Click(object sender, EventArgs e)
        {
            streetTableAdapter.Update(kursovaDataSet);
            var st = new KursovaDataSet.StreetDataTable();
            try
            {
                streetTableAdapter.FillBy(st, Convert.ToInt32(dataGridView5.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditStreet(Convert.ToInt32(row[0]), row[1].ToString(), row[2].ToString(), row[3].ToString(), row[4].ToString());
                edt.ShowDialog();
                streetTableAdapter.Fill(kursovaDataSet.Street);
                kursovaDataSet.AcceptChanges();
                streetTableAdapter.Update(kursovaDataSet.Street);
                string zaprosStr = $"SELECT * from street";
                Zapros(ConnectionString, zaprosStr, dataGridView5);

            }
            catch (Exception)
            {
                MessageBox.Show("Оберіть рядок");
                return;
            }

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void будинокToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
            houseTableAdapter1.Update(kursovaDataSet);
            var st = new KursovaDataSet.HouseDataTable();
            try
            {
                houseTableAdapter1.FillBy(st, Convert.ToInt32(dataGridView9.SelectedRows[0].Cells[0].Value));
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditHouse(Convert.ToInt32(row[0]), Convert.ToInt32(row[1]), row[2].ToString());
                edt.ShowDialog();
                houseTableAdapter1.Fill(kursovaDataSet.House);
                kursovaDataSet.AcceptChanges();
                string zaprosHouse = $"SELECT House.House_Id,House.House_Number,Street.Street_Id, Street.Street_Name  FROM House JOIN STREET ON HOUSE.STREET_ID = STREET.STREET_ID";
                Zapros(ConnectionString, zaprosHouse, dataGridView9);

            }
            catch (Exception)
            {
                MessageBox.Show("Оберіть рядок");
                return;
            }
        }

        private void будинокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            houseTableAdapter1.Update(kursovaDataSet);
            
            var edt = new EditHouse();
            edt.ShowDialog();
            string zaprosHouse = $"SELECT House.House_Id,House.House_Number,Street.Street_Id, Street.Street_Name  FROM House JOIN STREET ON HOUSE.STREET_ID = STREET.STREET_ID";
            Zapros(ConnectionString, zaprosHouse, dataGridView9);
            houseTableAdapter1.Update(kursovaDataSet);

            houseTableAdapter1.Update(kursovaDataSet.House);

            kursovaDataSet.AcceptChanges();
        }

        private void памяткаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
              attractionTableAdapter.Update(kursovaDataSet);
            
            var edt = new EditAttraction();
            edt.ShowDialog();
            string zaprosAttr = $"SELECT * from attraction";
            Zapros(ConnectionString, zaprosAttr, dataGridView3);
            attractionTableAdapter.Update(kursovaDataSet);
            attractionTableAdapter.Fill(kursovaDataSet.Attraction);
            kursovaDataSet.AcceptChanges();
        }

        private void областьToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void областьToolStripMenuItem1_Click_1(object sender, EventArgs e)
        {
            regionTableAdapter.Update(kursovaDataSet);

            var edt = new EditRegion();
            edt.ShowDialog();
            string zaprosAttr = $"SELECT * from Region";
            Zapros(ConnectionString, zaprosAttr, dataGridView4);
            regionTableAdapter.Update(kursovaDataSet);
            regionTableAdapter.Fill(kursovaDataSet.Region);
            kursovaDataSet.AcceptChanges();
        }

        private void вулицяToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            streetTableAdapter.Update(kursovaDataSet);

            var edt = new EditStreet();
            edt.ShowDialog();
            string zaprosStr = $"SELECT * from street";
            Zapros(ConnectionString, zaprosStr, dataGridView5);
            streetTableAdapter.Update(kursovaDataSet);
            streetTableAdapter.Fill(kursovaDataSet.Street);
            kursovaDataSet.AcceptChanges();
        }

        private void карантиннаЗонаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            quarantine_ZoneTableAdapter1.Update(kursovaDataSet);
            var st = new KursovaDataSet.Quarantine_ZoneDataTable();
            try
            {
                quarantine_ZoneTableAdapter1.FillBy(st, dataGridView8.SelectedRows[0].Cells[0].Value.ToString());
                object[] row = st.Rows[0].ItemArray;
                var edt = new EditQZ(row[0].ToString(), row[1].ToString());
                edt.ShowDialog();
                quarantine_ZoneTableAdapter1.Fill(kursovaDataSet.Quarantine_Zone);
                kursovaDataSet.AcceptChanges();
                quarantine_ZoneTableAdapter1.Update(kursovaDataSet.Quarantine_Zone);
                string zaprosStr = $"SELECT * from quarantine_zone";
                Zapros(ConnectionString, zaprosStr, dataGridView8);

            }
            catch (Exception)
            {
                MessageBox.Show("Оберіть рядок");
                return;
            }
        }

        private void карантиннаЗонаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            quarantine_ZoneTableAdapter1.Update(kursovaDataSet);

            var edt = new EditQZ();
            edt.ShowDialog();
            string zaprosStr = $"SELECT * from quarantine_zone";
            Zapros(ConnectionString, zaprosStr, dataGridView8);
            quarantine_ZoneTableAdapter1.Update(kursovaDataSet);
            quarantine_ZoneTableAdapter1.Fill(kursovaDataSet.Quarantine_Zone);
            kursovaDataSet.AcceptChanges();
        }

        private void button23_Click_1(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM quarantine_zone WHERE quarantine_zone_name = '{dataGridView8.CurrentRow.Cells[0].Value.ToString()}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                quarantine_ZoneTableAdapter1.Fill(kursovaDataSet.Quarantine_Zone);
                kursovaDataSet.AcceptChanges();
                string zaprosStr = $"SELECT * from quarantine_zone";
                Zapros(ConnectionString, zaprosStr, dataGridView8);
            }
            else
            {
                return;
            }
        }

        private void частинаУкраїниToolStripMenuItem_Click(object sender, EventArgs e)
        {
            part_Of_UkraineTableAdapter.Update(kursovaDataSet);
            var st = new KursovaDataSet.Part_Of_UkraineDataTable();
            try
            {
                part_Of_UkraineTableAdapter.FillBy(st, dataGridView10.SelectedRows[0].Cells[0].Value.ToString());
                object[] row = st.Rows[0].ItemArray;
                int num;
                if (row[1].ToString() == "")
                {
                     num = 0;
                }
                else
                {
                    num = Convert.ToInt32(row[1]);
                }
                var edt = new EditPart(row[0].ToString(), num, row[2].ToString());
                edt.ShowDialog();
                part_Of_UkraineTableAdapter.Fill(kursovaDataSet.Part_Of_Ukraine);
                kursovaDataSet.AcceptChanges();
                string zaprosPart = $"SELECT * from part_of_ukraine";
                Zapros(ConnectionString, zaprosPart, dataGridView10);

            }
            catch (Exception)
            {
                MessageBox.Show("Оберіть рядок");
                return;
            }
        }

        private void частинаУкраїниToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            part_Of_UkraineTableAdapter.Update(kursovaDataSet);

            var edt = new EditPart();
            edt.ShowDialog();
            string zaprosPart = $"SELECT * from part_of_ukraine";
            Zapros(ConnectionString, zaprosPart, dataGridView10);
            part_Of_UkraineTableAdapter.Update(kursovaDataSet);

            part_Of_UkraineTableAdapter.Update(kursovaDataSet.Part_Of_Ukraine);

            kursovaDataSet.AcceptChanges();
        }

        private void tabPage10_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView10_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM part_of_ukraine WHERE part_of_ukraine_name = '{dataGridView10.CurrentRow.Cells[0].Value.ToString()}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                part_Of_UkraineTableAdapter.Fill(kursovaDataSet.Part_Of_Ukraine);
                kursovaDataSet.AcceptChanges();
                string zaprosStr = $"SELECT * from part_of_ukraine";
                Zapros(ConnectionString, zaprosStr, dataGridView10);
            }
            else
            {
                return;
            }
        }

        private void button25_Click(object sender, EventArgs e)
        {
            string zapros = $"DELETE FROM house WHERE house_id = '{dataGridView9.CurrentRow.Cells[0].Value.ToString()}'";
            DialogResult dr = MessageBox.Show("Ви впевнені ?", "Видалити ?", MessageBoxButtons.YesNo);
            if (dr == DialogResult.Yes)
            {
                ZaprosDelete(ConnectionString, zapros);
                houseTableAdapter1.Fill(kursovaDataSet.House);
                kursovaDataSet.AcceptChanges();
                string zaprosHouse = $"SELECT House.House_Id,House.House_Number,Street.Street_Id, Street.Street_Name  FROM House JOIN STREET ON HOUSE.STREET_ID = STREET.STREET_ID";
                Zapros(ConnectionString, zaprosHouse, dataGridView9);
            }
            else
            {
                return;
            }
        }
        List<string> vsHou = new List<string>();
        int countHou;

        private void button27_Click(object sender, EventArgs e)
        {
            countHou = 0;
            numericUpDown7.Value = 0;
            vsHou.Clear();
            for (int i = 0; i < dataGridView9.Rows.Count - 1; i++)
            {

                if (dataGridView9.Rows[i].Cells[1].Value.ToString().Contains(textBox7.Text))
                {
                    vsHou.Add(dataGridView9.Rows[i].Cells[1].Value.ToString());
                    numericUpDown7.Value++;
                }
            }

            for (int j = 0; j < dataGridView9.Rows.Count - 1; j++)
            {

                if (dataGridView9.Rows[j].Cells[1].Value.ToString().Contains(textBox7.Text))
                {
                    dataGridView9.CurrentCell = dataGridView9.Rows[j].Cells[1];
                    break;
                }
            }

        }
        List<string> vsQZ = new List<string>();
        int countQZ;


        private void button26_Click(object sender, EventArgs e)
        {
            countQZ = 0;
            numericUpDown6.Value = 0;
            vsQZ.Clear();
            for (int i = 0; i < dataGridView8.Rows.Count - 1; i++)
            {

                if (dataGridView8.Rows[i].Cells[0].Value.ToString().Contains(textBox6.Text))
                {
                    vsQZ.Add(dataGridView8.Rows[i].Cells[0].Value.ToString());
                    numericUpDown6.Value++;
                }
            }

            for (int j = 0; j < dataGridView8.Rows.Count - 1; j++)
            {

                if (dataGridView8.Rows[j].Cells[0].Value.ToString().Contains(textBox6.Text))
                {
                    dataGridView8.CurrentCell = dataGridView8.Rows[j].Cells[0];
                    break;
                }
            }


        }
        List<string> vsPart = new List<string>();
        int countPart;


        private void button28_Click(object sender, EventArgs e)
        {
            countPart = 0;
            numericUpDown8.Value = 0;
            vsPart.Clear();
            for (int i = 0; i < dataGridView10.Rows.Count - 1; i++)
            {

                if (dataGridView10.Rows[i].Cells[0].Value.ToString().Contains(textBox8.Text))
                {
                    vsPart.Add(dataGridView10.Rows[i].Cells[0].Value.ToString());
                    numericUpDown8.Value++;
                }
            }

            for (int j = 0; j < dataGridView10.Rows.Count - 1; j++)
            {

                if (dataGridView10.Rows[j].Cells[0].Value.ToString().Contains(textBox8.Text))
                {
                    dataGridView10.CurrentCell = dataGridView10.Rows[j].Cells[0];
                    break;
                }
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button29_Click(object sender, EventArgs e)
        {
            string zapros = $"SELECT * FROM CITY ";
            if (checkBox1.Checked == true)
            {
                if(comboBox1.Text != "")
                {
                     zapros += $" WHERE City_Price_Level = '{Convert.ToInt32(comboBox1.Text)}' ";
                    
                }
                else
                {
                    MessageBox.Show("Выберите параметр");
                    return;
                }
            }
            if (checkBox2.Checked == true)
            {
                if (comboBox9.Text != "")
                {
                    if (zapros.Contains("WHERE") || zapros.Contains("where"))
                    {
                        zapros += $" AND region_name = '{comboBox9.Text}' ";

                    }
                    else
                    {
                        zapros += $" WHERE region_name = '{comboBox9.Text}' ";


                    }
                }
                else
                {
                    MessageBox.Show("Выберите параметр");
                    return;
                }
            }
            if (checkBox3.Checked == true)
            {

                    if (zapros.ToLower().Contains("where"))
                    {
                        zapros += $" AND city_population between {trackBar1.Value} and {trackBar2.Value} ";

                    }
                    else
                    {

                        zapros += $" WHERE city_population between {trackBar1.Value} and {trackBar2.Value} ";

                    }
            }

            //int price = Convert.ToInt32(comboBox1.SelectedItem);
            //string zapros = $"SELECT * FROM CITY WHERE City_Price_Level = '{price}'";
            ZaprosFilter(ConnectionString, zapros, dataGridView1);
        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

            
        }

        private void comboBox9_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox9_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select distinct region_name from city", sqlconn);
            
            DataTable dt = new DataTable();
            da.Fill(dt);
            string[] arr = new string[3];
            arr[0] = dt.Rows[0][0].ToString();
            arr[1] = dt.Rows[1][0].ToString();
            List<string> list = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                list.Add(dt.Rows[i][0].ToString());

            }
            for (int i = 0; i < list.Count; i++)
            {
                if (comboBox9.Items.Contains(list[i]))
                {

                }
                else
                {
                    comboBox9.Items.Add(list[i]);

                }

            }
            
            sqlconn.Close();

            
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label12.Text = String.Format(trackBar1.Value.ToString());
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            label13.Text = String.Format(trackBar2.Value.ToString());

        }

        bool d = true;
        private void button30_Click(object sender, EventArgs e)
        {


            if (d == false)
            {
                d = true;
                string zapros = "SELECT CITY_NAME, CITY_POPULATION, CITY_AREA, CITY_FOUNDATION_DATE, CITY_PRICE_LEVEL, CITY_HIGHEST_POINT, CITY_WEBSITE, CITY_INTERESTING_FACT, CITY_WEATHER, REGION_NAME FROM CITY ORDER BY CITY_POPULATION ";
                Zapros(ConnectionString, zapros, dataGridView1);
            }
            else
            {
                d = false;
                string zapros = "SELECT CITY_NAME, CITY_POPULATION, CITY_AREA, CITY_FOUNDATION_DATE, CITY_PRICE_LEVEL, CITY_HIGHEST_POINT, CITY_WEBSITE, CITY_INTERESTING_FACT, CITY_WEATHER, REGION_NAME FROM CITY ORDER BY CITY_POPULATION desc";
                Zapros(ConnectionString, zapros, dataGridView1);

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        bool filter = false;
        private void button31_Click(object sender, EventArgs e)
        {
            //if (asc == true)
            //{
            //    string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id ORDER BY Mayor_Date_Of_Birth";
            //    Zapros(ConnectionString, zapros, dataGridView2);
            //    asc = false;

            //}
            //else if (asc == false)
            //{
            //    string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id ORDER BY Mayor_Date_Of_Birth DESC";
            //    Zapros(ConnectionString, zapros, dataGridView2);
            //    asc = true;

            //}

            /////// 2 variant ///////////
            
            if(filter == false)
            {
                if (asc == true)
                {
                    string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id ORDER BY Mayor_Date_Of_Birth";
                    Zapros(ConnectionString, zapros, dataGridView2);
                    asc = false;

                }
                else if (asc == false)
                {
                    string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id ORDER BY Mayor_Date_Of_Birth DESC";
                    Zapros(ConnectionString, zapros, dataGridView2);
                    asc = true;

                }
            }
            else
            {
                if (asc == true)
                {
                    Zapros(ConnectionString, filterText + " order by mayor.mayor_date_of_birth asc", dataGridView2);
                    asc = false;

                }
                else if (asc == false)
                {
                    Zapros(ConnectionString, filterText + " order by mayor.mayor_date_of_birth desc", dataGridView2);
                    asc = true;

                }
            }
        }
        string filterText;
        private void button32_Click(object sender, EventArgs e)
        {
            string zapros = $"SELECT Mayor.Mayor_Id, Mayor.Mayor_Last_Name, Mayor.Mayor_First_Name, Mayor.Mayor_Patronemic, City_Mayor.City_Name, Mayor.Mayor_Gender, Mayor.Mayor_Date_Of_Birth, Mayor.Mayor_Political_Activity FROM Mayor JOIN CITY_MAYOR ON Mayor.Mayor_Id = CITY_MAYOR.Mayor_Id ";
            if (checkBox4.Checked == true)
            {
                if (comboBox6.Text != "")
                {
                    zapros += $" WHERE City_Mayor.IsActive = '{comboBox6.Text}' ";

                }
                else
                {
                    MessageBox.Show("Выберите параметр");
                    return;
                }
            }
            if (checkBox5.Checked == true)
            {
                if (comboBox2.Text != "")
                {
                    if (zapros.Contains("WHERE") || zapros.Contains("where"))
                    {
                        zapros += $" AND mayor.mayor_gender = '{comboBox2.Text}' ";

                    }
                    else
                    {
                        zapros += $" WHERE mayor.mayor_gender = '{comboBox2.Text}' ";


                    }
                }
                else
                {
                    MessageBox.Show("Выберите параметр");
                    return;
                }
            }
            filterText = zapros;
            filter = true;
            ZaprosFilter(ConnectionString, zapros, dataGridView2);

        }

        private void button21_Click(object sender, EventArgs e)
        {

            string zapros = $"SELECT * FROM attraction ";
            if (checkBox6.Checked == true)
            {
                if (true)
                {
                    zapros += $" WHERE convert(int,attraction_date_of_built) between '{trackBar3.Value}' and '{trackBar4.Value}'";

                }

            }
            ZaprosFilter(ConnectionString, zapros, dataGridView3);

        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            label6.Text = trackBar3.Value.ToString();
            
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            label14.Text = trackBar4.Value.ToString();
        }

        private void button33_Click(object sender, EventArgs e)
        {
            string zapros = $"SELECT * FROM region ";
            if (checkBox7.Checked == true)
            {
                if (comboBox3.Text != "")
                {
                    zapros += $" WHERE region_spoken_language = '{comboBox3.Text}' ";

                }
                else
                {
                    MessageBox.Show("Выберите параметр");
                    return;
                }
            }
            if (checkBox8.Checked == true)
            {
                if (comboBox10.Text != "")
                {
                    if (zapros.Contains("WHERE") || zapros.Contains("where"))
                    {
                        zapros += $" AND quarantine_zone_name = '{comboBox10.Text}' ";

                    }
                    else
                    {
                        zapros += $" WHERE quarantine_zone_name = '{comboBox10.Text}' ";


                    }
                }
                else
                {
                    MessageBox.Show("Выберите параметр");
                    return;
                }
            }
            ZaprosFilter(ConnectionString, zapros, dataGridView4);

        }

        private void comboBox10_MouseClick(object sender, MouseEventArgs e)
        {
            SqlConnection sqlconn = new SqlConnection(ConnectionString);
            sqlconn.Open();
            SqlDataAdapter da = new SqlDataAdapter("select distinct quarantine_zone_name from region", sqlconn);

            DataTable dt = new DataTable();
            da.Fill(dt);
            string[] arr = new string[3];
            arr[0] = dt.Rows[0][0].ToString();
            arr[1] = dt.Rows[1][0].ToString();
            List<string> list = new List<string>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {

                list.Add(dt.Rows[i][0].ToString());

            }
            for (int i = 0; i < list.Count; i++)
            {
                if (comboBox10.Items.Contains(list[i]))
                {

                }
                else
                {
                    comboBox10.Items.Add(list[i]);

                }

            }

            sqlconn.Close();
        }

        private void button34_Click(object sender, EventArgs e)
        {
            string zapros = $"SELECT *  FROM street" +
                $"";
            if (checkBox9.Checked == true)
            {
                if (comboBox11.Text != "")
                {
                    zapros += $" WHERE street.city_name = '{comboBox11.Text}' ";

                }
                else
                {
                    MessageBox.Show("Выберите параметр");
                    return;
                }
            }
            Zapros(ConnectionString, zapros, dataGridView5);


        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button37_Click(object sender, EventArgs e)
        {
            string zaprosPart = $"SELECT * from part_of_ukraine";
            Zapros(ConnectionString, zaprosPart, dataGridView10);

        }

        private void button36_Click(object sender, EventArgs e)
        {
            string zaprosHouse = $"SELECT House.House_Id,House.House_Number,Street.Street_Id, Street.Street_Name  FROM House JOIN STREET ON HOUSE.STREET_ID = STREET.STREET_ID";
            Zapros(ConnectionString, zaprosHouse, dataGridView9);

        }

        private void dataGridView8_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button35_Click(object sender, EventArgs e)
        {
            string zaprosQZ = $"SELECT * FROM Quarantine_Zone";
            Zapros(ConnectionString, zaprosQZ, dataGridView8);

        }

        private void comboBox5_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void button39_Click(object sender, EventArgs e)
        {
            //for (int j = 0; j < dataGridView1.Rows.Count - 1; j++)
            //{

            //    if (dataGridView1.Rows[j].Cells[0].Value.ToString().Contains(textBox1.Text))
            //    {
            //        dataGridView1.CurrentCell = dataGridView1.Rows[j].Cells[0];
            //        break;
            //    }
            //}
            countCity++;
            for (int i = 0; i < dataGridView1.RowCount-1; i++)
            {
                if (vsCity.Count > countCity)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value.ToString() == vsCity[countCity])
                    {
                        dataGridView1.CurrentCell = dataGridView1.Rows[i].Cells[0];
                    }
                }
                    
            }
        }
        int countMayor;
        private void button38_Click(object sender, EventArgs e)
        {
            countMayor++;
            for (int i = 0; i < dataGridView2.RowCount - 1; i++)
            {
                if (vsMayor.Count > countMayor)
                {
                    if (dataGridView2.Rows[i].Cells[1].Value.ToString() == vsMayor[countMayor])
                    {
                        dataGridView2.CurrentCell = dataGridView2.Rows[i].Cells[1];
                    }
                }

            }
        }

        private void button40_Click(object sender, EventArgs e)
        {
            countAttr++;
            for (int i = 0; i < dataGridView3.RowCount - 1; i++)
            {
                if (vsAttr.Count > countAttr)
                {
                    if (dataGridView3.Rows[i].Cells[1].Value.ToString() == vsAttr[countAttr])
                    {
                        dataGridView3.CurrentCell = dataGridView3.Rows[i].Cells[1];
                    }
                }

            }

        }

        private void button41_Click(object sender, EventArgs e)
        {
            countReg++;
            for (int i = 0; i < dataGridView4.RowCount - 1; i++)
            {
                if (vsReg.Count > countReg)
                {
                    if (dataGridView4.Rows[i].Cells[0].Value.ToString() == vsReg[countReg])
                    {
                        dataGridView4.CurrentCell = dataGridView4.Rows[i].Cells[0];
                    }
                }

            }

        }

        private void button42_Click(object sender, EventArgs e)
        {

            countStr++;
            for (int i = 0; i < dataGridView5.RowCount - 1; i++)
            {
                if (vsStr.Count > countStr)
                {
                    if (dataGridView5.Rows[i].Cells[1].Value.ToString() == vsStr[countStr])
                    {
                        dataGridView5.CurrentCell = dataGridView5.Rows[i].Cells[1];
                    }
                }

            }

        }

        private void button43_Click(object sender, EventArgs e)
        {
            countQZ++;
            for (int i = 0; i < dataGridView8.RowCount - 1; i++)
            {
                if (vsQZ.Count > countQZ)
                {
                    if (dataGridView8.Rows[i].Cells[0].Value.ToString() == vsQZ[countQZ])
                    {
                        dataGridView8.CurrentCell = dataGridView8.Rows[i].Cells[0];
                    }
                }

            }

        }

        private void button44_Click(object sender, EventArgs e)
        {
            countHou++;
            for (int i = 0; i < dataGridView9.RowCount - 1; i++)
            {
                if (vsHou.Count > countHou)
                {
                    if (dataGridView9.Rows[i].Cells[1].Value.ToString() == vsHou[countHou])
                    {
                        dataGridView9.CurrentCell = dataGridView9.Rows[i].Cells[1];
                    }
                }

            }

        }

        private void button45_Click(object sender, EventArgs e)
        {
            countPart++;
            for (int i = 0; i < dataGridView10.RowCount - 1; i++)
            {
                if (vsPart.Count > countPart)
                {
                    if (dataGridView10.Rows[i].Cells[0].Value.ToString() == vsPart[countPart])
                    {
                        dataGridView10.CurrentCell = dataGridView10.Rows[i].Cells[0];
                    }
                }

            }

        }

        private void памяткиПоМістамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string zapros = $"select region.region_name, string_agg(attraction.attraction_name, ', ') from attraction join house on house.house_id = attraction.house_id " +
                $"join street on street.street_id = house.street_id join city on street.city_name = city.city_name join region on city.region_name = region.region_name " +
                $"group by region.region_name";

            Request request = new Request(zapros);
            request.Show();
        }
    }
}

