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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace WpfApplication2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            updateList();
        }

        public void onClickUrlBox(Object sender, EventArgs e)
        {
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.ShowDialog();
            this.urlBox.Text = fbd.SelectedPath;
        }

        public void onChangeUrlBox(Object sender, EventArgs e)
        {
            updateList();
        }

        private void updateList()
        {
            DirectoryInfo di = new DirectoryInfo(Directory.Exists(this.urlBox.Text) ? this.urlBox.Text : "C:/Users/Valentin/Pictures");
            string[] extensions = new[] { ".jpg", ".tiff", ".bmp" };

            FileInfo[] files = di.GetFiles().Where(f => extensions.Contains(f.Extension.ToLower())).ToArray();
            foreach(FileInfo fi in files)
            {
                
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(fi.FullName));
                addThumbnail(image, 100);
            }
        }

        private void addThumbnail(Image image, int maxSize)
        {
            Image thumbnail = new Image();
            thumbnail.Source = image.Source;
            if(image.Height > image.Width)
            {
                thumbnail.Width = image.Width * maxSize / image.Height;
                thumbnail.Height = maxSize;
            }
            else
            {
                thumbnail.Height = image.Height * maxSize / Width;
                thumbnail.Width = maxSize;
            }

            thumbnail.MouseUp += onClickImage;
            thumbnail.Margin = new Thickness(5);

            this.imageGrid.Children.Add(thumbnail);
        }

        private void onClickImage(Object sender, EventArgs e)
        {
            Image img = (Image)sender;
            if(img != null)
            {
                imageRealSizeForm form = new imageRealSizeForm(getPath(img));
                form.ShowDialog();
            }
        }

        private String getPath(Image img)
        {
            BitmapImage bmpImg = img.Source as BitmapImage;
            return bmpImg.UriSource.AbsolutePath;
        }
    }
}
