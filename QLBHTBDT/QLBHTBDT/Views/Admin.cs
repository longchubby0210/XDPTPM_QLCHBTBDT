using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTL_GK.Views
{
    public partial class Admin : Form
    {
        private int UserRole;
        
        public Admin(int role)
        {
            InitializeComponent();
            UserRole = role;
        }


        //Load Form Product
        private void LoadChildForm(Form childFrom)
        {
            //xóa controll cũ trên form
            mainPanel.Controls.Clear();

            //thiết lập child form
            childFrom.TopLevel = false;
            childFrom.FormBorderStyle = FormBorderStyle.None;
            childFrom.Dock= DockStyle.Fill;

            mainPanel.Controls.Add(childFrom);
            childFrom.Show();
        }

        private void BtnLoadFormPD_Click(object sender, EventArgs e)
        {
            Product productForm = new Product();

            LoadChildForm(productForm);
        }

        private void BtnLoadFormDH_Click(object sender, EventArgs e)
        {
            DonHang donHangForm = new DonHang();

            LoadChildForm(donHangForm);
        }

      
         

        private void BtnLoadFormTK_Click(object sender, EventArgs e)
        {
            ThongKe thongKeForm = new ThongKe();

            LoadChildForm(thongKeForm);
        }

        private void LblThoat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc chắn muốn thoát không",
               "Hộp thoại",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                Close();
            }
        }

        private void LlbDangXuat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            DialogResult result = MessageBox.Show(
               "Bạn có chắc chắn muốn đăng xuất không",
               "Hộp thoại",
               MessageBoxButtons.YesNo,
               MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                this.Hide();
                Login loginForm = new Login();
                loginForm.ShowDialog();
                //Close();
                this.Close();
            }
            //đóng form hiện tại
            
            //mở lại form Login
            
           
        }

        //hàm ẩn chức năng nếu là Staff
        public void HideStaffFuncion()
        {
            btnLoadFormTTD.Visible = false;
            btnLoadFormTK.Visible = false;
            btnNhanVien.Visible= false;
        }

        private void Admin_Load(object sender, EventArgs e)
        {
            lbHelloRole.Text = UserRole == 1 ? "Admin!" : "Staff!";
            lblRole.Text = UserRole == 1 ? "Vai trò: Admin" : "Vai trò: Staff";
     
            //nếu là Staff thì ẩn nút 
            if (UserRole == 2) 
            { 
                HideStaffFuncion();
            }
        }

        private void BtnLoadFormTTD_Click(object sender, EventArgs e)
        {
            TrangThaiDon trangThaiDon = new TrangThaiDon();

            LoadChildForm(trangThaiDon);
        }

        private void BtnNhanVien_Click(object sender, EventArgs e)
        {
            NhanVien nhanVien = new NhanVien();

            LoadChildForm(nhanVien);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
