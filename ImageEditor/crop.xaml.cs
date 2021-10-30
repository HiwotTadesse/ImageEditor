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

namespace ImageEditor
{
    /// <summary>
    /// Interaction logic for crop.xaml
    /// </summary>
    public partial class crop : Window
    {
        ImageHandler im = new ImageHandler();
        public crop()
        {
            InitializeComponent();
        }

        public int Newwidth
        {
            get
            {
                double w = im.CurrentBitmap.PixelWidth;
                if (string.IsNullOrEmpty(width.Text))
                    width.Text = w.ToString();
                return Convert.ToInt32(width.Text);
            }

            set
            {
                width.Text = value.ToString();
            }
        }
        public int Newheight
        {
            get
            {
                double w = im.CurrentBitmap.PixelHeight;
                if (string.IsNullOrEmpty(height.Text))
                    height.Text = w.ToString();
                return Convert.ToInt32(height.Text);
            }

            set
            {
                height.Text = value.ToString();
            }
        }
        public int pointy
        {
            get
            {
                if (string.IsNullOrEmpty(py.Text))
                    py.Text = "0";
                return Convert.ToInt32(py.Text);
            }

            set
            {
                py.Text = value.ToString();
            }
        }
        public int pointx
        {
            get
            {
                if (string.IsNullOrEmpty(py.Text))
                    px.Text = "0";
                return Convert.ToInt32(px.Text);
            }

            set
            {
                px.Text = value.ToString();
            }
        }

        private void btnok(object sender, RoutedEventArgs e)
        {
            Newwidth = Convert.ToInt32(width.Text);
            Newheight = Convert.ToInt32(height.Text);
            pointx = Convert.ToInt32(px.Text);
            pointy = Convert.ToInt32(py.Text);
            this.Close();
        }

        private void btncancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
