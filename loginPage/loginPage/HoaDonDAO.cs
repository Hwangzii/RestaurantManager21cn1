using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace loginPage
{
    internal class HoaDonDAO
    {
        String connectionString = "Data Source=DESKTOP-BTLUTR6\\SQLEXPRESS;Initial Catalog=Quanlynhahang21CN1;Integrated Security=True;Encrypt=False";

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
    }
}
