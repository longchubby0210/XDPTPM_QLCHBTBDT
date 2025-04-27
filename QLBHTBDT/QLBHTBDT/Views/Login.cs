
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_GK.Views
{
    public partial class Login : Form
    {
          //chuỗi kết nối
          string strCon = @"Data Source=DESKTOP-44Q601U\SQLEXPRESS;Initial Catalog=QLBHTBDT;Integrated Security=True;Encrypt=False";
          //đối tượng kết nối
          SqlConnection sqlCon= null;

          //hàm mở kết nối
          private void MoKetNoi()
          {
              if(sqlCon == null) sqlCon = new SqlConnection(strCon);
              if (sqlCon.State == ConnectionState.Closed) sqlCon.Open() ;
          }

          //hàm đóng kết nôi
          private void DongKetNoi()
          {
              if(sqlCon.State==ConnectionState.Open) sqlCon.Close() ;
          }

       


        public Login()
        {
            InitializeComponent();
            chkHienMatKhau.Checked = false;   
           
        }
        private void Login_Load(object sender, EventArgs e)
        {
            
            txtDangNhap.Focus();
        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
        //hàm kiểm tra đăng nhập
             public int CheckLogin(string username, string password) {

            // MoKetNoi();

            SqlConnection sqlCon = Connection.MoKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = System.Data.CommandType.Text;
                sqlCmd.CommandText = "select Role from tblLogin where Name ='" + username + "' and Pass='" + password + "'";



                //gan vao chuoi ket noi
                sqlCmd.Connection = sqlCon;

                //nhận kết quả

                object rs = sqlCmd.ExecuteScalar();
                return rs != null ? Convert.ToInt32(rs) : -1;

             }
        
        

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtDangNhap.Text.Trim();
            string password = txtMatKhau.Text.Trim();

            int role = CheckLogin(username, password);  
            if (role == -1)
            {
                lblLoi.Text = "Sai tài khoản hoặc mật khẩu";
                lblLoi.Visible = true;

            }
            else if (role == 1)
            {
                this.Hide();
                Admin adminForm = new Admin(role);
                adminForm.ShowDialog();
                this.Close();

            }
            else if (role == 2)
            {
                this.Hide();
                Admin adminForm = new Admin(role);
                adminForm.ShowDialog();
                this.Close();
            }
        }

        private void txtDangNhap_KeyDown(object sender, KeyEventArgs e)
        {
            //nếu phím enter được nhấn
            if (e.KeyCode == Keys.Enter)
            {
                txtMatKhau.Focus();
            }
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            //nếu phím enter được nhấn 
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap_Click(sender, e);
            }
        }

       
    }
}
