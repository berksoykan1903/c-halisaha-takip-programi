using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace berksoykan_performans_144
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void databaslat()
        {
            SQLiteConnection baglanti =
                new SQLiteConnection("Data Source=C:\\Users\\PC\\Desktop\\Yazılım\\halisahatakip.db;version=3");
            baglanti.Open();
            SQLiteDataAdapter da =
                new SQLiteDataAdapter("SELECT * FROM halisahatakip", baglanti);
            DataSet ds = new DataSet();
            da.Fill(ds, "halisahatakip");
            dataGridView1.DataSource = ds.Tables["halisahatakip"];
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglanti =
                    new SQLiteConnection("Data Source=C:\\Users\\PC\\Desktop\\Yazılım\\halisahatakip.db;version=3");
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand();
                komut.Connection = baglanti;
                komut.CommandText =
                    "INSERT INTO halisahatakip VALUES('" + textBox1.Text + "','" +
                    textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "', '"+textBox5.Text+"')";
                komut.ExecuteNonQuery();
                baglanti.Close();
                databaslat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA ! " + ex.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            databaslat();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SQLiteConnection baglanti =
                    new SQLiteConnection("Data Source=C:\\Users\\PC\\Desktop\\Yazılım\\halisahatakip.db;version=3");
                baglanti.Open();
                SQLiteCommand komut = new SQLiteCommand();
                komut.Connection = baglanti;
                komut.CommandText =
                    "DELETE FROM halisahatakip WHERE takim1='" + textBox1.Text + "'";
                komut.ExecuteNonQuery();
                baglanti.Close();
                databaslat();
            }
            catch (Exception ex)
            {
                MessageBox.Show("HATA : " + ex.Message);
            }
            finally
            {
                textBox5.Clear();
            }
        }
    }
}
