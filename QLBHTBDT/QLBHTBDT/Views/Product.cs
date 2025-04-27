using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace BTL_GK.Views
{
    public partial class Product : Form
    {
        //chuỗi kết nối
        string strCon = @"Data Source=DESKTOP-44Q601U\SQLEXPRESS;Initial Catalog=QLBHTBDT;Integrated Security=True;Encrypt=False";
        //tạo đối tượng kết nối
        SqlConnection sqlCon = null;

        //hàm mở kết nối
        private void MoKetNoi()
        {
            if (sqlCon==null) sqlCon = new SqlConnection(strCon);
            if(sqlCon.State== ConnectionState.Closed) sqlCon.Open();
        }

        //hàm đóng kết nối
        private void DongKetNoi()
        {
            if(sqlCon.State==ConnectionState.Open) sqlCon.Close();
        }

        public Product()
        {
            InitializeComponent();
        }

        //form load
        private void Product_Load(object sender, EventArgs e)
        {
            HienThiDSSP();
            grbTTCT.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        //hiển thị danh sách lên listview
        public void HienThiDSSP()
        {
            SqlConnection sqlCon = Connection.MoKetNoi();
         
            //đối tượng kết nối
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType= CommandType.Text;
            sqlCmd.CommandText= "select * from tblSanPham";

            //gắn vào kết nối
            sqlCmd.Connection=sqlCon;

            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvSanPham.Items.Clear();
            while (reader.Read()) 
            {
                string maSP = reader.GetString(0);
                string tenSP= reader.GetString(1);
                decimal giaTien = reader.GetDecimal(2);
                string ngayNhap=reader.GetDateTime(3).ToString("MM/dd/yyyy");
                int soLuong= reader.GetInt32(4);

                //tạo bảng và thêm dữ liệu
                ListViewItem lvi = new ListViewItem(maSP);
                lvi.SubItems.Add(tenSP);
                lvi.SubItems.Add(giaTien.ToString("#,0.000"));
                lvi.SubItems.Add(ngayNhap);
                lvi.SubItems.Add(soLuong.ToString());

                lsvSanPham.Items.Add(lvi);

            }
            reader.Close();


        }
        
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            //lấy dữ liệu từ form
            string maTK = txtMaTimKiem.Text.Trim();
            string tenTK = txtTenTimKiem.Text.Trim();

            //phân chia trường hợp
            if (maTK != "" && tenTK == "")
            {
                TimKiemTheoMa(maTK);

            }
            else if (maTK == "" && tenTK != "")
            {
                TimKiemTheoTen(tenTK);
            }
            else if (maTK != "" && tenTK != "")
            {
                TimKiemTheoMa(maTK);
            }
            else
            {
                MessageBox.Show("Bạn chưa nhập thông tin tìm kiếm!");
                txtMaTimKiem.Focus();
            }
            
        }
        //Tìm kiếm theo mã
        private void TimKiemTheoMa(string maTK)
        {
            SqlConnection sqlCon = Connection.MoKetNoi();

            //đối tượng truy vấn
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "select * from tblSanPham where MaSp='"+maTK+"'";

            //gắn vào kết nối
            sqlCmd.Connection = sqlCon;

            //thực thi truy vấn
            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvSanPham.Items.Clear();
            while (reader.Read())
            {
                //đọc dữ liệu từ csdl
                string maSP = reader.GetString(0);
                string tenSP = reader.GetString(1);
                decimal giaTien = reader.GetDecimal(2);
                string ngayNhap = reader.GetDateTime(3).ToString("MM/dd/yyyy");
                int soLuong = reader.GetInt32(4);

                //tạo 1 dòng và thêm dữ liệu
                ListViewItem lvi = new ListViewItem(maSP);
                lvi.SubItems.Add(tenSP);
                lvi.SubItems.Add(giaTien.ToString("#,0.000"));
                lvi.SubItems.Add(ngayNhap);
                lvi.SubItems.Add(soLuong.ToString());

                lsvSanPham.Items.Add(lvi);

            }
            reader.Close();
        }
        
        //Tìm kiếm theo tên
        private void TimKiemTheoTen(string tenTK)
        {
             SqlConnection sqlCon = Connection.MoKetNoi();
            //đối tượng truy vấn
            SqlCommand  sqlCmd = new SqlCommand();
            sqlCmd.CommandType= CommandType.Text;
            sqlCmd.CommandText = "select * from tblSanPham where  tenSP like '%"+tenTK+"%'";

            //gắn vào kết nối
            sqlCmd.Connection = sqlCon;

            //thực thi truy vấn
            SqlDataReader reader = sqlCmd.ExecuteReader();
            lsvSanPham.Items.Clear();
            while (reader.Read())
            {
                //đọc dữ liệu từ csdl
                string maSP = reader.GetString(0);
                string tenSP = reader.GetString(1);
                decimal giaTien = reader.GetDecimal(2);
                string ngayNhap = reader.GetDateTime(3).ToString("MM/dd/yyyy");
                int soLuong = reader.GetInt32(4);

                //tạo 1 dòng và thêm dữ liệu
                ListViewItem lvi = new ListViewItem(maSP);
                lvi.SubItems.Add(tenSP);
                lvi.SubItems.Add(giaTien.ToString("#,0.000"));
                lvi.SubItems.Add(ngayNhap);
                lvi.SubItems.Add(soLuong.ToString());

                lsvSanPham.Items.Add(lvi);

            }
            reader.Close();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            lsvSanPham.Items.Clear ();
            HienThiDSSP();
            txtMaTimKiem.Clear();
            txtTenTimKiem.Clear();
        }

        //phan chia chức năng
       int chucNang =0;
        
        private void btnThem_Click(object sender, EventArgs e)
        {
            chucNang = 1;
            XoaDL();
            txtMaSanPham.Enabled = true;
            grbTTCT.Enabled = true;
            btnSua.Enabled=false;
            btnXoa.Enabled=false;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            chucNang = 2;
            btnXoa.Enabled = false;
            grbTTCT.Enabled = true;
            txtMaSanPham.Enabled = false;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (chucNang==1)
            {
                ThemSanPham();
            }else if (chucNang == 2)
            {
                SuaTTSanPham();
            }
        }

        //hàm chọn sản phẩm trong list và hiển thị thông tin
        private void lsvSanPham_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(lsvSanPham.SelectedItems.Count==0) return;
            ListViewItem lvi = lsvSanPham.SelectedItems[0];
            txtMaSanPham.Text=lvi.SubItems[0].Text.Trim();
            txtTenSanPham.Text = lvi.SubItems[1].Text.Trim();
            txtGiaTien.Text = lvi.SubItems[2].Text.Trim();
            string[] ngayNhap = lvi.SubItems[3].Text.Split('/');
            dtpNgayNhap.Value = new DateTime(int.Parse(ngayNhap[2]), int.Parse(ngayNhap[0]), int.Parse(ngayNhap[1]));
            nmrSoLuong.Text = lvi.SubItems[4].Text.Trim();

            btnSua.Enabled = true;
            btnXoa.Enabled = true;
            
        }

        //xóa dữ liệu form nhập thông tin
        private void XoaDL()
        {
            txtMaSanPham.Clear();
            txtTenSanPham.Clear();
            txtGiaTien.Clear();
            nmrSoLuong.Value = 0;
        }
        //thêm sản phẩm
        private void ThemSanPham()
        {
            SqlConnection sqlCon = Connection.MoKetNoi();
            //lấy dữ liệu từ form
            string maSP = txtMaSanPham.Text.Trim();
            string tenSP = txtTenSanPham.Text.Trim();
            string ngayNhap = dtpNgayNhap.Value.Year + "-" + dtpNgayNhap.Value.Month + "-" + dtpNgayNhap.Value.Day;
            string soLuong = nmrSoLuong.Text.Trim();
            decimal giaTien;
            if (!decimal.TryParse(txtGiaTien.Text.Trim(), out giaTien))
            {
                MessageBox.Show("Vui lòng nhập giá tiền là một số hợp lệ.");
                return;
            }
            //kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(maSP))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }

            if (string.IsNullOrWhiteSpace(tenSP))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin!");
                return;
            }
            //đối tượng truy vấn
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "insert into tblSanPham values('" + maSP + "', N'" + tenSP + "', " + giaTien + ", CONVERT(datetime, '" + ngayNhap + "'), N'" + soLuong + "')";

            //gắn vào kết nối
            sqlCmd.Connection = sqlCon;

            //thực thi truy vấn
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Thêm sản phẩm thành công");
                HienThiDSSP();
                XoaDL();
            }
            else
            {
                MessageBox.Show("Thêm sản phẩm không thành công");
                HienThiDSSP();
                XoaDL();
            }
            grbTTCT.Enabled = false;
            
        }

        //sửa thông tin sản phẩm
        private void SuaTTSanPham()
        {
            SqlConnection sqlCon = Connection.MoKetNoi();
            //lấy dữ liệu từ form
            string maSP = txtMaSanPham.Text.Trim();
            string tenSP = txtTenSanPham.Text.Trim();
            string ngayNhap = dtpNgayNhap.Value.Year + "-" + dtpNgayNhap.Value.Month + "-" + dtpNgayNhap.Value.Day;
            string soLuong = nmrSoLuong.Text.Trim();
            decimal giaTien;
            if (!decimal.TryParse(txtGiaTien.Text.Trim(), out giaTien))
            {
                MessageBox.Show("Vui lòng nhập giá tiền là một số hợp lệ.");
                return; 
            }
            //đối tượng truy vấn
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.CommandType = CommandType.Text;
            sqlCmd.CommandText = "update tblSanPham set MaSP='" + maSP + "',TenSP=N'" + tenSP + "',GiaTien=" + giaTien + ",NgayNhap=CONVERT(datetime, '" + ngayNhap + "'),SoLuong=N'" + soLuong + "' where MaSP='" + maSP + "'";

            //gắn vào kết nối
            sqlCmd.Connection = sqlCon;

            //thực thi truy vấn
            int kq = sqlCmd.ExecuteNonQuery();
            if (kq > 0)
            {
                MessageBox.Show("Sửa sản phẩm thành công");
                HienThiDSSP();
                XoaDL();
            }
            else
            {
                MessageBox.Show("Sửa sản phẩm không thành công");
                HienThiDSSP();
                XoaDL();
            }
            grbTTCT.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }

        //hàm xóa sản phẩm
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?",
                                          "Xác nhận xóa",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);
            if (result == DialogResult.No)
            {
                return; 
            }

            try
            {
                SqlConnection sqlCon = Connection.MoKetNoi();
                string maSP_xoa = lsvSanPham.SelectedItems[0].SubItems[0].Text.Trim();

                //đối tượng truy vấn 
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.CommandType = CommandType.Text;
                sqlCmd.CommandText = "delete from tblSanPham where MaSP='" + maSP_xoa + "'";


                //gắn vào kết nối 
                sqlCmd.Connection = sqlCon;

                //thưc thi truy vấn
                int kq = sqlCmd.ExecuteNonQuery();
                if (kq > 0)
                {
                    MessageBox.Show("Xóa sản phẩm thành công");
                    HienThiDSSP();
                }
                else
                {
                    MessageBox.Show("Xóa sản phẩm không thành công");
                    HienThiDSSP();
                }
                grbTTCT.Enabled = false;
                btnSua.Enabled = false;
                btnXoa.Enabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sản phẩm đang có trong Trạng thái đơn" );
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            XoaDL();
            grbTTCT.Enabled = false;
            btnSua.Enabled = false;
            btnXoa.Enabled = false;
        }
    }
}
