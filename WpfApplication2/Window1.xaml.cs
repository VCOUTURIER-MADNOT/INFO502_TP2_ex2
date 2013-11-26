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

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class imageRealSizeForm : Window
    {
        public imageRealSizeForm(String path)
        {
            InitializeComponent();

            BitmapImage bi = new BitmapImage(new Uri(path));
            this.image.Source = bi;
            this.image.Visibility = System.Windows.Visibility.Visible;
            this.Height = image.Height;
            this.Width = image.Width;
        }
    }
}
