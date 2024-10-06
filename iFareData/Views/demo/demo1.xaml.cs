using iFareData.Models.demo;
using System;
using System.Collections.Generic;
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

namespace iFareData.Views.demo
{
    /// <summary>
    /// Interaction logic for demo1.xaml
    /// </summary>
    public partial class demo1 : Window
    {
        public demo1()
        {
            List<Person> people = new List<Person>
            {
                new Person { FullName = "John Doe1", Birthday = new DateTime(1990, 1, 1), City = "New York", Gender = "Male", Price = 100, Level = "Expert", IsSelected = false },
                new Person { FullName = "John Doe2", Birthday = new DateTime(1990, 1, 1), City = "New York", Gender = "Male", Price = 100, Level = "Expert", IsSelected = false },
                new Person { FullName = "John Doe3", Birthday = new DateTime(1990, 1, 1), City = "New York", Gender = "Male", Price = 100, Level = "Expert", IsSelected = false },
                new Person { FullName = "John Doe4", Birthday = new DateTime(1990, 1, 1), City = "New York", Gender = "Male", Price = 100, Level = "Expert", IsSelected = false },
                new Person { FullName = "Jane Smith", Birthday = new DateTime(1985, 5, 10), City = "Los Angeles", Gender = "Female", Price = 150, Level = "Intermediate", IsSelected = true }
            };
            InitializeComponent();

            myDataGrid.ItemsSource = people;
        }
        private void PriceColumn_Click(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            // Lấy TextBlock từ ô được click
            var textBlock = sender as TextBlock;
            if (textBlock != null)
            {
                // Lấy DataGridRow chứa ô được click
                DataGridRow row = FindParent<DataGridRow>(textBlock);
                if (row != null)
                {
                    // Lấy đối tượng Person tương ứng với hàng đó
                    Person selectedPerson = row.Item as Person;
                    if (selectedPerson != null)
                    {
                        // Hiển thị thông tin của Person trong MessageBox
                        MessageBox.Show($"Thông tin của Person:\n" +
                                        $"Full Name: {selectedPerson.FullName}\n" +
                                        $"Birthday: {selectedPerson.Birthday.ToString("yyyy-MM-dd")}\n" +
                                        $"City: {selectedPerson.City}\n" +
                                        $"Gender: {selectedPerson.Gender}\n" +
                                        $"Price: {selectedPerson.Price}\n" +
                                        $"Level: {selectedPerson.Level}");
                    }
                }
            }
        }

        // Hàm hỗ trợ để tìm đối tượng cha trong cây trực quan
        private T FindParent<T>(DependencyObject child) where T : DependencyObject
        {
            DependencyObject parentObject = VisualTreeHelper.GetParent(child);

            if (parentObject == null) return null;

            T parent = parentObject as T;
            if (parent != null)
            {
                return parent;
            }
            else
            {
                return FindParent<T>(parentObject);
            }
        }

        public void SelectAllCheckbox_Click(object sender, RoutedEventArgs e)
        {
            // Lấy trạng thái của checkbox "Select All"
            var selectAllCheckBox = sender as CheckBox;
            bool isChecked = selectAllCheckBox?.IsChecked ?? false;

            // Lặp qua tất cả các item trong DataGrid và cập nhật IsSelected
            foreach (var item in myDataGrid.Items)
            {
                var person = item as Person;
                if (person != null)
                {
                    person.IsSelected = isChecked;
                }
            }

            // Cập nhật lại DataGrid
            myDataGrid.Items.Refresh();
        }
    }
}
