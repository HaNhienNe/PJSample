using iFareData.Models.Initialization.ini;
using iFareData.Service.impl.Initialization;
using iFareData.Service.Interfaces.Initialization;
using iFareData.ViewModels.demo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        private IAppInitializer _appInitializer;
        IFareDataIni iFareDataIni;
        SwsURLIni swsURLIni;
        public ProductWindow()
        {
            InitializeComponent();
            this.DataContext = new ProductViewModel();
            _appInitializer = new AppInitializer();
            _appInitializer.InitializeFoldersAndFiles();
             iFareDataIni = _appInitializer.getIFareDataIni();
             swsURLIni = _appInitializer.getSwsURLIni();
        }


        private void rdbDefault_Checked(object sender, RoutedEventArgs e)
        {
            if (txtAddress != null && txtPort!= null)
            {
                txtAddress.IsEnabled = false;
                txtAddress.Background = new SolidColorBrush(Colors.LightGray);
                txtAddress.Clear();

                txtPort.IsEnabled = false;
                txtPort.Background = new SolidColorBrush(Colors.LightGray);
                txtPort.Clear();
            }
            
        }

        private void rdbCustom_Checked(object sender, RoutedEventArgs e)
        {
            if (txtAddress != null && txtPort != null)
            {
                txtAddress.IsEnabled = true;
                txtAddress.Background = new SolidColorBrush(Colors.White);
                txtAddress.Text = iFareDataIni.CONNECT.ADDRESS;

                txtPort.IsEnabled = true;
                txtPort.Background = new SolidColorBrush(Colors.White);
                txtPort.MaxLength = 4;
                txtPort.Text = iFareDataIni.CONNECT.PORT;


            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            
            if(iFareDataIni != null && swsURLIni != null)
            {
                if(iFareDataIni.CONNECT.CONNECT_SETTING == 0)
                {
                    rdbDefault.IsChecked = true;
                    loadDefault();
                } else if(iFareDataIni.CONNECT.CONNECT_SETTING == 1)
                {
                    rdbCustom.IsChecked = true;
                    txtAddress.Text = iFareDataIni.CONNECT.ADDRESS;
                    txtPort.Text = iFareDataIni.CONNECT.PORT;
                }

                txtUsername.Text = iFareDataIni.CONNECT.CONNECT_USER;
                txtPassword.Text = iFareDataIni.CONNECT.CONNECT_PASSWORD;

            }

        }

        private void loadDefault()
        {
            rdbDefault.IsChecked = true;
            txtAddress.Background = new SolidColorBrush(Colors.LightGray);
            txtAddress.IsEnabled = false;
            txtAddress.Clear();
            txtPort.IsEnabled = false;
            txtPort.Background = new SolidColorBrush(Colors.LightGray);
            txtPort.Clear();
        }
        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if(rdbDefault.IsChecked == true)
            {
                iFareDataIni.CONNECT.CONNECT_SETTING = 0;

            }
            else if(rdbCustom.IsChecked == true)
            {
                if(string.IsNullOrEmpty(txtAddress.Text.Trim())) {
                    MessageBox.Show("Bo trong address");
                    return;
                }

                if (string.IsNullOrEmpty(txtPort.Text.Trim()))
                {
                    MessageBox.Show("Bo trong port");
                    return;
                }

                Regex regex = new Regex("[^0-9]+");
                bool isNumber = regex.IsMatch(txtPort.Text.Trim());
                if (isNumber)
                {
                    MessageBox.Show("Port không đúng định dạng");
                    return;
                }

                iFareDataIni.CONNECT.CONNECT_SETTING = 1;
                iFareDataIni.CONNECT.ADDRESS = txtAddress.Text;
                iFareDataIni.CONNECT.PORT = txtPort.Text;
                iFareDataIni.CONNECT.CONNECT_USER = txtUsername.Text;
                iFareDataIni.CONNECT.CONNECT_PASSWORD = txtPassword.Text;
            }

            iFareDataIni.CreateIniFile();
            MessageBox.Show("Da luu thiet dinh");

        }
    }
}
