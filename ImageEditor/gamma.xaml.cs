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
    /// Interaction logic for gamma.xaml
    /// </summary>
    public partial class gamma : Window
    {
        public gamma()
        {
            InitializeComponent();
        }
        public int RedValue
        {
            get

            {
                return Convert.ToInt32(r.Text);
            }
            set
            {
                r.Text = value.ToString();
            }
        }
        public int GreenValue
        {
            get

            {
                return Convert.ToInt32(g.Text);
            }
            set
            {
                g.Text = value.ToString();
            }
        }
        public int BlueValue
        {
            get

            {
                return Convert.ToInt32(b.Text);
            }
            set
            {
                b.Text = value.ToString();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RedValue = int.Parse(r.Text);
            GreenValue = int.Parse(g.Text);
            BlueValue = int.Parse(b.Text);
            if (r.Text == null) {
                RedValue = 0;
            }
            if (g.Text == null)
            {
                GreenValue = 0;
            }
            if (b.Text == null)
            {
                BlueValue = 0;
            }
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
