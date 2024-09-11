using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iFareData.Component.Constant
{
    public class Constant
    {
        // Lấy đường dẫn thư mục của ứng dụng khi ứng dụng chạy
        private static readonly string baseFolderPath = AppDomain.CurrentDomain.BaseDirectory;

        // Đường dẫn thư mục được khởi tạo tại thời điểm chạy
        public static readonly string CONFIG_FOLDER_PATH = Path.Combine(baseFolderPath, "CONFIG");
        public static readonly string TRACE_FOLER_PATH = Path.Combine(baseFolderPath, "TRACE");
        public static readonly string LOG_FOLDER_PATH = Path.Combine(baseFolderPath, "LOG");

        public static readonly string BLANK_VALUE = string.Empty;
        public static readonly int ZERO_NUMBER = 0;
        

    }
}
