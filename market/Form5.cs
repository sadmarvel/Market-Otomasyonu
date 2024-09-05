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

namespace market
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
           
            dataGridView1.Visible = true;
            string connectionString = "server =.; Initial Catalog = market; Integrated Security = SSPI";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM urunalis";

                List<string> conditions = new List<string>();
                List<SqlParameter> parameters = new List<SqlParameter>();

                if (!string.IsNullOrEmpty(textBox1.Text))
                {
                    conditions.Add("ürünkodu LIKE @ürünkodu");
                    parameters.Add(new SqlParameter("@ürünkodu", "%" + textBox1.Text + "%"));
                }
                if (!string.IsNullOrEmpty(textBox2.Text))
                {
                    conditions.Add("adet LIKE @adet2");
                    parameters.Add(new SqlParameter("@adet2", "%" + textBox2.Text + "%"));
                }
                if (!string.IsNullOrEmpty(textBox3.Text))
                {
                    conditions.Add("fiyat LIKE @fiyat");
                    parameters.Add(new SqlParameter("@fiyat", "%" + textBox3.Text + "%"));
                }
                if (!string.IsNullOrEmpty(textBox4.Text))
                {
                    conditions.Add("tarih LIKE @tarih");
                    parameters.Add(new SqlParameter("@tarih", "%" + textBox4.Text + "%"));
                }
                if (!string.IsNullOrEmpty(textBox5.Text))
                {
                    conditions.Add("firma LIKE @firma");
                    parameters.Add(new SqlParameter("@firma", "%" + textBox5.Text + "%"));
                }
                if (!string.IsNullOrEmpty(textBox6.Text))
                {
                    conditions.Add("tür LIKE @tür");
                    parameters.Add(new SqlParameter("@tür", "%" + textBox6.Text + "%"));
                }

                if (conditions.Count > 0)
                {
                    query += " WHERE " + string.Join(" AND ", conditions);
                }

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }

                    SqlDataReader reader = command.ExecuteReader();

                    DataTable dataTable = new DataTable();
                    dataTable.Load(reader);

                    dataGridView1.DataSource = dataTable;

                }
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
        dataGridView1.Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

