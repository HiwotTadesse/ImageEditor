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
    /// Interaction logic for notes.xaml
    /// </summary>
    public partial class notes : Window
    {
        ImageHandler imageHandler = new ImageHandler();
        database dd = new database();
        string title;
        public notes(string title)
        {
            InitializeComponent();
            this.title = title;
            Console.WriteLine(title);
        }

        public string note {
            get
            {
                return tt.Text;
            }
            set {
                tt.Text = value.ToString();
            }
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
             
            note = tt.Text.ToString();
            Console.WriteLine(note);
            MessageBoxResult mb = MessageBox.Show("Do you want to save your notes?", "Confirmation", MessageBoxButton.YesNo, MessageBoxImage.Question);
            this.Close();
            if (mb == MessageBoxResult.Yes)
            {
                dd.insertImageInToDatabase(title, note);
                
                  
                }if (mb == MessageBoxResult.No) {
                this.Close();
            }
            }
            
        }
    }
