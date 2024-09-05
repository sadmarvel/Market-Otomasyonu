using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace market
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            button4.Visible = false;
            groupBox4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           Form4 form4 = new Form4();
            form4.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {



            SqlConnection x = new SqlConnection("server=.; Initial Catalog=market;Integrated Security=SSPI");
            SqlCommand y = new SqlCommand("insert into urunalis(ürünkodu,adet,fiyat) values(@kod,@adet,@fiyat)", x);
            y.Parameters.AddWithValue("@kod", textBox1.Text);
            y.Parameters.AddWithValue("@adet", int.Parse(textBox2.Text));
            y.Parameters.AddWithValue("@fiyat", textBox3.Text);
            x.Open();
            y.ExecuteNonQuery();
            MessageBox.Show("Kayıt işlemi başarılı");
            x.Close();

        }


        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

            string kullaniciAdi = "admin";
            string sifre = "sifre123";
            if (textBox4.Text == kullaniciAdi && textBox5.Text == sifre)
            {
                try
                {
                    groupBox1.Visible = true;
                    groupBox2.Visible = true;
                    groupBox3.Visible = false;
                    button4.Visible = true;
                    groupBox4.Visible = true;
                    groupBox5.Visible = true;
                    groupBox6.Visible = true;
                    button9.Visible = true;
                }
                catch {
                    MessageBox.Show("Bir hata oluştu!");
                    }
            }
            else
            { MessageBox.Show("Kullanıcı Adı veya Şifre Yanlış");

            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void button5_Click(object sender, EventArgs e)
        {

            Form2 form2 = new Form2();
            form2.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SqlConnection z = new SqlConnection("server=.; Initial Catalog=market;Integrated Security=SSPI");
            SqlCommand x = new SqlCommand("DELETE FROM urunalis WHERE işlemno = (SELECT MAX(işlemno) FROM urunalis)", z);

            z.Open();
            x.ExecuteNonQuery();
            MessageBox.Show("Son kayıt silindi");
            z.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SqlConnection z = new SqlConnection("server=.; Initial Catalog=market;Integrated Security=SSPI");
            SqlCommand x = new SqlCommand("delete from urunalis where ürünkodu=@kod", z);
            x.Parameters.AddWithValue("@kod",textBox6.Text);
            z.Open();
            x.ExecuteNonQuery();
            MessageBox.Show("Kayıt silindi");
            z.Close();
        }

        private void button8_Click(object sender, EventArgs e)
        {

            Form3 form3 = new Form3();
            form3.Show();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            groupBox1.Visible = false;
            groupBox2.Visible = false;
            groupBox3.Visible = true;
            groupBox4.Visible = false;
            textBox4.Text = "";
            textBox5.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            button4.Visible = false;
            groupBox5.Visible = false;
            groupBox6.Visible = false;
            button9.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button9.Visible=false;
        }
    }
}

