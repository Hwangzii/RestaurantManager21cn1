﻿using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace loginPage
{
    /// <summary>
    /// Interaction logic for doanhthu.xaml
    /// </summary>
    public partial class doanhthu : UserControl
    {
        public SeriesCollection SeriesCollection { get; set; }
        public string[] Labels { get; set; }
        private string selectedYear;


        public doanhthu()
        {
            InitializeComponent();

            LoadYears();

            // Initialize SeriesCollection
            SeriesCollection = new SeriesCollection();

            LoadCbb();

            // Set SeriesCollection to chart
            ColumnChart.Series = SeriesCollection;

            var axisX = new Axis
            {
                Labels = Labels,
                MinValue = 1,
                MaxValue = 12,
                Position = AxisPosition.LeftBottom
            };
            ColumnChart.AxisX.Add(axisX);
        }

        private void btnxemDoanhThu_Click(object sender, RoutedEventArgs e)
        {
            HoaDonDAO hoadonDAO = new HoaDonDAO();

            var hoadonItemsSource = hoadonDAO.GetAddHoaDon();

            Dataview.ItemsSource = hoadonItemsSource;
        }
        private void LoadDataAndBindToChart(string year)
        {
            string connectionString = @"Data Source=THANHHOA\MSSQLSERVER01;Initial Catalog=Quanlynhahang21CN1.1;Integrated Security=True;Encrypt=False";
            string query = @"SELECT MONTH(NgayAn) AS Month, SUM(Tongtien) AS Revenue FROM HoaDon WHERE YEAR(NgayAn) = @Year GROUP BY MONTH(NgayAn) ORDER BY Month";

            // Initialize Labels and Revenue array
            double[] revenueByMonth = new double[12];

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Year", year);
                    connection.Open();

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int month = Convert.ToInt32(reader["Month"]);
                            double revenue = Convert.ToDouble(reader["Revenue"]);
                            revenueByMonth[month - 1] = revenue; // Month starts from 1 but array index starts from 0
                        }
                    }
                }
            }

            // Populate SeriesCollection and Labels
            SeriesCollection.Add(new ColumnSeries
            {
                Title = "Doanh thu",
                Values = new ChartValues<double>(revenueByMonth)
            });

        }

        private void LoadCbb() 
        { 
            // Set Labels
            Labels = new[]
            {
                "Tháng 1", "Tháng 2", "Tháng 3", "Tháng 4", "Tháng 5", "Tháng 6", "Tháng 7", "Tháng 8", "Tháng 9", "Tháng 10", "Tháng 11", "Tháng 12"
            };
        }

        private void LoadYears()
        {
            // Tạo danh sách các năm từ năm 2000 đến năm hiện tại
            List<string> years = new List<string>();
            int currentYear = DateTime.Now.Year;
            for (int year = 2020; year <= currentYear; year++)
            {
                years.Add(year.ToString()); // Chuyển đổi từ int sang string
            }

            // Gán danh sách năm vào ComboBox
            YearComboBox.ItemsSource = years;
        }


        private void YearComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedYear = YearComboBox.SelectedItem as string;
            LoadDataAndBindToChart(selectedYear);
        }
    }
}