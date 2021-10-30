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
    /// Interaction logic for Ttle.xaml
    /// </summary>
    public partial class Ttle : Window
    {
        database d = new database();
        public Ttle()
        {
            InitializeComponent();
        }
        public string ImageName
        {
            get
            {
                return v.Text;
            }
            set
            {
                v.Text = value.ToString();
            }
        }




        private void btnok(object sender, RoutedEventArgs e)
        {
            ImageName = v.Text.ToString();
            bool b = d.retrieveName(ImageName);
            if (b == true)
            {
                MessageBoxResult mb = MessageBox.Show("There is already same title in the Store, Do you want to change name?", "Asking", MessageBoxButton.YesNo, MessageBoxImage.Error);
                if (mb == MessageBoxResult.Yes)
                {
                    v.Text = "";
                    new Ttle();
                }
            }
            else
            {

                notes n = new notes(ImageName);
                n.ShowDialog();
                this.Close();
                if (v.Text == null) { ImageName = ""; this.Close(); }
            }
        }
        

        private void btncancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
