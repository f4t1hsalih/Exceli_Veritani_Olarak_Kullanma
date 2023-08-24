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

        private void btnListele_Click(object sender, EventArgs e)
        {
            Listele();
        }
    }
}