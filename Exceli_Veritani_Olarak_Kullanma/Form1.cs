using System.Data;
using System.Data.OleDb;

namespace Exceli_Veritani_Olarak_Kullanma
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Yazilim\\C#\\Exceli_Veritani_Olarak_Kullanma\\Exceli_Veritani_Olarak_Kullanma\\Belge.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;'");

        private void Temizle()
        {
            txtSaat.Clear();
            txtDersAdi.Clear();
        }

        private void Listele()
        {
            con.Open();
            string komut = "Select * from [Sayfa1$]";
            OleDbDataAdapter da = new OleDbDataAdapter(komut, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void Kaydet()
        {
            con.Open();
            string komut = "Insert into [Sayfa1$] (SAAT, DERS) values (@p1, @p2)";
            OleDbCommand cmd = new OleDbCommand(komut, con);
            cmd.Parameters.AddWithValue("@p1", txtSaat.Text);
            cmd.Parameters.AddWithValue("@p2", txtDersAdi.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Kayýt Baþarýyla Yapýldý");
            Listele();
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            Kaydet();
            Temizle();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}