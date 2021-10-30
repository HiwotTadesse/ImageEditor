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
    /// Interaction logic for viewNote.xaml
    /// </summary>
    public partial class viewNote : Window
    {
        database d = new database();
        int left = 0;
        int bottom = 0;
        int right = 0;
        int top = 0;
        int space = 10;
        public viewNote()
        {
            InitializeComponent();
          Dictionary<string, string> v= d.retriveImage();
            string title = "";
            
             
            for (int i = 0; i < v.Keys.Count; i++)
            {
               
                    title = "Title:";
                    Label l = new Label();
                    l.Content = title;
                    l.Foreground = Brushes.White;
                l.FontStyle = FontStyles.Italic;
                l.FontWeight = FontWeights.SemiBold;
                l.FontSize = 17;
                    l.Margin = new Thickness
                    {
                        Bottom = 10,
                        Left = 20,
                        Top =  10 + space,
                        Right = 0
                    };
                    
                    grid.Children.Add(l);
                space += 80;
                
            }
            space =10;
            for (int i = 0; i < v.Keys.Count; i++)
            {
                Label m = new Label();
                m.Content = v.Keys.ElementAt(i);
                m.FontWeight = FontWeights.SemiBold;
                m.Foreground = Brushes.Wheat;
                m.FontSize = 17;
                m.Margin = new Thickness
                {
                    Bottom = 10,
                    Left = 70,
                    Top = 10 + space,
                    Right = 0
                };
                grid.Children.Add(m);
                space += 80;
            }
            space = 30;
            for (int i = 0; i < v.Values.Count; i++)
            {
                title = "Note:";
                Label l = new Label();
                l.Content = title;
                l.Foreground = Brushes.White;
                l.FontStyle = FontStyles.Italic;
                l.FontWeight = FontWeights.SemiBold;
                l.FontSize = 17;
                l.Margin = new Thickness
                {
                    Bottom = 10,
                    Left = 20,
                    Top = 10 + space,
                    Right = 0
                };

                grid.Children.Add(l);
                space += 80;
            }
            space = 30;
            for (int i = 0; i < v.Values.Count; i++)
            {
                Label m = new Label();
                m.Content = v.Values.ElementAt(i);
                m.FontWeight = FontWeights.SemiBold;
                m.Foreground = Brushes.Wheat;
                m.FontSize = 17;
                m.Margin = new Thickness
                {
                    Bottom = 10,
                    Left = 70,
                    Top = 10 + space,
                    Right = 0
                };
                grid.Children.Add(m);
                space += 80;
            }


        }
        }

        
    }

