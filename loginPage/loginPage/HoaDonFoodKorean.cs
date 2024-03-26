using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace loginPage
{
    internal class HoaDonFoodKorean
    {
        String connectionString = "Data Source=HOANGPHI;Initial Catalog=quanlynhahang21CN1; Integrated Security=True; Encrypt=True";

        public HoaDonFoodKorean()
        {

        }

        public List<HoaDon> GetAddBills()
        {
            List<HoaDon> listBills = new List<HoaDon>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM HoaDon", sqlConnection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        HoaDon hoaDonKH = new HoaDon();
                        hoaDonKH.ID = reader.GetInt32(0);
                        hoaDonKH.maKH = reader.GetInt32(1);
                        hoaDonKH.maBan = reader.GetInt32(4);
                        hoaDonKH.TenKH = reader.GetString(6);
                        hoaDonKH.SDTKH = reader.GetString(7);
                        hoaDonKH.SL = reader.GetInt32(8);
                        hoaDonKH.TongTien = reader.GetDouble(9);
                        hoaDonKH.NgayAn = reader.GetDateTime(10);

                        listBills.Add(hoaDonKH);
                    }
                }
            }

            return listBills; // Thêm câu lệnh return này
        }
    }
}
