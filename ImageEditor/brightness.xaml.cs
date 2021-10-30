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
    /// Interaction logic for brightness.xaml
    /// </summary>
    public partial class brightnesswin : Window
    {
        ImageHandler im = new ImageHandler();
       
        public brightnesswin()
        {
            
            InitializeComponent();
            
           
        }

         public  int BrightnessValue
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

        private void v_TextChanged(object sender, TextChangedEventArgs e)
        {   
            
            
        }

        private void btnOk_Click(object sender, RoutedEventArgs e)
        {

            BrightnessValue = int.Parse(v.Text);
            if (v.Text == null) {
                BrightnessValue = 0;
            }
            if (im.CurrentBitmap == null) {
                BrightnessValue = 0;
            }
            Close();
        }

        
    }
}
