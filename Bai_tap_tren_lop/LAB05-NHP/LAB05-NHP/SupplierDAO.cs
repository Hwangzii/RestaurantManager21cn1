using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace LAB05_NHP
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=HOANGPHI;Initial Catalog=Northwind;Integrated Security=True;Encrypt=False";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bnLoadData_Click(object sender, RoutedEventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            SupplierDAO supplierDAO = new SupplierDAO();
            List<Supplier> suppliers = supplierDAO.GetAddSuppliers();
            dataGridviewSupplier.ItemsSource = suppliers;
        }

        private void btnSearchName_Click(object sender, RoutedEventArgs e)
        {
            string searchText = txtSearchText.Text.Trim();
            if (!string.IsNullOrEmpty(searchText))
            {
                SupplierDAO supplierDAO = new SupplierDAO();
                List<Supplier> searchResults = supplierDAO.SearchSuppliersByCompanyName(searchText);
                dataGridviewSupplier.ItemsSource = searchResults;
            }
            else
            {
                LoadSuppliers();
            }
        }

        private void MouseLeftButtonDown_Click(object sender,MouseButtonEventArgs e)
        {
            if (sender is DataGrid dataGrid)
            {
                var selectedItem = (dynamic)dataGrid.SelectedItem;
                int clickedRowID = selectedItem.ID;
                string clickedRowName = selectedItem.Name;
            }
        }

        private void txtSearchText_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                btnSearchName_Click(sender, e);
            }
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertSupplier();
        }

        private void InsertSupplier()
        {
            string companyName = txtBoxCompanyName.Text;
            string contactName = txtBoxContactName.Text;
            string contactTitle = txtBoxContactTitle.Text;
            string address = txtboxAddress.Text;
            string city = txtBoxCity.Text;
            string region = txtBoxRegion.Text;
            string postalCode = txtPastalCode.Text;
            string country = txtBoxCountry.Text;
            string phone = txtBoxPhone.Text;
            string fax = txtBoxFax.Text;
            string homepage = txtBoxHomepage.Text;

            if (!string.IsNullOrEmpty(companyName) && !string.IsNullOrEmpty(contactName) && !string.IsNullOrEmpty(contactTitle) &&
                !string.IsNullOrEmpty(address) && !string.IsNullOrEmpty(city) && !string.IsNullOrEmpty(postalCode) &&
                !string.IsNullOrEmpty(country) && !string.IsNullOrEmpty(phone))
            {
                Supplier newSupplier = new Supplier
                {
                    CompanyName = companyName,
                    ContactName = contactName,
                    ContactTitle = contactTitle,
                    Address = address,
                    City = city,
                    Region = region,
                    PostalCode = postalCode,
                    Country = country,
                    Phone = phone,
                    Fax = fax,
                    HomePage = homepage
                };

                SupplierDAO supplierDAO = new SupplierDAO();
                supplierDAO.InsertSupplier(newSupplier);

                MessageBox.Show("Insert successful!");
                LoadSuppliers();
                ClearTextBoxes();
            }
            else
            {
                MessageBox.Show("Please fill in all required fields!");
            }
        }

        private void ClearTextBoxes()
        {
            txtBoxCompanyName.Text = string.Empty;
            txtBoxContactName.Text = string.Empty;
            txtBoxContactTitle.Text = string.Empty;
            txtboxAddress.Text = string.Empty;
            txtBoxCity.Text = string.Empty;
            txtBoxRegion.Text = string.Empty;
            txtPastalCode.Text = string.Empty;
            txtBoxCountry.Text = string.Empty;
            txtBoxPhone.Text = string.Empty;
            txtBoxFax.Text = string.Empty;
            txtBoxHomepage.Text = string.Empty;
        }

        private void dataGridviewSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (dataGridviewSupplier.SelectedItem != null)
            {
                Supplier selectedSupplier = (Supplier)dataGridviewSupplier.SelectedItem;
                DisplaySupplierDetails(selectedSupplier);
            }
        }

        private void DisplaySupplierDetails(Supplier supplier)
        {
            txtBoxCompanyName.Text = supplier.CompanyName;
            txtBoxContactName.Text = supplier.ContactName;
            txtBoxContactTitle.Text = supplier.ContactTitle;
            txtboxAddress.Text = supplier.Address;
            txtBoxCity.Text = supplier.City;
            txtBoxRegion.Text = supplier.Region;
            txtPastalCode.Text = supplier.PostalCode;
            txtBoxCountry.Text = supplier.Country;
            txtBoxPhone.Text = supplier.Phone;
            txtBoxFax.Text = supplier.Fax;
            txtBoxHomepage.Text = supplier.HomePage;
        }

        
    }
}
