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
    /// Interaction logic for insertShape.xaml
    /// </summary>
    public partial class insertShape : Window
    {
        private string shapeType;

        int space = 10;
        public string[] v = { "Ecllipse", "Rectangle", "RoundedRectangle" };
        public insertShape()
        {
            InitializeComponent();
          
            for (int i = 0; i < v.Length; i++)
            {
               // shape.Items.Add(v[i]);
            }

            var value = typeof(Brushes).GetProperties().Select(p => new { Name = p.Name, Brush = p.GetValue(null) as Brush }).
               ToList();

            foreach (var item in value)
            {
                color.Items.Add(item.Name.ToString());
            }
            foreach (var item in value)
            {
                color1.Items.Add(item.Name.ToString());
            }
            int space = 20;
            //if (shape.Text == "Rectangle") 
            { 
                for (int i = 0; i < 4; i++)
                {
                    TextBox tb = new TextBox();
                    tb.Width = 355;
                    tb.HorizontalAlignment =HorizontalAlignment.Left;
                    tb.Margin = new Thickness { Bottom = 0, Left = 166, Right = 0, Top = 144+space};
                    grid.Children.Add(tb);
                    space += 33;
                }
            }
        }
        
        public Brush Color
        {
            get
            {

                var c = color.Text.ToString();
                return new BrushConverter().ConvertFromString(c) as SolidColorBrush;
            }
            set
            {
                color.Text = value.ToString();
            }
        }
        public Brush Color1
        {
            get
            {

                var c = color1.Text.ToString();
                return new BrushConverter().ConvertFromString(c) as SolidColorBrush;
            }
            set
            {
                color1.Text = value.ToString();
            }
        }

        private void color_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
