using iFareData.Models.demo;
using System.ComponentModel;
using System.Windows.Input;

namespace iFareData.ViewModels.demo
{
    public class ProductViewModel : BaseViewModel
    {
        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                _productName = value;
                OnPropertyChanged();
            }
        }

        public ICommand UpdateProductNameCommand { get; set; }

        public ProductViewModel()
        {
            UpdateProductNameCommand = new RelayCommand<object>(
                (param) => CanUpdateProductName(),
                (param) => UpdateProductName());
        }

        private bool CanUpdateProductName()
        {
            // Logic xác định khi nào nút bấm có thể được kích hoạt
            return !string.IsNullOrWhiteSpace(ProductName);
        }

        private void UpdateProductName()
        {
            // Logic để cập nhật tên sản phẩm
            ProductName = "Updated Product";
        }
    }
}
