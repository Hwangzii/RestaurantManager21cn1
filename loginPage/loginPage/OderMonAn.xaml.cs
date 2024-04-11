using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.IO;
using Aspose.Pdf.Text;

namespace loginPage
{
    public partial class OderMonAn : Window
    {//Data Source=HOANGPHI;Initial Catalog=Quanlynhahang21CN1;Integrated Security=True;Encrypt=False
        string connectstring = @"Data Source=HOANGPHI;Initial Catalog=Quanlynhahang21CN1;Integrated Security=True;Encrypt=False";
        public OderMonAn()
        {
            InitializeComponent();
        }

        // Nam: hiển thị số bàn
        public void settext(string text)
        {
            tableNumber.Text = text;
        }

        // Nam: Xóa bill trong bàn       
        private void deleteBill(object sender, MouseButtonEventArgs e)
        {
            try
            {
                ListOderBox.Items.Clear();
                int i = tablebooked.LuuHoadon.FindIndex(item => item.Ban == tableNumber.Text);
                if (i >= 0)
                {
                    tablebooked.LuuHoadon.RemoveAt(i);
                }
                tablebooked.NutDangChon.Background = Brushes.White;
                MessageBox.Show("Xóa hóa đơn thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Lỗi khi xóa hóa đơn: " + ex.Message);
            }
        }

        // Nam: Chuyển bill trong bàn
        private void moveBill(object sender, MouseButtonEventArgs e)
        {
            moveHoaDon.IsOpen = true;
        }       
        private void moveBill_Click(object sender, RoutedEventArgs e)
        {
            string banNow = tableNumber.Text;
            string banNext = inputTableNum.Text;

            int iNow = tablebooked.LuuHoadon.FindIndex(i=> i.Ban == banNow);
            int iNext = tablebooked.LuuHoadon.FindIndex(i => i.Ban == banNext);
            if(iNow >= 0 && iNext >= 0)
            {
                
                foreach (FoodItem item in tablebooked.LuuHoadon[iNow].Danhsach)
                {
                    tablebooked.LuuHoadon[iNext].Danhsach.Add(item);
                }      
                tablebooked.LuuHoadon.RemoveAt(iNow);
                tablebooked.NutDangChon.Background = Brushes.White;
            }
            else if (iNow >= 0 && iNext == -1)
            {
                LuuHoaDon DMT = tablebooked.LuuHoadon.Find(i => i.Ban == banNow);
                DMT.Ban = banNext.ToString();
                tablebooked.NutDangChon.Background = Brushes.White;                
            }
            else
            {
                MessageBox.Show("that bai");
            }
            moveHoaDon.IsOpen = false;
        }


        // ============ Ngọc: Tạo các button dựa trên số món ăn có trong database ============ //
        private void goimonTabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (allTabItem.IsSelected)
            {
                MonAnDAO monAnDAO = new MonAnDAO();
                monAnDAO.getAllMonAn(allGrid, allTabItem, DynamicBtn_Click);
            }

            else if (monNuongTabItem.IsSelected)
            {
                MonAnDAO monAnDAO = new MonAnDAO();
                monAnDAO.getMonNuong(monNuongGrid, monNuongTabItem, DynamicBtn_Click);
            }

            else if (monLauTabItem.IsSelected)
            {
                MonAnDAO monAnDAO = new MonAnDAO();
                monAnDAO.getMonLau(monLauGrid, monLauTabItem, DynamicBtn_Click);
            }

            else if (monNongTabItem.IsSelected)
            {
                MonAnDAO monAnDAO = new MonAnDAO();
                monAnDAO.getMonNong(monNongGrid, monNongTabItem, DynamicBtn_Click);
            }

            else if (doUongTabItem.IsSelected)
            {
                MonAnDAO monAnDAO = new MonAnDAO();
                monAnDAO.getDoUong(doUongGrid, doUongTabItem, DynamicBtn_Click);
            }
        }

        // Nam: Thêm thời gian vào column
        public void DynamicBtn_Click(object sender, RoutedEventArgs e)
        {
            Button clickedButton = (Button)sender;
            string foodTime = DateTime.Now.ToString("HH:mm");
            string foodName = ((TextBlock)((StackPanel)clickedButton.Content).Children[2]).Text;
            string foodPrice = ((TextBlock)((StackPanel)clickedButton.Content).Children[3]).Text;
            FoodItem newfoodItem = new FoodItem()
            {
               Name = foodName,
               Price = foodPrice,
               Qty = 1,
               Time = foodTime,
             };
             ListOderBox.Items.Add(newfoodItem);
           
            Tongtien();
        }

        public void Tongtien()
        {
            double tongtien = 0;
            foreach (FoodItem item in ListOderBox.Items)
            {
                tongtien += double.Parse(item.Price.Replace(" vnđ", "")) * item.Qty;
            }
            hienthitongtien.Text = tongtien.ToString("#,##") + " đ";

            hienthitongtien.Foreground = Brushes.Green;
            hienthitongtien.FontSize = 25;
        }

        // ============ (The mf who will code this function a.k.a Hùng) ============//
            private void luuThongtin_Click(object sender, RoutedEventArgs e)
            {
                
                    if(ListOderBox.HasItems == true)
                    { 
                        int i = tablebooked.LuuHoadon.FindIndex(i => i.Ban == tableNumber.Text);
                        if (i >= 0)
                        {
                            tablebooked.LuuHoadon[i].Danhsach.Clear();
                            foreach (FoodItem item in ListOderBox.Items)
                            {
                                tablebooked.LuuHoadon[i].Danhsach.Add(item);
                            }
                            MessageBox.Show("Luu thanh cong");
                        }
                        else 
                        {
                            LuuHoaDon HDD = new LuuHoaDon();
                            HDD.Ban = tableNumber.Text;
                            foreach (FoodItem item in ListOderBox.Items)
                            {
                                HDD.Danhsach.Add(item);
                            }
                            tablebooked.LuuHoadon.Add(HDD);
                            tablebooked.NutDangChon.Background = Brushes.LightSkyBlue;
                            MessageBox.Show("Luu thanh cong");
                        }
                    }
                else { MessageBox.Show("Đề nghị chọn món trước khi lưu"); }           
                
            }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            // Tìm và đóng cửa sổ tablebooked khi nhấp vào nút Back
            Window tablebookedWindow = Application.Current.Windows.OfType<tablebooked>().FirstOrDefault();
            if (tablebookedWindow != null)
            {
                tablebookedWindow.Visibility = Visibility.Visible;
                this.Close(); // Đóng cửa sổ hiện tại (OderMonAn)
            }

        }

        // Phi: code thêm hiển thị giao diện  
        private void OrderfoodForm_Loaded(object sender, RoutedEventArgs e)
        {
            double w = SystemParameters.PrimaryScreenWidth;
            double h = SystemParameters.PrimaryScreenHeight;
            this.WindowState = WindowState.Maximized;
            this.Left = 0;
            this.Top = 0;
            this.Width = w;
            this.Height = h;
        }

        // Hùng: Thêm biến public để lưu nút đang bị bấm

        Button TheButton;
        int soluong3;

        // Hùng: Thêm chức năng để gọi item từ một phần tử của nó
        private static T FindAncestor<T>(DependencyObject current) where T : DependencyObject
        {
            do
            {
                if (current is T)
                {
                    return (T)current;
                }
                current = VisualTreeHelper.GetParent(current);
            }
            while (current != null);
            return null;
        }

        // Hùng: Thêm chức năng để mở panel thay đổi số lượng

        public void ChangeAmount_Click(object sender, RoutedEventArgs e)
        {
            TheButton = sender as Button;
            var listViewItem = FindAncestor<ListViewItem>(TheButton);
            var item = listViewItem.DataContext as FoodItem;
            string namee = item.Name;
            int Qtyy = item.Qty;

            popup.IsOpen = true;
            Hienthiso.Text = Qtyy.ToString();
            Hienthitenmon.Text = namee;

        }

        // Hùng + Phi: 3 chức năng của 3 nút bấm trong bảng thay đổi số lượng
        private void huyBtn_Click(object sender, RoutedEventArgs e)
        {
            popup.IsOpen = false;
        }

        private void xoaBtn_Click(object sender, RoutedEventArgs e)
        {
            var listViewItem = FindAncestor<ListViewItem>(TheButton);
            var item = listViewItem.DataContext as FoodItem;
            ListOderBox.Items.Remove(item);
            Tongtien();
            popup.IsOpen = false;
        }

        private void luuBtn_Click(object sender, RoutedEventArgs e)
        {
            var listViewItem = FindAncestor<ListViewItem>(TheButton);
            var item = listViewItem.DataContext as FoodItem;
            item.Qty = soluong3;
            ListOderBox.Items.Refresh();
            Tongtien();
            popup.IsOpen = false;
        }

        // Hùng: Thêm 2 chức năng tăng giảm số lượng

        private void truBtn_Click(object sender, RoutedEventArgs e)
        {
            string thamso = Hienthiso.Text.ToString();
            soluong3 = Int32.Parse(thamso);
            if (soluong3 > 1)
            {
                soluong3 -= 1;
                Hienthiso.Text = soluong3.ToString();
            }
        }

        private void congBtn_Click(object sender, RoutedEventArgs e)
        {
            string thamso = Hienthiso.Text.ToString();
            soluong3 = Int32.Parse(thamso);
            soluong3 += 1;
            Hienthiso.Text = soluong3.ToString();

        }

        private void inhoadonBtn_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("hiện chưa thể in phiếu thanh toán!");
        }

        // === PHI: Thêm câu lênh mở Popup hóa đơn
        private void inhoadon_Click(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = true;
            Thoigian.Text = "Ngày: " + DateTime.Now.ToString();
            Ban.Text = "Bàn: " + tableNumber.Text;
            TongTien.Text = hienthitongtien.Text;
            SortThatShitOut();
            Hienthi.Children.Clear();

            // === Hùng: Thêm item vào hóa đơn từ List ====
            foreach (FoodItem item in Danhsach)
            {
                Grid grid = new Grid();
                grid.MinHeight = 25;
                grid.Margin = new Thickness(10, 10, 10, 10);
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(300) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(50) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200) });
                grid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(200) });

                TextBlock textBlock1 = new TextBlock();
                textBlock1.Text = item.Name;
                Grid.SetColumn(textBlock1, 0);
                grid.Children.Add(textBlock1);
                textBlock1.TextAlignment = TextAlignment.Left;
                textBlock1.Width = 300;

                TextBlock textBlock2 = new TextBlock();
                textBlock2.Text = item.Qty.ToString();
                Grid.SetColumn(textBlock2, 1);
                textBlock2.TextAlignment = TextAlignment.Center;
                grid.Children.Add(textBlock2);

                TextBlock textBlock3 = new TextBlock();
                textBlock3.Text = item.Price;
                Grid.SetColumn(textBlock3, 2);
                grid.Children.Add(textBlock3);
                textBlock3.TextAlignment = TextAlignment.Right;

                TextBlock textBlock4 = new TextBlock();
                double GiaTien = double.Parse(item.Price.Replace(" vnđ", ""));
                textBlock4.Text = (GiaTien * item.Qty).ToString() + " vnđ ";
                Grid.SetColumn(textBlock4, 3);
                textBlock4.TextAlignment = TextAlignment.Right;
                grid.Children.Add(textBlock4);

                Hienthi.Children.Add(grid);
            }


        }

        // === PHI: thêm hủy in hóa đơn ====
        private void huythanhtoanBtn_Click(object sender, RoutedEventArgs e)
        {
            popup1.IsOpen = false;
        }

        // === Hùng: Lấy int ID từ tên món để sort ====
        private int GetID(string a)
        {
            int IDD;
            if (Char.IsNumber(a, 1))
            {
                IDD = Convert.ToInt32(a[0]) * 10 + Convert.ToInt32(a[1]);
            }
            else
            {
                IDD = Convert.ToInt32(a[0]);
            }
            return IDD;
        }

        // === Hùng: Tạo một List để sắp xếp item ====
        List<FoodItem> Danhsach = new List<FoodItem>();

        private void SortThatShitOut()
        {
            Danhsach.Clear();
            foreach (FoodItem item in ListOderBox.Items)
            {
                if (Danhsach.Exists(x => x.Name == item.Name))
                {
                    FoodItem item1 = Danhsach.Find(x => x.Name == item.Name);
                    item1.Qty += item.Qty;
                }
                else
                {
                    Danhsach.Add(new FoodItem { Name = item.Name, Qty = item.Qty, Price = item.Price, ID = GetID(item.Name) });
                }
            }
            Danhsach = Danhsach.OrderBy(x => x.ID).ToList();

        }

        // ============ Ngọc: Code nút thanh toán phần nhập ttkh và chọn hình thức thanh toán,
        // ============ lưu hóa đơn vào csdl ============ //
        // ============ Hùng: Code phần xóa dữ liệu tạm thời sau khi thanh toán ============ //
        private void thanhtoanBtn_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection conn = new SqlConnection(connectstring);

            if (tenktTxtBox.Text != null && sdtkhTxtBox.Text == null)
            {
                MessageBox.Show("Vui lòng nhập sđt của khách hàng");
            }
            else if (sdtkhTxtBox.Text != null && tenktTxtBox.Text == null)
            {
                MessageBox.Show("Vui lòng nhập tên của khách hàng");
            }
            else if (tenktTxtBox.Text != null && sdtkhTxtBox.Text != null)
            {
                if (chuyenkhoanRadioBtn.IsChecked == false && tratienmatRadioBtn.IsChecked == false)
                {
                    MessageBox.Show("Đề nghị chọn phương thức thanh toán");
                }
                else if (chuyenkhoanRadioBtn.IsChecked == true)
                {
                    HoaDonDAO hoaDonDAO = new HoaDonDAO();
                    hoaDonDAO.insertHoaDonvaKhachHangChuyenKhoan(tableNumber, Thoigian, tenktTxtBox, sdtkhTxtBox, ListOderBox);

                    // Phi cho QR vào đây //
                    MessageBox.Show("okayChuyenKhoan");
                    this.Close();
                }
                else
                {
                    HoaDonDAO hoaDonDAO = new HoaDonDAO();
                    hoaDonDAO.insertHoaDonvaKhachHangChuyenKhoan(tableNumber, Thoigian, tenktTxtBox, sdtkhTxtBox, ListOderBox);

                    // Phi cho window xác nhận vào đây //
                    MessageBox.Show("okayTienmat");
                    this.Close();
                }
            }
            else
            {
                if (chuyenkhoanRadioBtn.IsChecked == false && tratienmatRadioBtn.IsChecked == false)
                {
                    MessageBox.Show("Đề nghị chọn phương thức thanh toán");
                }
                else if (chuyenkhoanRadioBtn.IsChecked == true)
                {
                    HoaDonDAO hoaDonDAO = new HoaDonDAO();
                    hoaDonDAO.insertHoaDonvaKhachHangTraTienMat(tableNumber, Thoigian, tenktTxtBox, sdtkhTxtBox, ListOderBox);

                    // Phi cho QR vào đây //
                    MessageBox.Show("okayChuyenKhoan");
                    this.Close();
                }
                else
                {
                    HoaDonDAO hoaDonDAO = new HoaDonDAO();
                    hoaDonDAO.insertHoaDonvaKhachHangTraTienMat(tableNumber, Thoigian, tenktTxtBox, sdtkhTxtBox, ListOderBox);

                    // Phi cho window xác nhận vào đây //
                    MessageBox.Show("okayTienmat");
                    this.Close();
                }
            }
        }




        private void btnOption_Click(object sender, RoutedEventArgs e)
        {
            popupBanAn.IsOpen = true;
        }

        private void inHoaDonPdf_Click(object sender, RoutedEventArgs e)
        {
            PrintInvoiceToPdf(Danhsach);
        }

        private string GenerateInvoiceCode(string tableNumber)
        {
            // Lấy thời gian hiện tại
            DateTime now = DateTime.Now;

            // Tạo mã hóa đơn dựa trên tên bàn và thời gian
            // Đảm bảo rằng bạn xử lý tên bàn để loại bỏ các ký tự không hợp lệ trong tên file
            string formattedTableNumber = tableNumber.Replace(" ", "_"); // Thay thế dấu cách bằng dấu gạch dưới (hoặc bất kỳ phương thức nào khác để loại bỏ ký tự không hợp lệ)
            string invoiceCode = $"{formattedTableNumber}_{now.ToString("yyyyMMddHHmmss")}"; // Định dạng: TableNumber_YYYYMMDDHHmmss

            return invoiceCode;
        }


        // =====  HOA ==== Làm in hóa đơn PDF
        private void PrintInvoiceToPdf(List<FoodItem> items)
        {
            try
            {
                // Lấy mã hóa đơn dựa trên tên bàn và thời gian
                string invoiceCode = GenerateInvoiceCode(tableNumber.Text);

                // Tạo một đối tượng tài liệu PDF
                Aspose.Pdf.Document pdfDocument = new Aspose.Pdf.Document();

                // Tạo một trang mới trong tài liệu
                Aspose.Pdf.Page page = pdfDocument.Pages.Add();

                Aspose.Pdf.Text.TextFragment title = new Aspose.Pdf.Text.TextFragment("Hóa Đơn");
                title.TextState.FontSize = 25;
                title.TextState.FontStyle = Aspose.Pdf.Text.FontStyles.Bold;
                title.Position = new Aspose.Pdf.Text.Position(200, 700);
                page.Paragraphs.Add(title);

                Aspose.Pdf.Text.TextFragment phancach = new Aspose.Pdf.Text.TextFragment("");

                // tạo chuỗi phân cách với 100 dấu -
                string separator = "";

                for (int i = 0; i < 100; i++)
                {
                    separator += "-";
                }

                // thiết lập văn bản của TextFragment là chuỗi phân cách
                phancach.Text = separator;

                page.Paragraphs.Add(phancach);

                // Lấy ngày giờ hiện tại
                DateTime now = DateTime.Now;

                // Tạo một đối tượng TextFragment để chứa thông tin về số bàn và ngày giờ
                Aspose.Pdf.Text.TextFragment info = new Aspose.Pdf.Text.TextFragment($"\nSố bàn: {tableNumber.Text}\n" +
                    $"Ngày giờ: {now.ToString()}\n" +
                    $"Mã hóa đơn: {invoiceCode}");

                info.TextState.FontSize = 16;
                page.Paragraphs.Add(info);

                // Tạo một đối tượng Table để chứa dữ liệu hóa đơn
                Aspose.Pdf.Table table = new Aspose.Pdf.Table();
                Aspose.Pdf.Text.TextState headerState = new Aspose.Pdf.Text.TextState();
                headerState.FontSize = 14;
                headerState.FontStyle = Aspose.Pdf.Text.FontStyles.Bold;
                table.ColumnWidths = "120 30 100 130";

                // Thêm hàng tiêu đề cho bảng
                Aspose.Pdf.Row headerRow = table.Rows.Add();
                headerRow.Cells.Add("Tên món").DefaultCellTextState = headerState;
                headerRow.Cells.Add("SL").DefaultCellTextState = headerState;
                headerRow.Cells.Add("Đơn giá").DefaultCellTextState = headerState;
                headerRow.Cells.Add("Thành tiền").DefaultCellTextState = headerState;


                Aspose.Pdf.Text.TextState dataState = new Aspose.Pdf.Text.TextState();
                dataState.FontSize = 14;
                // Thêm dữ liệu từ danh sách món ăn vào bảng
                foreach (var item in items)
                {
                    Aspose.Pdf.Row dataRow = table.Rows.Add();
                    dataRow.Cells.Add(item.Name).DefaultCellTextState = dataState;
                    dataRow.Cells.Add(item.Qty.ToString()).DefaultCellTextState = dataState;
                    dataRow.Cells.Add(item.Price).DefaultCellTextState = dataState;
                    double GiaTien = double.Parse(item.Price.Replace(" vnđ", ""));
                    dataRow.Cells.Add((GiaTien * item.Qty).ToString() + " vnđ").DefaultCellTextState = dataState; ;
                }

                // Thêm bảng vào trang PDF
                page.Paragraphs.Add(table);

                page.Paragraphs.Add(phancach);

                // Thêm tổng hóa đơn vào cuối hóa đơn
                double total = items.Sum(item => double.Parse(item.Price.Replace(" vnđ", "")) * item.Qty);
                Aspose.Pdf.Text.TextFragment totalText = new Aspose.Pdf.Text.TextFragment($"Tổng tiền: {total.ToString()} vnđ");
                totalText.TextState.FontSize = 14; // Đặt vị trí tổng hóa đơn
                page.Paragraphs.Add(totalText);

                // Đường dẫn đầy đủ của thư mục muốn lưu file PDF
                string folderPath = @"D:\Chung\JOBS\git\C#\FILE_1\RestaurantManager21cn1\loginPage\Bill\HD";




                // === PHI === Lưu tài liệu PDF
                string fileName = folderPath + invoiceCode + ".pdf";
                pdfDocument.Save(fileName);

                // mở file hóa đơn đã lưu
                if (File.Exists(fileName))
                {
                    Process.Start(fileName);
                    popup1.IsOpen = false;
                }
                else
                {
                    MessageBox.Show("khôn thể mở file hóa đơn.", "lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
                }





            }
            catch (Exception ex)
            {
                // Hiển thị MessageBox khi in hóa đơn thất bại và hiển thị thông tin lỗi (nếu có)
                MessageBox.Show("In hóa đơn thất bại");
            }
        }
    }
}
