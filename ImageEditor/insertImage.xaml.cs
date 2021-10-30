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
    /// Interaction logic for insertImage.xaml
    /// </summary>
    public partial class insertImage : Window
    {
        public insertImage()
        {
            InitializeComponent();
        }
        public double pointx
        {
            get
            {
                if (string.IsNullOrEmpty(x.Text))
                    x.Text = "0";
                return Convert.ToDouble(x.Text);
            }
            set
            {
                x.Text = value.ToString();
            }
        }
        public double pointy
        {
            get
            {
                if (string.IsNullOrEmpty(y.Text))
                    y.Text = "0";
                return Convert.ToDouble(y.Text);
            }
            set
            {
                y.Text = value.ToString();
            }
        }
        private void btnok(object sender, RoutedEventArgs e)
        {
            pointx = double.Parse(x.Text);
            pointy = double.Parse(y.Text);
            if (x.Text == null) { pointx = 0; }
            if (y.Text == null) { pointy = 0; }
            this.Close();
        }

        private void btncancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
