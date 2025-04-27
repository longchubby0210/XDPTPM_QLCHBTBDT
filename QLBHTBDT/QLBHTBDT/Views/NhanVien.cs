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
    public partial class NhanVien : Form
    {
        //2 đối tượng kết nối
        string strCon = @"Data Source=DESKTOP-44Q601U\SQLEXPRESS;Initial Catalog=QLBHTBDT;Integrated Security=True;Encrypt=False";
        SqlConnection sqlCon = null;

        //hàm mở kết nôi,đóng kết nối
        private void MoKetNoi()
        {
            if (sqlCon == null) sqlCon = new SqlConnection(strCon);
            if (sqlCon.State == ConnectionState.Closed) sqlCon.Open();
        }

        private void DongKetNoi()
        {
            if (sqlCon.State == ConnectionState.Open) sqlCon.Close();
        }



        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            grbThongTinChiTiet.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
            HienDSNV();
            cbbGioiTinh.SelectedItem = "Nam";

        }

        //load danh sánh từ csdl
        private void HienDSNV()
        {
            SqlConnection sqlCon = Connection.MoKetNoi();

            // đối tượng truy vấn
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from tblNhanVien";

            //gắn vào kết nối
            sqlCmd.Connection = sqlCon;

            //thực thi truy vấn
            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvDSNV.Items.Clear();
            while (reader.Read())
            {
                string maNV = reader.GetString(0);
                string tenNV = reader.GetString(1);
                string ngaySinh = reader.GetDateTime(2).ToString("MM/dd/yyyy");
                string gioiTinh = reader.GetString(3);
                string soDT = reader.GetString(4);
                string diaChi = reader.GetString(5);
                decimal luong = reader.GetDecimal(6);

                ListViewItem lvi = new ListViewItem(maNV);
                lvi.SubItems.Add(tenNV);
                lvi.SubItems.Add(ngaySinh);
                lvi.SubItems.Add(gioiTinh);
                lvi.SubItems.Add(soDT);
                lvi.SubItems.Add((diaChi));
                lvi.SubItems.Add(luong.ToString("0.000"));

                lsvDSNV.Items.Add(lvi);
            }
            reader.Close();
            Connection.DongKetNoi(sqlCon);

        }

        //phan chia 
        int chucNang = 0;

        private void btnSua_Click(object sender, EventArgs e)
        {
            chucNang = 2;
            grbThongTinChiTiet.Enabled = true;
            txtMaNV.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chucNang == 1)
            {
                ThemNhanVien();
            }
            else if (chucNang == 2)
            {
                SuaNhanVien();

            }
        }

        //hàm xóa dữ liệu form
        private void XoaDLForm()
        {
            txtDiaChi.Clear();
            txtLuong.Clear();
            txtMaNV.Clear();
            txtTenNV.Clear();
            txtSDT.Clear();
        }

        //hàm thêm nhân viên
        private void ThemNhanVien()
        {
             SqlConnection sqlCon= Connection.MoKetNoi();
          
            //lấy dữ liệu từ form
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();
            string gioiTinh = cbbGioiTinh.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.Year + "-" + dtpNgaySinh.Value.Month + "-" + dtpNgaySinh.Value.Day;
            string diaChi = txtDiaChi.Text.Trim();
            string soDT = txtSDT.Text.Trim();
            decimal luong;
            if (!decimal.TryParse(txtLuong.Text.Trim(), out luong))
            {
                MessageBox.Show("Vui lòng nhập lương là một số hợp lệ.");
                return;
            }
            //kiểm tra rỗng
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }
            else if (string.IsNullOrEmpty(tenNV))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }
            else if (string.IsNullOrEmpty(diaChi))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }
            else if (string.IsNullOrEmpty(soDT))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }



             try
            {
                // Tạo câu lệnh SQL với tham số
                string sql = "INSERT INTO tblNhanVien (MaNV, HoTen, NgaySinh, GioiTinh, DiaChi, SoDienThoai, Luong) " +
                             "VALUES (@maNV, @hoTen, @ngaySinh, @gioiTinh, @diaChi, @soDT, @luong)";

                // Đối tượng SqlCommand
                SqlCommand sqlCmd = new SqlCommand(sql, sqlCon);

                // Thêm tham số vào câu lệnh SQL
                sqlCmd.Parameters.AddWithValue("@maNV", maNV);
                sqlCmd.Parameters.AddWithValue("@hoTen", tenNV);
                sqlCmd.Parameters.AddWithValue("@ngaySinh", DateTime.Parse(ngaySinh));
                sqlCmd.Parameters.AddWithValue("@gioiTinh", gioiTinh);
                sqlCmd.Parameters.AddWithValue("@diaChi", diaChi);
                sqlCmd.Parameters.AddWithValue("@soDT", soDT);
                sqlCmd.Parameters.AddWithValue("@luong", luong);
                //gắn vào kết nối
                sqlCmd.Connection = sqlCon;

                //thực thi truy vấn
                int kq = sqlCmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Thêm nhân viên thành công!");
                    HienDSNV();
                    XoaDLForm();
                    grbThongTinChiTiet.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Thêm nhân viên thât bại!");
                    HienDSNV();
                    XoaDLForm();
                    grbThongTinChiTiet.Enabled = false;
                    btnSua.Enabled = false;
                    btnXoa.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
            finally
            {
                Connection.DongKetNoi(sqlCon);
            }
        }

        //hàm sửa nhân viên
        private void SuaNhanVien()
        {
            SqlConnection sqlCon = Connection.MoKetNoi();

            //lấy dữ liệu từ form
            string maNV = txtMaNV.Text.Trim();
            string tenNV = txtTenNV.Text.Trim();
            string gioitinh = cbbGioiTinh.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.Year + "-" + dtpNgaySinh.Value.Month + "-" + dtpNgaySinh.Value.Day;
            string diaChi = txtDiaChi.Text.Trim();
            string soDT = txtSDT.Text.Trim();
            decimal luong;
            if (!decimal.TryParse(txtLuong.Text.Trim(), out luong))
            {
                MessageBox.Show("Vui lòng nhập lương là một số hợp lệ.");
                return;
            }



            //đối tượng truy vấn
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update tblNhanVien set HoTen=N'" + tenNV + "',NgaySinh=CONVERT(datetime, '" + ngaySinh + "'),GioiTinh = N'" + gioitinh + "',DiaChi=N'" + diaChi + "',SoDienThoai=N'" + soDT + "',Luong=" + luong.ToString("0.000") + " where MaNV='" + maNV + "'";

            //gắn vào kết nối
            sqlCmd.Connection = sqlCon;

            //thực thi truy vấn
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Sửa nhân viên thành công!");
                HienDSNV();
                XoaDLForm();
                grbThongTinChiTiet.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            else
            {
                MessageBox.Show("Sửa nhân viên thât bại!");
                HienDSNV();
                XoaDLForm();
            }
            Connection.DongKetNoi(sqlCon);
        }
        //lấy dữ liệu từ list hiện thi
        private void lsvDSNV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsvDSNV.SelectedItems.Count == 0) return;
            ListViewItem lvi = lsvDSNV.SelectedItems[0];
            txtMaNV.Text = lvi.SubItems[0].Text.Trim();
            txtTenNV.Text = lvi.SubItems[1].Text.Trim();
            string[] ns = lvi.SubItems[2].Text.Split('/');
            try
            {
                dtpNgaySinh.Value = new DateTime(int.Parse(ns[2]), int.Parse(ns[0]), int.Parse(ns[1]));
            }
            catch(Exception ex) 
            {
                MessageBox.Show("Có lỗi xảy ra: Lỗi định dạng ngày tháng");
            }

            dtpNgaySinh.Value = new DateTime(int.Parse(ns[2]), int.Parse(ns[0]), int.Parse(ns[1]));
            cbbGioiTinh.Text = lvi.SubItems[3].Text.Trim();
            txtDiaChi.Text = lvi.SubItems[4].Text.Trim();
            txtSDT.Text = lvi.SubItems[5].Text.Trim();
            txtLuong.Text = lvi.SubItems[6].Text.Trim();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            txtMaNV.Enabled = true;
            grbThongTinChiTiet.Enabled=false;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa nhân viên này không?",
                                          "Xác nhận xóa",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return;
            }
            SqlConnection sqlCon=Connection.MoKetNoi();
            string maNV_xoa = lsvDSNV.SelectedItems[0].SubItems[0].Text.Trim();

            //đối tượng truy vấn 
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "delete from tblNhanVien where MaNV='" + maNV_xoa + "'";

            //gắn vào kết nối 
            sqlCmd.Connection = sqlCon;

            //thưc thi truy vấn
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Xóa nhân viên thành công");
                HienDSNV();
            }
            else
            {
                MessageBox.Show("Xóa nhân viên không thành công");
                HienDSNV();
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaDLForm();
            grbThongTinChiTiet.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            chucNang = 1;
            XoaDLForm();
            txtMaNV.Enabled = true;
            grbThongTinChiTiet.Enabled = true;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
    }
}
