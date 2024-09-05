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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection z = new SqlConnection("server=.; Initial Catalog=market;Integrated Security=SSPI");
            SqlCommand x = new SqlCommand("insert into  urunalis (ürünkodu,adet, fiyat, tarih, firma, tür) values(@ürünkodu,@adet,@fiyat,@tarih,@firma,@tür)", z);

            x.Parameters.AddWithValue("@ürünkodu",textBox1.Text);
            x.Parameters.AddWithValue("@adet", Convert.ToInt32(textBox2.Text));
            x.Parameters.AddWithValue("@fiyat", textBox3.Text);
            x.Parameters.AddWithValue("@tarih", textBox4.Text);
            x.Parameters.AddWithValue("@firma", textBox5.Text);
            x.Parameters.AddWithValue("@tür", textBox6.Text);

            z.Open();
            x.ExecuteNonQuery();
            MessageBox.Show("Kayıt eklendi");
            z.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
