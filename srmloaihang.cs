using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QLBH
{
    public partial class srmloaihang : Form
    {
        public srmloaihang()
        {
            InitializeComponent();
        }

        public string chuoikn = "server =LAPTOP-HLCQIVNQ" + ";database = QLNH; uid = sa; pwd = 123456";
        SqlConnection conn;

        public void load()
        {
            string load_loaihang = "select* from LOAIHANG";
            conn = new SqlConnection(chuoikn);
            conn.Open();
            SqlDataAdapter ad = new SqlDataAdapter(load_loaihang, conn);
            DataTable tbl = new DataTable();
            ad.Fill(tbl);
            dataGridView1.DataSource = tbl.DefaultView;
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void them_Click(object sender, EventArgs e)
        {
            textma.Text = "";
            textten.Text = "";
            textma.Enabled = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void srmloaihang_Load(object sender, EventArgs e)
        {
            load();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string thoat = MessageBox.Show("Bạn có muốn thoát Form?",
                "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question).ToString();
            if(thoat == "Yes")
                Close();
        }

        private void luu_Click(object sender, EventArgs e)
        {
            if(textma.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại hàng");
                textma.Focus();
            }else if(textten.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại hàng ");
                textten.Focus();
            }
            else
            {
                conn = new SqlConnection(chuoikn);
                conn.Open();
                string them = "insert into LOAIHANG values('" + textma.Text + "',N'" + textten.Text + "')";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = them;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công");
                load();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void sua_Click(object sender, EventArgs e)
        {
            if (textma.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập mã loại hàng");
                textma.Focus();
            }
            else if (textten.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập tên loại hàng ");
                textten.Focus();
            }
            else
            {
                conn = new SqlConnection(chuoikn);
                conn.Open();
                string sua = "update LOAIHANG set TENLOAIHANG = N'"+ textten.Text +"' where MALOAIHANG ='"+ textma.Text+"' ";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = sua;
                cmd.ExecuteNonQuery();
                MessageBox.Show("Lưu thành công");
                load();
            }
        }

        private void xoa_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(chuoikn);
            conn.Open();
            string xoa = "delete from lOAIHANG where MALOAIHANG ='" + textma.Text + "' ";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = xoa;
            cmd.ExecuteNonQuery();
            MessageBox.Show("Xoa thành công");
            load();
        }

        private void textma_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textma.Enabled = false;
            for(int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if (dataGridView1.Rows[i].Selected)
                {
                    textma.Text = dataGridView1.Rows[i].Cells[0].ToString();
                    textten.Text = dataGridView1.Rows[i].Cells[0].ToString();
                }
            }
        }
    }
}
