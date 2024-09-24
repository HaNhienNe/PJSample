using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for IFareDataWindow.xaml
    /// </summary>
    public partial class IFareDataWindow : Window
    {
        public static class DataGridRowUtils
        {
            public static DataGridRow GetRowContainingElement(FrameworkElement element)
            {
                while (element != null && !(element is DataGridRow))
                {
                    element = VisualTreeHelper.GetParent(element) as FrameworkElement;
                }
                return element as DataGridRow;
            }
        }
        class Person : INotifyPropertyChanged
        {
            private bool _isSelected;
            public bool IsSelected
            {
                get { return _isSelected; }
                set
                {
                    _isSelected = value;
                    OnPropertyChanged(nameof(IsSelected));
                }
            }

            public static int count = 0;
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string City { get; set; }
            public Person ()
            {
                IsSelected = true;
                count++;
                LastName = "O";
                City = "X";
                FirstName = $"First name {count}";
            }

            public static List<Person> init()
            {
                var list = new List<Person> ();
                list.Add(new Person());
                list.Add(new Person());
                list.Add(new Person());
                list.Add(new Person());
                list.Add(new Person());
                list.Add(new Person());
                list.Add(new Person());
                list.Add(new Person());
                list.Add(new Person());
                return list;

            }
            public event PropertyChangedEventHandler PropertyChanged;
            protected virtual void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public IFareDataWindow()
        {
            InitializeComponent();
            this.DataContext = Person.init();
        }
        private void RowCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            // Lấy row hiện tại và chọn nó
            var checkBox = sender as CheckBox;
            var dataGridRow = DataGridRow.GetRowContainingElement(checkBox);

            if (dataGridRow != null)
            {
                dataGridRow.IsSelected = true; // Chọn row
            }
        }

        private void RowCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            // Lấy row hiện tại và bỏ chọn nó
            var checkBox = sender as CheckBox;
            var dataGridRow = DataGridRow.GetRowContainingElement(checkBox);

            if (dataGridRow != null)
            {
                dataGridRow.IsSelected = false; // Bỏ chọn row
                dataGridRow.Background = Brushes.White;
            }
        }

        private void SelectAllCheckBox_Checked(object sender, RoutedEventArgs e)
        {
            foreach (var item in MyDataGrid.Items)
            {
                var dataGridRow = MyDataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (dataGridRow != null)
                {
                    dataGridRow.IsSelected = true; // Chọn row
                    (item as Person).IsSelected = true; // Chọn checkbox
                    dataGridRow.Background = Brushes.Red;

                }
            }
        }

        private void SelectAllCheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            foreach (var item in MyDataGrid.Items)
            {
                var dataGridRow = MyDataGrid.ItemContainerGenerator.ContainerFromItem(item) as DataGridRow;
                if (dataGridRow != null)
                {
                    dataGridRow.IsSelected = false; // Bỏ chọn row
                    (item as Person).IsSelected = false; // Bỏ chọn checkbox
                }
            }
        }
    }
}
