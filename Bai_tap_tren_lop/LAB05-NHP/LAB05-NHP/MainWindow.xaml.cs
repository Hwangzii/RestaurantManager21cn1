using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace LAB05_NHP
{
    internal class SupplierDAO
    {
        string connectionString = "Data Source=HOANGPHI;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False";


        public SupplierDAO()
        {

        }

        public List<Supplier> GetAddSuppliers()
        {
            List<Supplier> listSuppliers = new List<Supplier>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SUPPLIERS", sqlConnection);

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Supplier supplier = new Supplier();
                        supplier.ID = reader.GetInt32(0);
                        supplier.CompanyName = reader.GetString(1);
                        supplier.ContactName = reader.GetString(2);
                        supplier.ContactTitle = reader.GetString(3);
                        supplier.Address = reader.GetString(4);
                        supplier.City = reader.GetString(5);
                        supplier.Region = reader.IsDBNull(6) ? null : reader.GetString(6);
                        supplier.PostalCode = reader.GetString(7);
                        supplier.Country = reader.GetString(8);
                        supplier.Phone = reader.GetString(9);
                        supplier.Fax = reader.IsDBNull(10) ? null : reader.GetString(10);
                        supplier.HomePage = reader.IsDBNull(11) ? null : reader.GetString(11);

                        listSuppliers.Add(supplier);
                    }
                }
            }
            return listSuppliers;
        }

        public List<Supplier> SearchSuppliersByCompanyName(string companyName)
        {
            List<Supplier> searchResults = new List<Supplier>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT * FROM SUPPLIERS WHERE CompanyName LIKE @CompanyName", sqlConnection);
                sqlCommand.Parameters.AddWithValue("@CompanyName", "%" + companyName + "%");

                using (SqlDataReader reader = sqlCommand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        Supplier supplier = new Supplier();
                        supplier.ID = reader.GetInt32(0);
                        supplier.CompanyName = reader.GetString(1);
                        supplier.ContactName = reader.GetString(2);
                        supplier.ContactTitle = reader.GetString(3);
                        supplier.Address = reader.GetString(4);
                        supplier.City = reader.GetString(5);
                        supplier.Region = reader.IsDBNull(6) ? null : reader.GetString(6);
                        supplier.PostalCode = reader.GetString(7);
                        supplier.Country = reader.GetString(8);
                        supplier.Phone = reader.GetString(9);
                        supplier.Fax = reader.IsDBNull(10) ? null : reader.GetString(10);
                        supplier.HomePage = reader.IsDBNull(11) ? null : reader.GetString(11);

                        searchResults.Add(supplier);
                    }
                }
            }
            return searchResults;
        }

        // Phương thức chèn dữ liệu nhà cung cấp vào cơ sở dữ liệu
        public void InsertSupplier(Supplier supplier)
        {
            // Tạo chuỗi truy vấn SQL INSERT
            string query = @"INSERT INTO Suppliers (CompanyName, ContactName, ContactTitle, Address, City, Region, PostalCode, Country, Phone, Fax, HomePage) 
                            VALUES (@CompanyName, @ContactName, @ContactTitle, @Address, @City, @Region, @PostalCode, @Country, @Phone, @Fax, @HomePage)";

            // Tạo kết nối đến cơ sở dữ liệu
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection.Open();

                // Tạo đối tượng SqlCommand để thực hiện truy vấn
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Thêm các tham số vào truy vấn
                    command.Parameters.AddWithValue("@CompanyName", supplier.CompanyName);
                    command.Parameters.AddWithValue("@ContactName", supplier.ContactName);
                    command.Parameters.AddWithValue("@ContactTitle", supplier.ContactTitle);
                    command.Parameters.AddWithValue("@Address", supplier.Address);
                    command.Parameters.AddWithValue("@City", supplier.City);
                    command.Parameters.AddWithValue("@Region", supplier.Region);
                    command.Parameters.AddWithValue("@PostalCode", supplier.PostalCode);
                    command.Parameters.AddWithValue("@Country", supplier.Country);
                    command.Parameters.AddWithValue("@Phone", supplier.Phone);
                    command.Parameters.AddWithValue("@Fax", supplier.Fax);
                    command.Parameters.AddWithValue("@HomePage", supplier.HomePage);

                    // Thực thi truy vấn INSERT
                    int rowsAffected = command.ExecuteNonQuery();

                    // Kiểm tra xem có bao nhiêu dòng bị ảnh hưởng bởi truy vấn
                    if (rowsAffected > 0)
                    {
                        Console.WriteLine("Insert successful!");
                    }
                    else
                    {
                        Console.WriteLine("Insert failed!");
                    }
                }
            }
        }

       

    }
}