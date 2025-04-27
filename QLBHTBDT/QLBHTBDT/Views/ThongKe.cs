using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BTL_GK.Views
{
    public partial class ThongKe : Form
    {
        //chuỗi kết nối
        string strCon = @"Data Source=DESKTOP-44Q601U\SQLEXPRESS;Initial Catalog=QLBHTBDT;Integrated Security=True;Encrypt=False";

        //đối tượng kết nối
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

        public ThongKe()
        {
            InitializeComponent();
        }

        private void ThongKe_Load(object sender, EventArgs e)
        {
            cboTuyChonTK.SelectedItem = "Theo ngày";
            //hiển thị theo tùy chọn


        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //hiển thị theo lựa chọn
            string option = cboTuyChonTK.SelectedItem.ToString();
            switch (option)
            {
                case "Theo ngày":
                    dtpNgay.Enabled = true;
                    dtpNgay2.Visible = false;
                    break;
                case "Theo tháng":
                    dtpNgay.Enabled = true;
                    dtpNgay2.Visible = false;
                    break;
                case "Theo năm":
                    dtpNgay.Enabled = true;
                    dtpNgay2.Visible = false;
                    break;
                case "Nhiều ngày":
                    dtpNgay.Enabled = true;
                    dtpNgay2.Visible = true;
                    break;
            }
        }

        private void btnLoc_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpNgay.Value;
            DateTime endDate = dtpNgay2.Value;
            string kieuLoc = cboTuyChonTK.SelectedItem.ToString();

            decimal tongDoanhThu = 0;

            string query = "";

            SqlConnection sqlCon=Connection.MoKetNoi();

            switch (kieuLoc)
            {
                case "Theo ngày":
                    query = "SELECT SUM(TongTien) FROM tblDonHang " +
                            "WHERE MaTrangThai = 2 AND DATEDIFF(day, NgayDatHang, @StartDate) = 0";
                    break;
                case "Theo tháng":
                    query = "SELECT SUM(TongTien) FROM tblDonHang " +
                            "WHERE MaTrangThai = 2 AND MONTH(NgayDatHang) = @Month AND YEAR(NgayDatHang) = @Year";
                    break;
                case "Theo năm":
                    query = "SELECT SUM(TongTien) FROM tblDonHang " +
                            "WHERE MaTrangThai = 2 AND YEAR(NgayDatHang) = @Year";
                    break;
                case "Nhiều ngày":
                    query = "SELECT SUM(TongTien) FROM tblDonHang " +
                            "WHERE MaTrangThai = 2 AND NgayDatHang BETWEEN @StartDate AND @EndDate";
                    break;
            }

            SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
            sqlCmd.Parameters.AddWithValue("@StartDate", startDate);
            sqlCmd.Parameters.AddWithValue("@EndDate", endDate);

            if (kieuLoc == "Theo tháng" || kieuLoc == "Theo năm")
            {
                sqlCmd.Parameters.AddWithValue("@Month", startDate.Month);
                sqlCmd.Parameters.AddWithValue("@Year", startDate.Year);
            }

            try
            {
                tongDoanhThu = Convert.ToDecimal(sqlCmd.ExecuteScalar());
                lblDoanhThu.Text = tongDoanhThu.ToString("#,0.000");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Chưa có sản phẩm nào được bán ra! " + ex.Message);
            }
            finally
            {
                Connection.DongKetNoi(sqlCon);
            }
        }




        private void btnXemKetQua_Click(object sender, EventArgs e)
        {
            string query = ""; // Chuỗi SQL để thực hiện
            if (rbtnBanChayNhat.Checked)
            {
                query = @"
            SELECT TOP 3 s.MaSP, s.TenSP, SUM(c.SoLuong) AS TongSoLuongBan 
                    FROM tblSanPham s
                    JOIN ChiTietDonHang c ON s.MaSP = c.MaSP
                    JOIN tblDonHang d ON c.MaDonHang = d.MaDonHang
                    WHERE d.MaTrangThai = 2
                    GROUP BY s.MaSP, s.TenSP
                    ORDER BY TongSoLuongBan DESC,MAX(d.NgayDatHang) DESC;";

            }
            else if (rbtnTonNhieuNhat.Checked)
            {
                query = @"
            SELECT TOP 4 MaSP, TenSP, SoLuong
            FROM tblSanPham
            ORDER BY SoLuong DESC; ";
            }
            else if (rbtnConIt.Checked)
            {
                query = @"
            SELECT TOP 4 MaSP, TenSP, SoLuong
                FROM tblSanPham
                WHERE SoLuong > = 0
                ORDER BY SoLuong ASC;";
            }

            // Thực hiện truy vấn và hiển thị kết quả
            if (!string.IsNullOrEmpty(query))
            {
                try
                {
                    SqlConnection sqlCon = Connection.MoKetNoi(); // Mở kết nối
                    SqlDataAdapter adapter = new SqlDataAdapter(query, sqlCon);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvThongKeSanPham.DataSource = dt; // Đổ dữ liệu lên DataGridView
                    Connection.DongKetNoi(sqlCon); // Đóng kết nối
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }


        }
    }
}
