using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace BTL_GK.Views
{
    public partial class XemHoaDonForm : Form
    {
        public XemHoaDonForm(string khachHang, string soDienThoai, string diaChi, string tongTien, ListView.ListViewItemCollection gioHang)
        {
            InitializeComponent();

            // Hiển thị thông tin vào RichTextBox
            rtbHoaDon.AppendText("Hóa Đơn Mua Hàng\n\n");
            rtbHoaDon.AppendText("Tên Khách Hàng: " + khachHang + "\n");
            rtbHoaDon.AppendText("SĐT: " + soDienThoai + "\n");
            rtbHoaDon.AppendText("Địa Chỉ: " + diaChi + "\n");
            rtbHoaDon.AppendText("Tổng Tiền: " + tongTien + "\n\n");
            rtbHoaDon.AppendText("Danh Sách Sản Phẩm:\n");

            // Hiển thị danh sách sản phẩm
            foreach (ListViewItem item in gioHang)
            {
                string tenSP = item.SubItems[0].Text;
                string giaTien = item.SubItems[1].Text;
                string soLuong = item.SubItems[2].Text;
                string tongSP = (decimal.Parse(giaTien) * int.Parse(soLuong)).ToString();

                rtbHoaDon.AppendText($"{tenSP} - {giaTien} x {soLuong} = {tongSP}\n");
            }

            // Thêm một dòng trống ở cuối
            rtbHoaDon.AppendText("\n");

            // Thêm dòng ghi chú
            rtbHoaDon.AppendText("\nGhi chú: ");
            rtbHoaDon.SelectionStart = rtbHoaDon.Text.Length; // Đưa con trỏ đến cuối
            rtbHoaDon.SelectionLength = 0; // Không có đoạn text nào được chọn
            rtbHoaDon.Focus(); // Đưa focus vào RichTextBox
        }

        private void XemHoaDonForm_Load(object sender, EventArgs e)
        {

        }
    }
}
