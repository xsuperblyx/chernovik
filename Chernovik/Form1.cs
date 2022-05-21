using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Chernovik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static string str = "server=localhost;user=root;password=1337;database=черновик;port=3306";
        MySqlConnection con = new MySqlConnection(str);

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "SELECT * FROM черновик.materials where id_material < 2;";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql,con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }
        int x = 1; // счетчик для щелчков вперед назад

        private void label1_Click(object sender, EventArgs e) // вперед
        {
            x++;
            if (x == 4)
            {
                x--;
            }
            if (x == 2)
            {
                label3.Text = "2/3";
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM черновик.materials where id_material < 3 and id_material > 1;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (x == 3)
            { 
                label3.Text = "3/3";
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM черновик.materials where id_material < 4 and id_material > 2;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

        }

        private void label2_Click(object sender, EventArgs e) // назад
        {
            x--;
            if (x==0)
            {
                x++;
                label3.Text = "1/3";
            }
            if (x == 2) 
            {
                label3.Text = "2/3";
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM черновик.materials where id_material < 3 and id_material > 1;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            if (x == 1)
            {
                label3.Text = "1/3";
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM черновик.materials where id_material < 2 and id_material > 0;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }


        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                string sql = "SELECT * FROM черновик.materials where name like '%" + textBox1.Text.ToString() + "%';";
                MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex==0) // по имени
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM черновик.materials ORDER BY name;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

            }
            if (comboBox1.SelectedIndex == 1) // по цене возрастание
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM черновик.materials ORDER BY price ASC;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }

            if (comboBox1.SelectedIndex == 2) // по цене убывание
            {
                try
                {
                    con.Open();
                    string sql = "SELECT * FROM черновик.materials ORDER BY price DESC;";
                    MySqlDataAdapter adapter = new MySqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }
    }
}
