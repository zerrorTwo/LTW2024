using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LTW2024.UI
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void gwSellProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tbMoneyPay_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            string qty = tbQty.Text;
            int qtyInt = int.Parse(qty);
            if (qtyInt > 1)
            {
                qtyInt -= 1;
                tbQty.Text = qtyInt.ToString();
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            string qty = tbQty.Text;
            int qtyInt = int.Parse(qty);
            qtyInt += 1;
            tbQty.Text = qtyInt.ToString();

        }

        private void btnPay_Click(object sender, EventArgs e)
        {

        }

        private void btnCancle_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            using (var context = new DBGroceryContext())
            {
                var query = context.SanPhams
                      .Select(s => new { s.MaSP, s.TenSP, s.DonGia }); // Chọn các cột MaSP, TenSP, DonGia

                // Thêm các cột vào gwProduct và gán dữ liệu từ query vào các cột tương ứng
                gwProduct.Columns.Add("MaSP", "Mã Sản Phẩm");
                gwProduct.Columns["MaSP"].DataPropertyName = "MaSP";

                gwProduct.Columns.Add("TenSP", "Tên Sản Phẩm");
                gwProduct.Columns["TenSP"].DataPropertyName = "TenSP";

                gwProduct.Columns.Add("DonGia", "Đơn Giá");
                gwProduct.Columns["DonGia"].DataPropertyName = "DonGia";

                // Gán dữ liệu từ query vào gwProduct.DataSource
                gwProduct.DataSource = query.ToList();
            }
        }

        private void gwProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void gwProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra xem ô đã được chọn có phải là một hàng không và hàng đó có dữ liệu không
            if (e.RowIndex >= 0 && e.RowIndex < gwProduct.Rows.Count - 1)
            {
                if (gwSellProduct.Columns.Count == 0)
                {
                    gwSellProduct.Columns.Add("MaSP", "Mã Sản Phẩm");
                    gwSellProduct.Columns.Add("TenSP", "Tên Sản Phẩm");
                    gwSellProduct.Columns.Add("DonGia", "Đơn Giá");
                    gwSellProduct.Columns.Add("SoLuong", "Số Lượng"); // Thêm cột số lượng
                }
                // Lấy ra dữ liệu từ ô được chọn trong gwProduct
                DataGridViewRow selectedRow = gwProduct.Rows[e.RowIndex];

                // Kiểm tra xem dữ liệu đã tồn tại trong gwSellProduct hay chưa
                bool existed = false;
                foreach (DataGridViewRow row in gwSellProduct.Rows)
                {
                    // Kiểm tra xem các giá trị không phải null trước khi sử dụng ToString()
                    if (row.Cells["MaSP"].Value != null && selectedRow.Cells["MaSP"].Value != null &&
                        row.Cells["MaSP"].Value.ToString() == selectedRow.Cells["MaSP"].Value.ToString())
                    {
                        // Nếu dữ liệu đã tồn tại, tăng giá trị của cột "Số lượng" lên 1 và thoát khỏi vòng lặp
                        int quantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                        row.Cells["SoLuong"].Value = quantity + 1;
                        existed = true;
                        tbQty.Text = (quantity + 1).ToString(); // Hiển thị số lượng tương ứng vào tbQty
                        break;
                    }
                }

                // Nếu dữ liệu chưa tồn tại, thêm một hàng mới vào gwSellProduct
                if (!existed)
                {
                    gwSellProduct.Rows.Add(selectedRow.Cells["MaSP"].Value,
                                            selectedRow.Cells["TenSP"].Value,
                                            selectedRow.Cells["DonGia"].Value,
                                            1); // Số lượng mặc định bằng 1
                    tbQty.Text = "1"; // Hiển thị số lượng mặc định vào tbQty
                }
            }
            UpdateTotalMoney();
        }

        private void tbQty_TextChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem tbQty có rỗng hay không
            if (!string.IsNullOrEmpty(tbQty.Text))
            {
                int newQuantity = int.Parse(tbQty.Text);
                if (newQuantity >= 0)
                {
                    // Lấy chỉ số hàng đang được chọn trong gwSellProduct (nếu có)
                    int selectedRowIndex = gwSellProduct.CurrentCell?.RowIndex ?? -1;
                    if (selectedRowIndex >= 0)
                    {
                        // Cập nhật giá trị của cột "SoLuong" trong hàng đang được chọn
                        gwSellProduct.Rows[selectedRowIndex].Cells["SoLuong"].Value = newQuantity;

                        // Nếu giá trị số lượng là 0, xóa hàng đó ra khỏi gwSellProduct
                        if (newQuantity == 0)
                        {
                            gwSellProduct.Rows.RemoveAt(selectedRowIndex);
                        }
                    }
                }
            }
            UpdateTotalMoney();
        }

        private void gwSellProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        { 
        }

        private void btnDeletePro_Click(object sender, EventArgs e)
        {
            // Lấy chỉ số hàng đang được chọn trong gwSellProduct(nếu có)
            int selectedRowIndex = gwSellProduct.CurrentCell?.RowIndex ?? -1;
            if (selectedRowIndex >= 0)
            {
                // Xóa hàng đang chọn ra khỏi gwSellProduct
                gwSellProduct.Rows.RemoveAt(selectedRowIndex);
                UpdateTotalMoney();
            }
        }

        private void gwProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void gwSellProduct_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           
        }

        private void gwSellProduct_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //// Kiểm tra xem sự thay đổi có xảy ra trong cột "Đơn giá" hoặc cột "Số lượng" không
            //if (e.ColumnIndex == gwSellProduct.Columns["DonGia"].Index || e.ColumnIndex == gwSellProduct.Columns["SoLuong"].Index)
            //{
            //    UpdateTotalMoney();
            //}
        }

        private void UpdateTotalMoney()
        {
            double totalMoney = 0;
            foreach (DataGridViewRow row in gwSellProduct.Rows)
            {
                // Lấy giá trị từ cột "DonGia" và "SoLuong" bằng cách sử dụng chỉ mục cột
                if (row.Cells[2].Value != null && row.Cells[3].Value != null)
                {
                    double price = Convert.ToDouble(row.Cells[2].Value);
                    int quantity = Convert.ToInt32(row.Cells[3].Value);
                    // Tính tổng tiền
                    totalMoney += price * quantity;
                }
            }
            lbMoneyPay.Text = totalMoney.ToString() + " đ";
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            using (var context = new DBGroceryContext())
            {
                try
                {
                    string searchText = tbSearch.Text.Trim();

                    // Lấy danh sách sản phẩm từ database dựa trên điều kiện tìm kiếm
                    var products = context.SanPhams.Select(s => new { s.MaSP, s.TenSP, s.DonGia }).Where(p => p.TenSP.Contains(searchText)).ToList();

                    // Xóa dữ liệu hiện có trong DataGridView trước khi thêm dữ liệu mới
                    gwProduct.DataSource = null ;

                    // Thêm dữ liệu mới từ products vào DataGridView
                    gwProduct.DataSource = products;
                }
                catch (Exception)
                {
                    MessageBox.Show("Tải dữ liệu không thành công!!!", "Thất bại", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

    }
}
