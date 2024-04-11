using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Windows.Media;

namespace loginPage
{
    internal class HoaDonDAO
    {
        String connectionString = "Data Source=HOANGPHI;Initial Catalog=Quanlynhahang21CN1;Integrated Security=True;Encrypt=False";

        public HoaDonDAO()
        {

        }

        public List<HoaDon> GetAddHoaDon()
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM HoaDon", sqlConnection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDon hoaDon = new HoaDon();
                        hoaDon.ID = (int)reader.GetInt32(0);
                        if (!reader.IsDBNull(reader.GetOrdinal("MaKH")))
                        {
                            hoaDon.MaKH = (int)reader.GetInt32(1);
                        }
                        hoaDon.MaBan = (int)reader.GetInt32(4);
                        hoaDon.TenKH = reader.GetValue(6).ToString();
                        hoaDon.SDTKH = reader.GetValue(7).ToString();
                        hoaDon.SoLuongMon = (int)reader.GetInt32(8);
                        hoaDon.TongTien = ((int)reader.GetInt32(9)).ToString("#,##") + " vnđ";
                        hoaDon.NgayAn = reader.GetDateTime(10);

                        listHoaDon.Add(hoaDon);
                    }
                }
            }
            return listHoaDon; // Thêm câu lệnh return này
        }

        public List<HoaDon> timkiemthongtin(string TongTien)
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM HoaDon WHERE TongTien LIKE @TongTien", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TongTien", "%" + TongTien + "%");

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDon hoaDon = new HoaDon();
                        hoaDon.ID = (int)reader.GetInt32(0);
                        if (!reader.IsDBNull(reader.GetOrdinal("MaKH")))
                        {
                            hoaDon.MaKH = (int)reader.GetInt32(1);
                        }
                        hoaDon.MaBan = (int)reader.GetInt32(4);
                        hoaDon.TenKH = reader.GetValue(6).ToString();
                        hoaDon.SDTKH = reader.GetValue(7).ToString();
                        hoaDon.SoLuongMon = (int)reader.GetInt32(8);
                        hoaDon.TongTien = ((int)reader.GetInt32(9)).ToString("#,##") + " vnđ";
                        hoaDon.NgayAn = reader.GetDateTime(10);

                        listHoaDon.Add(hoaDon);
                    }
                }
            }
            return listHoaDon;
        }

        public List<HoaDon> insertHoaDonvaKhachHangChuyenKhoan(TextBlock targetTenBanTxtBlock, TextBlock targetTxtBlockDate, TextBox targetTenKHTxtBox, TextBox targetSDTKHTxtBox, ListView targetOrderLV)
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            try
            {
                string tenBan = targetTenBanTxtBlock.Text;
                string findTableID = "select * from BanAn where TenBan = @tenBan";
                int banID = 0;

                SqlCommand cmdTableID = new SqlCommand(findTableID, sqlConnection);
                cmdTableID.Parameters.AddWithValue("@tenBan", tenBan);

                using (SqlDataReader read = cmdTableID.ExecuteReader())
                {
                    while (read.Read())
                    {
                        banID = (int)read["MaBan"];
                    }
                }

                DateTime ngayAn = DateTime.Parse(targetTxtBlockDate.Text.Replace("Ngày: ", ""));
                string tenKH = targetTenKHTxtBox.Text;
                string sdtKH = targetSDTKHTxtBox.Text;
                string insertTTKH = @"insert into KhachHang (TenKH, SDTKH) values (@tenKH, @sdtKH)";

                SqlCommand cmdTTKH = new SqlCommand(insertTTKH, sqlConnection);
                cmdTTKH.Parameters.AddWithValue("@tenKH", tenKH);
                cmdTTKH.Parameters.AddWithValue("@sdtKH", sdtKH);

                cmdTTKH.ExecuteNonQuery();

                string findKHID = @"select * from KhachHang where TenKH = @tenKH and SDTKH = @sdtKH";
                int khID = 0;

                SqlCommand cmdKHID = new SqlCommand(findKHID, sqlConnection);
                cmdKHID.Parameters.AddWithValue("@tenKH", tenKH);
                cmdKHID.Parameters.AddWithValue("@sdtKH", sdtKH);

                using (SqlDataReader read = cmdKHID.ExecuteReader())
                {
                    while (read.Read())
                    {
                        khID = (int)read["MaKH"];
                    }
                }

                double tongTien = 0;
                foreach (FoodItem item in targetOrderLV.Items)
                {
                    tongTien += double.Parse(item.Price.Replace(" vnđ", "")) * item.Qty;
                }
                int soLuongMon = 0;
                foreach (FoodItem item in targetOrderLV.Items)
                {
                    soLuongMon += item.Qty;
                }

                string insertString = @"insert into HoaDon
                (MaKH, MaBan, TenKH, SDTKH, NgayAn, SoLuongMon, TongTien)
                values (@maKH, @maBan, @tenKH, @sdtKH, @ngayAn, @soLuongMon, @tongTien)";

                SqlCommand cmd = new SqlCommand(insertString, sqlConnection);
                cmd.Parameters.AddWithValue("@maKH", khID);
                cmd.Parameters.AddWithValue("@maBan", banID);
                cmd.Parameters.AddWithValue("@tenKH", tenKH);
                cmd.Parameters.AddWithValue("@sdtKH", sdtKH);
                cmd.Parameters.AddWithValue("@ngayAn", ngayAn);
                cmd.Parameters.AddWithValue("@soLuongMon", soLuongMon);
                cmd.Parameters.AddWithValue("@tongTien", tongTien);

                cmd.ExecuteNonQuery();

            }
            finally
            {
                // Close the connection
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                // Hùng: Thanh toán xong xóa trong cái lưu Tạm
                targetOrderLV.Items.Clear();
                int i = tablebooked.LuuHoadon.FindIndex(i => i.Ban == targetTenBanTxtBlock.Text);
                if (i >= 0)
                {
                    tablebooked.LuuHoadon.RemoveAt(i);
                }
                tablebooked.NutDangChon.Background = Brushes.White;
            }

            return listHoaDon;
        }

        public List<HoaDon> insertHoaDonvaKhachHangTraTienMat(TextBlock targetTenBanTxtBlock, TextBlock targetTxtBlockDate, TextBox targetTenKHTxtBox, TextBox targetSDTKHTxtBox, ListView targetOrderLV)
        {
            List<HoaDon> listHoaDon = new List<HoaDon>();
            SqlConnection sqlConnection = new SqlConnection(connectionString);
            sqlConnection.Open();

            try
            {
                string tenBan = targetTenBanTxtBlock.Text;
                string findTableID = "select * from BanAn where TenBan = @tenBan";
                int banID = 0;

                SqlCommand cmdTableID = new SqlCommand(findTableID, sqlConnection);
                cmdTableID.Parameters.AddWithValue("@tenBan", tenBan);

                using (SqlDataReader read = cmdTableID.ExecuteReader())
                {
                    while (read.Read())
                    {
                        banID = (int)read["MaBan"];
                    }
                }

                DateTime ngayAn = DateTime.Parse(targetTxtBlockDate.Text.Replace("Ngày: ", ""));
                double tongTien = 0;
                foreach (FoodItem item in targetOrderLV.Items)
                {
                    tongTien += double.Parse(item.Price.Replace(" vnđ", "")) * item.Qty;
                }
                int soLuongMon = 0;
                foreach (FoodItem item in targetOrderLV.Items)
                {
                    soLuongMon += item.Qty;
                }

                string insertString = @"insert into HoaDon
                (MaBan, NgayAn, SoLuongMon, TongTien)
                values (@maBan, @ngayAn, @soLuongMon, @tongTien)";

                SqlCommand cmd = new SqlCommand(insertString, sqlConnection);
                cmd.Parameters.AddWithValue("@maBan", banID);
                cmd.Parameters.AddWithValue("@ngayAn", ngayAn);
                cmd.Parameters.AddWithValue("@soLuongMon", soLuongMon);
                cmd.Parameters.AddWithValue("@tongTien", tongTien);

                cmd.ExecuteNonQuery();

            }
            finally
            {
                // Close the connection
                if (sqlConnection != null)
                {
                    sqlConnection.Close();
                }

                // Hùng: Thanh toán xong xóa trong cái lưu Tạm
                targetOrderLV.Items.Clear();
                int i = tablebooked.LuuHoadon.FindIndex(i => i.Ban == targetTenBanTxtBlock.Text);
                if (i >= 0)
                {
                    tablebooked.LuuHoadon.RemoveAt(i);
                }
                tablebooked.NutDangChon.Background = Brushes.White;
            }

            return listHoaDon;
        }
    }
}
