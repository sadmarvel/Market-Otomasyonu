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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection z = new SqlConnection("server=.; Initial Catalog=market;Integrated Security=SSPI");
            SqlCommand x = new SqlCommand("UPDATE urunalis SET adet=@adet, fiyat=@fiyat, tarih=@tarih, firma=@firma, tür=@tür WHERE ürünkodu = @kod", z);

            x.Parameters.AddWithValue("@kod", textBox1.Text);
            x.Parameters.AddWithValue("@adet", Convert.ToInt32(textBox2.Text));
            x.Parameters.AddWithValue("@fiyat", textBox3.Text);
            x.Parameters.AddWithValue("@tarih", textBox4.Text);
            x.Parameters.AddWithValue("@firma", textBox5.Text);
            x.Parameters.AddWithValue("@tür", textBox6.Text);
          

            z.Open();
            x.ExecuteNonQuery();
            MessageBox.Show("Kayıt güncellendi");
            z.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
