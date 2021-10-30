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
    /// Interaction logic for Resize.xaml
    /// </summary>
    public partial class Resize : Window
    {
        ImageHandler im = new ImageHandler();
        public Resize()
        {
            InitializeComponent();
        }
        public int Newwidth {
            get
            {
               
                return Convert.ToInt32(width.Text);
            }

            set {
                width.Text = value.ToString();
            }
        }
        public int Newheight
        {
            get
            {
                return Convert.ToInt32(height.Text);
            }

            set
            {
                height.Text = value.ToString();
            }
        }

       
        

        private void btnok(object sender, RoutedEventArgs e)
        {
            Newwidth = int.Parse(width.Text);
            Newheight = int.Parse(height.Text);
            if (width.Text == null) {
                Newwidth = 0;
            }
            if (height.Text == null)
            {
                Newheight = 0;
            }
            this.Close();
        }

        private void btncancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
