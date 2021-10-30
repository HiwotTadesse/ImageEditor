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
    /// Interaction logic for blur.xaml
    /// </summary>
    public partial class blur : Window
    {
        public blur()
        {
            InitializeComponent();
        }
        public int BlurValue
        {
            get

            {
                return Convert.ToInt32(v.Text);
            }
            set
            {
                v.Text = value.ToString();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BlurValue = int.Parse(v.Text);
            if (v.Text == null) {
                BlurValue = 0;
            }
            this.Close();
        }
    }
}
