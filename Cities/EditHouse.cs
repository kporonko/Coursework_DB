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
    public partial class EditHouse : Form
    {
        bool edit = false;
        int id;
        public EditHouse()
        {
            InitializeComponent();
            houseTableAdapter1.Fill(kursovaDataSet.House);
            button1.Visible = false;
            button2.Visible = true;
        }
        public EditHouse(int house_id, int houseNumber, string street_name): this()
        {
            edit = true;
            textBox1.Text = house_id.ToString();
            textBox2.Text = houseNumber.ToString();
            button2.Visible = false;
            button1.Visible = true;
            id = Convert.ToInt32(street_name);
            //label5.Text = 
        }

        private void EditHouse_Load(object sender, EventArgs e)
        {
            // TODO: данная строка кода позволяет загрузить данные в таблицу "kursovaDataSet.Street". При необходимости она может быть перемещена или удалена.
            this.streetTableAdapter.Fill(this.kursovaDataSet.Street);
            if (edit)
            {
                comboBox1.SelectedValue = id;

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                houseTableAdapter1.UpdateQuery(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text) ,Convert.ToInt32(comboBox1.SelectedValue));

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
                houseTableAdapter1.InsertQuery(Convert.ToInt32(textBox1.Text), Convert.ToInt32(textBox2.Text), Convert.ToInt32(comboBox1.SelectedValue));

            }
            catch (Exception)
            {

                MessageBox.Show("Ви ввели неправильні дані");
            }
            this.Close();
        }
    }
}
