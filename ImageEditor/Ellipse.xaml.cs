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
    /// Interaction logic for Ecllipse.xaml
    /// </summary>
    public partial class Ecllipse : Window
    {
        public int Pointx { get { return Convert.ToInt32(px.Text); } set { px.Text = value.ToString(); } }
        public int Pointy { get { return Convert.ToInt32(py.Text); } set { py.Text = value.ToString(); } }
        public int Newwidth { get { return Convert.ToInt32(width.Text); } set { width.Text = value.ToString(); } }
        public int Newheight { get { return Convert.ToInt32(height.Text); } set { height.Text = value.ToString(); } }

        public Ecllipse()
        {
            InitializeComponent();
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
            for (double i = 0; i < 200; i += 10)
            {
                color1_Copy.Items.Add(i.ToString() + "pt");
            }
        }
        public double Size
        {
            get
            {
                double fs = 0.0;
                if (!string.IsNullOrEmpty(color1_Copy.Text))
                    fs = Convert.ToSingle(color1_Copy.Text.Replace("pt", ""));
                return fs;
            }
            set
            {
                color1_Copy.Text = value.ToString();
            }
        }
        private void btnok(object sender, RoutedEventArgs e)
        {
            Pointx = Convert.ToInt32(px.Text);
            Color = new BrushConverter().ConvertFromString(color.Text.ToString()) as SolidColorBrush;
            Color1 = new BrushConverter().ConvertFromString(color1.Text.ToString()) as SolidColorBrush;
            Pointy = Convert.ToInt32(py.Text);
            Newwidth = Convert.ToInt32(width.Text);
            Newheight = Convert.ToInt32(height.Text);
            Size = Convert.ToDouble(color1_Copy.Text.Replace("pt", ""));
            if (px.Text == null) { Pointx = 0; }
            if (py.Text == null) { Pointy = 0; }
            if (width.Text == null) { Newwidth = 0; }
            if (height.Text == null) { Newheight = 0; }
            if (color.Text == null) { Color = Brushes.Black; }
            if (color1.Text == null) { Color1 = Brushes.Black; }
            this.Close();
        }

        private void btncancel(object sender, RoutedEventArgs e)
        {
            this.Close();
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
    }
}
