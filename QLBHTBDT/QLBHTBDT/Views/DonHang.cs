using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


namespace BTL_GK.Views
{
    public partial class DonHang : Form
    {
        private void LoadChildForm(Form childFrom)
        {

            childFrom.Show();
        }

        //tạo 2 biến cục bộ
        string strCon = @"Data Source=DESKTOP-44Q601U\SQLEXPRESS;Initial Catalog=QLBHTBDT;Integrated Security=True;Encrypt=False;";

        // đói tượng kết nối
        SqlConnection sqlCon = null;

        // ham mo ket noi
        public void MoKetNoi()
        {
            if (sqlCon == null)
            {
                sqlCon = new SqlConnection(strCon);
            }
            if (sqlCon.State == ConnectionState.Closed)
            {
                sqlCon.Open();
            }
        }

        // ham dong ket noi
        public void DongKetNoi()
        {
            if (sqlCon.State == ConnectionState.Open && sqlCon != null)
            {
                sqlCon.Close();
            }
        }


        public DonHang()
        {
            InitializeComponent();
        }

        private void DonHang_Load(object sender, EventArgs e)
        {
            HienThiDSSanPham();
            txtSoLuong.Enabled = false;
            btnThem.Enabled = false;
        }
        private void HienThiDSSanPham()
        {
            SqlConnection sqlCon = Connection.MoKetNoi();

            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select TenSP, GiaTien, SoLuong from tblSanPham";
            sqlCmd.Connection = sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvSanPham.Items.Clear();
            while (reader.Read())
            {
                ListViewItem item = new ListViewItem(reader["TenSP"].ToString());

                item.SubItems.Add(reader["GiaTien"].ToString());
                item.SubItems.Add(reader["SoLuong"].ToString());
                lsvSanPham.Items.Add(item);
            }
            reader.Close();
        }

        private void lsvSanPham_Click(object sender, EventArgs e)
        {

            // Kiểm tra nếu có một dòng được chọn
            if (lsvSanPham.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvSanPham.SelectedItems[0];
                string tenSP = selectedItem.SubItems[0].Text;
                double giaTien = double.Parse(selectedItem.SubItems[1].Text);
                int soLuong = int.Parse(selectedItem.SubItems[2].Text);
                if (soLuong == 0)
                {
                    MessageBox.Show("Số lượng sản phẩm không đủ!");
                }
                else
                {

                    // Kiểm tra sản phẩm đã tồn tại trong giỏ hàng chưa
                    foreach (ListViewItem item in lsvGioHang.Items)
                    {
                        if (item.SubItems[0].Text == tenSP)
                        {
                            MessageBox.Show("Sản phẩm đã có trong giỏ hàng. Hãy chỉnh sửa số lượng nếu cần!");
                            return;
                        }
                    }

                    // Thêm sản phẩm vào giỏ hàng với số lượng mặc định là 0
                    ListViewItem lsv = new ListViewItem(tenSP);
                    lsv.SubItems.Add(giaTien.ToString("0.000"));
                    lsv.SubItems.Add("0"); // Số lượng mặc định là 0
                    lsvGioHang.Items.Add(lsv);

                    UpdateGiaTienThemSP();
                }
            }
            txtSoLuong.Enabled = false;
        }

        // Tính tổng tiền trong giỏ hàng
        private void UpdateGiaTienThemSP()
        {
            decimal totalPrice = 0;

            // Lặp qua tất cả các sản phẩm trong giỏ hàng và cộng tổng giá tiền
            foreach (ListViewItem item in lsvGioHang.Items)
            {
                decimal price = decimal.Parse(item.SubItems[1].Text); // Giá tiền sản phẩm
                int quantity = int.Parse(item.SubItems[2].Text);  // Số lượng sản phẩm trong giỏ

                totalPrice += price * quantity;  // Cộng giá tiền x số lượng
            }

            // Hiển thị tổng tiền vào TextBox
            txtTongTien.Text = totalPrice.ToString("#,0.000");  
        }

        public void ThemSL()
        {
            if (lsvGioHang.SelectedItems.Count > 0)
            {
                txtSoLuong.Enabled = true;
                btnThem.Enabled = true;

            }
        }

        private void lsvGioHang_Click(object sender, EventArgs e)
        {
            
            // Kiểm tra nếu có một dòng được chọn trong giỏ hàng
            if (lsvGioHang.SelectedItems.Count > 0)
            {
                ThemSL();
                ListViewItem selectedItem = lsvGioHang.SelectedItems[0];

                // Lấy thông tin từ dòng được chọn
                string tenSP = selectedItem.SubItems[0].Text;
                int soLuong = int.Parse(selectedItem.SubItems[2].Text);

                // Hiển thị số lượng vào TextBox để chỉnh sửa
                txtSoLuong.Text = soLuong.ToString();
            }
            else
            {
                txtSoLuong.Enabled = false;
                btnThem.Enabled = false;
            }
            
        }



        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection sqlCon = Connection.MoKetNoi();

                // Lấy thông tin khách hàng
                string tenKH = txtNhapTenKH.Text.Trim();
                string soDienThoai = txtNhapSDT.Text.Trim();
                string diaChi = txtDiaChi.Text.Trim();
                decimal tongTien = decimal.Parse(txtTongTien.Text);
                DateTime ngayDatHang = DateTime.Now;  // Ngày đặt hàng
                string maNV = txtMaNV.Text.Trim();
                //kiểm tra rỗng
                if (string.IsNullOrEmpty(tenKH))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!");
                    return;
                }

                if (string.IsNullOrEmpty(soDienThoai))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!");
                    return;
                }

                if (string.IsNullOrEmpty(diaChi))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!");
                    return;
                }
                if (string.IsNullOrEmpty(maNV))
                {
                    MessageBox.Show("Vui lòng nhập đủ thông tin!");
                    return;
                }

                // Lưu thông tin đơn hàng vào bảng tblDonHang
                string insertQuery = "INSERT INTO tblDonHang (NgayDatHang, TongTien, TenKH, SoDienThoai, DiaChi,MaTrangThai,MaNV) " +
                                     "VALUES (@NgayDatHang, @TongTien, @TenKH, @SoDienThoai, @DiaChi,@MaTrangThai,@MaNV); SELECT SCOPE_IDENTITY();";
                SqlCommand sqlCmd = new SqlCommand(insertQuery, sqlCon);
                sqlCmd.Parameters.AddWithValue("@NgayDatHang", ngayDatHang);
                sqlCmd.Parameters.AddWithValue("@TongTien", tongTien);
                sqlCmd.Parameters.AddWithValue("@TenKH", tenKH);
                sqlCmd.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                sqlCmd.Parameters.AddWithValue("@DiaChi", diaChi);
                sqlCmd.Parameters.AddWithValue("@MaTrangThai", 1);
                sqlCmd.Parameters.AddWithValue("@MaNV", maNV);
                // Lấy mã đơn hàng vừa tạo
                int maDonHang = Convert.ToInt32(sqlCmd.ExecuteScalar());

                // Lưu chi tiết đơn hàng vào bảng ChiTietDonHang
                foreach (ListViewItem item in lsvGioHang.Items)
                {
                    string tenSP = item.SubItems[0].Text;
                    double giaTien = double.Parse(item.SubItems[1].Text);
                    int soLuong = int.Parse(item.SubItems[2].Text); // Lấy số lượng từ giỏ hàng

                    // Chèn chi tiết đơn hàng vào bảng ChiTietDonHang
                    string insertChiTietQuery = @"INSERT INTO ChiTietDonHang (MaDonHang, TenSP, GiaTien, SoLuong) 
                                          VALUES (@MaDonHang, @TenSP, @GiaTien, @SoLuong)";
                    SqlCommand chiTietCmd = new SqlCommand(insertChiTietQuery, sqlCon);
                    chiTietCmd.Parameters.AddWithValue("@MaDonHang", maDonHang);  // Liên kết với MaDonHang vừa tạo
                    chiTietCmd.Parameters.AddWithValue("@TenSP", tenSP);
                    chiTietCmd.Parameters.AddWithValue("@GiaTien", giaTien);
                    chiTietCmd.Parameters.AddWithValue("@SoLuong", soLuong);
                    chiTietCmd.ExecuteNonQuery();

                    // Cập nhật số lượng trong kho
                    string capNhatKhoQuery = @"UPDATE tblSanPham SET SoLuong = SoLuong - @SoLuong WHERE TenSP = @TenSP";
                    SqlCommand capNhatKhoCmd = new SqlCommand(capNhatKhoQuery, sqlCon);
                    capNhatKhoCmd.Parameters.AddWithValue("@TenSP", tenSP);
                    capNhatKhoCmd.Parameters.AddWithValue("@SoLuong", soLuong); // Trừ số lượng sản phẩm
                    capNhatKhoCmd.ExecuteNonQuery();
                }

                MessageBox.Show("Đơn hàng đã được lưu thành công!");
                lsvGioHang.Items.Clear();  // Xóa giỏ hàng
                HienThiDSSanPham();  // Hiển thị lại danh sách sản phẩm
                LamMoiGD();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }

        private void LamMoiGD()
        {
            txtNhapTenKH.Clear();
            txtNhapSDT.Clear();
            txtDiaChi.Clear();
            txtSoLuong.Clear();
            txtSoLuong.Enabled = false;
            btnThem.Enabled = false;
            txtTongTien.Clear();
        }
        

        private void btnHuy_Click(object sender, EventArgs e)
        {
            lsvGioHang.Items.Clear();
            txtTongTien.Text = "0";
            txtSoLuong.Clear();
            HienThiDSSanPham();
            txtNhapTenKH.Clear();
            txtNhapSDT.Clear();
            txtDiaChi.Clear();
            txtMaNV.Clear();
            txtSoLuong.Enabled=false;
        }

        private void btnInHoaDon_Click(object sender, EventArgs e)
        {
            {
                // Thu thập thông tin từ các TextBox
                string khachHang = txtNhapTenKH.Text;
                string soDienThoai = txtNhapSDT.Text;
                string diaChi = txtDiaChi.Text;
                string tongTien = txtTongTien.Text;

                // Mở form XemHoaDonForm và truyền thông tin hóa đơn
                XemHoaDonForm xemHoaDonForm = new XemHoaDonForm(khachHang, soDienThoai, diaChi, tongTien, lsvGioHang.Items);
                xemHoaDonForm.ShowDialog();  // Hiển thị cửa sổ xem hóa đơn
            }
        }

        private void lsvGioHang_DoubleClick(object sender, EventArgs e)
        {
            if (lsvGioHang.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvGioHang.SelectedItems[0];
                string tenSP = selectedItem.SubItems[0].Text;
                int soLuongGioHang = int.Parse(selectedItem.SubItems[2].Text);

                // Tăng số lượng lại trong kho
                foreach (ListViewItem item in lsvSanPham.Items)
                {
                    if (item.SubItems[0].Text == tenSP)
                    {
                        int currentStock = int.Parse(item.SubItems[2].Text);
                        item.SubItems[2].Text = (currentStock + soLuongGioHang).ToString();
                        break;
                    }
                }

                // Xóa sản phẩm khỏi giỏ hàng
                lsvGioHang.Items.Remove(selectedItem);

                // Cập nhật tổng tiền
                UpdateGiaTienThemSP();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (lsvGioHang.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = lsvGioHang.SelectedItems[0];
                string tenSP = selectedItem.SubItems[0].Text;

                // Lấy số lượng cũ trong giỏ hàng và số lượng mới từ TextBox
                int slCu = int.Parse(selectedItem.SubItems[2].Text);
                int slMoi = int.Parse(txtSoLuong.Text);
                if (!int.TryParse(txtSoLuong.Text, out slMoi) || slMoi <= 0)
                {
                    MessageBox.Show("Số lượng không hợp lệ!");
                    return;
                }

                // Tính chênh lệch số lượng
                int delta = slMoi - slCu;

                // Cập nhật lại số lượng trong giỏ hàng
                selectedItem.SubItems[2].Text = slMoi.ToString();

                // Cập nhật lại số lượng trong danh sách sản phẩm
                foreach (ListViewItem item in lsvSanPham.Items)
                {
                    if (item.SubItems[0].Text == tenSP)
                    {
                        int slTrongKho = int.Parse(item.SubItems[2].Text);
                        if (slTrongKho - delta < 0)
                        {
                            MessageBox.Show("Không đủ số lượng sản phẩm trong kho!");                            
                            selectedItem.SubItems[2].Text = slCu.ToString(); // Hoàn tác thay đổi
                            return;

                        }
                        
                        item.SubItems[2].Text = (slTrongKho - (slMoi - slCu)).ToString();
                        break;
                    }
                }

                // Cập nhật tổng tiền
                UpdateGiaTienThemSP();
            }
        }
    }
}
