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

namespace BTL_GK.Views
{
    public partial class TrangThaiDon : Form
    {
        //chuỗi kết nối
        string strCon = @"Data Source=DESKTOP-44Q601U\SQLEXPRESS;Initial Catalog=QLBHTBDT;Integrated Security=True;Encrypt=False";
        //tạo đối tượng kết nối
        SqlConnection sqlCon = null;

        //hàm mở kết nối
        private void MoKetNoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
        }

        //hàm đóng kết nối
        private void DongKetNoi()
        {
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }

        public void HienThiDSDH()
        {
            SqlConnection sqlCon = Connection.MoKetNoi();

            //đối tượng kết nối
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from tblDonHang";

            //gắn vào kết nối
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvDonHang.Items.Clear();
            while (reader.Read())
            {
                int maDonHang = reader.GetInt32(0);
                string ngayNhap = reader.GetDateTime(1).ToString("MM/dd/yyyy");
                decimal tongTien = reader.GetDecimal(2);
                string tenKH = reader.GetString(3);
                string soDT = reader.GetString(4);
                string diaChi = reader.GetString(5);
                int maTrangThai = reader.GetInt32(6);
                string maNV = reader.GetString(7);

                //tạo bảng và thêm dữ liệu
                ListViewItem lvi = new ListViewItem(maDonHang.ToString());
                lvi.SubItems.Add(ngayNhap);
                lvi.SubItems.Add(tongTien.ToString("#,0.000"));
                lvi.SubItems.Add(tenKH);
                lvi.SubItems.Add(soDT);
                lvi.SubItems.Add(diaChi);
                lvi.SubItems.Add(maTrangThai.ToString());
                lvi.SubItems.Add(maNV);
                lsvDonHang.Items.Add(lvi);

            }
            reader.Close();


        }
        public TrangThaiDon()
        {
            InitializeComponent();
        }

        private void TrangThaiDon_Load(object sender, EventArgs e)
        {
            HienThiDSDH();
            txtMaDonHang.Enabled = false;
            grbCapNhat.Enabled = false;
        }

        private void CapNhatTT()
        {
             SqlConnection sqlCon = Connection.MoKetNoi();
            //lấy dữ liệu từ form
            string maTrangThai = txtTrangThai.Text.Trim();
            string diaChi = txtDiaChi.Text.Trim();
            string soDienThoai = txtSDT.Text.Trim();
            string maDonHang=txtMaDonHang.Text.Trim();

            //đối tượng truy vấn
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update tblDonHang set MaTrangThai='" + maTrangThai + "',DiaChi=N'" + diaChi + "',SoDienThoai=N'" + soDienThoai + "' where MaDonHang='" + maDonHang + "'";

            //gắn vào kết nối
            sqlCmd.Connection = sqlCon;

            //thực thi truy vấn
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Cập nhật trạng thái thành công");
                HienThiDSDH();
                
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái không thành công");
                HienThiDSDH();              
            }
            
        }

        private void XoaDL()
        {
            txtMaDonHang.Clear();
            txtTrangThai.Clear();
            txtDiaChi.Clear();
            txtSDT.Clear();
        }

        public void HienThiDSSanPhamDaMua()
        {
            try
            {
                 SqlConnection sqlCon = Connection.MoKetNoi();

                string maDonHang = txtMaDonHang.Text.Trim();

                // Tạo đối tượng truy vấn
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "SELECT MaSP, TenSP, SoLuong, GiaTien FROM ChiTietDonHang WHERE MaDonHang = '"+maDonHang+"'";               
                sqlCmd.Connection = sqlCon;
                SqlDataReader reader = sqlCmd.ExecuteReader();

                // Xóa dữ liệu cũ trong ListView 
                lsvDSSanPhamDaMua.Items.Clear();

                while (reader.Read())
                {
                    string maSanPham = reader.GetString(0);
                    string tenSanPham = reader.GetString(1);
                    int soLuong = reader.GetInt32(2);
                    decimal donGia = reader.GetDecimal(3);

                    // Tạo ListViewItem và thêm dữ liệu
                    ListViewItem lvi = new ListViewItem(maSanPham);
                    lvi.SubItems.Add(tenSanPham);
                    lvi.SubItems.Add(soLuong.ToString());
                    lvi.SubItems.Add(donGia.ToString("#,0.000"));

                    lsvDSSanPhamDaMua.Items.Add(lvi);
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CapNhatTT();
            grbCapNhat.Enabled = false;
            XoaDL();
        }

        private void lsvDonHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDonHang.SelectedItems.Count == 0) return;
            ListViewItem lvi = lsvDonHang.SelectedItems[0];
            txtTrangThai.Text = lvi.SubItems[6].Text.Trim();
            txtDiaChi.Text = lvi.SubItems[5].Text.Trim();
            txtSDT.Text = lvi.SubItems[4].Text.Trim();
            txtMaDonHang.Text = lvi.SubItems[0].Text.Trim();

            string maDonHang = lvi.SubItems[0].Text.Trim();
            HienThiDSSanPhamDaMua();
            grbCapNhat.Enabled = true;
        }
        private void txtMaDonHang_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            XoaDL();
            grbCapNhat.Enabled=false;
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            CapNhatTT();
            grbCapNhat.Enabled = false;
            XoaDL();
            lsvDSSanPhamDaMua.Items.Clear();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            grbCapNhat.Enabled = false;
            XoaDL();
            lsvDSSanPhamDaMua.Items.Clear();
        }

        private void XoaDonHang()
        {
            
            SqlConnection sqlCon = Connection.MoKetNoi();
            string maSP_xoa = lsvDonHang.SelectedItems[0].SubItems[0].Text.Trim();

            //đối tượng truy vấn 
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from tblDonHang where MaDonHang='" + maSP_xoa + "'";

            //gắn vào kết nối 
            sqlCmd.Connection = sqlCon;

            //thưc thi truy vấn
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Xóa đơn hàng thành công");
                HienThiDSDH();
            }
            else
            {
                MessageBox.Show("Xóa đơn hàng không thành công");
                HienThiDSDH();
            }
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa đơn hàng này không?",
                                          "Xác nhận xóa",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }

            XoaDonHang();
            XoaDL();
            grbCapNhat.Enabled = false;
        }
    }
}
