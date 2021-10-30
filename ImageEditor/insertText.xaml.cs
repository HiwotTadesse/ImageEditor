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
using System.Globalization;

namespace ImageEditor
{
    /// <summary>
    /// Interaction logic for insertText.xaml
    /// </summary>
    public partial class insertText : Window
    {
        public FormattedText ft;
        public insertText()
        {
            InitializeComponent();
            var value = typeof(Brushes).GetProperties().Select(p => new { Name = p.Name, Brush = p.GetValue(null) as Brush }).
               ToList();
           
            foreach (var item in value)
            {
                color.Items.Add(item.Name.ToString());
            }
            //Typeface t = ;
            foreach (FontFamily ff in Fonts.SystemFontFamilies)
            {
                font.Items.Add(ff.Source.ToString());
            }
            for (double i = 0; i < 200; i+=10)
            {
                size.Items.Add(i.ToString() + "pt");
            }

        }


        public Single Size {
            get
            {
                float fs = 10.0F;
                if (!string.IsNullOrEmpty(size.Text))
                    fs = Convert.ToSingle(size.Text.Replace("pt", ""));
                return fs;
            }
            set
            {
                size.Text = value.ToString();
            }
        }
        public string Font {
            get
            {
                return font.Text.ToString();
            }
            set
            {
                font.Text = value.ToString();
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

        public string message
        {
            get
            {
                return t.Text; 
            }
            set
            {
                t.Text = value.ToString();
            }
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
            Size = Convert.ToSingle(size.Text.Replace("pt", ""));
            Font = font.Text.ToString();
            Color = new BrushConverter().ConvertFromString(color.Text.ToString()) as SolidColorBrush;
            message =t.Text;
            pointx = Convert.ToDouble(x.Text);
            pointy = Convert.ToDouble(y.Text);
            var v = Convert.ToString(Size);
            Console.WriteLine("size "+v);
            Console.WriteLine("font "+Font);
            Console.WriteLine("color "+Color);
            Console.WriteLine("text "+message);
            Console.WriteLine("x "+pointy);
            Console.WriteLine("y "+pointx);
             ft = new FormattedText(message, CultureInfo.CurrentCulture, FlowDirection.LeftToRight, new Typeface(Font)
                , Size, Color);
            if (size.Text == null) { Size = 0; }
            if (font.Text == null) { Font = FontFamily.FamilyNames.Values.ElementAt(1); }
            if (color.Text == null) { Color = Brushes.Black; }
            if (x.Text == null) { pointx = 0; }
            if (y.Text == null) { pointy = 0;}
            if (t.Text == null) { message = ""; }
            if (t.Text == null && font.Text == null && size.Text == null && color.Text == null) { ft = null; }
                this.Close();
        }

        private void btncancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
       /* public FormattedText mytext {
            get {

            } set {

            } }*/
    }
}
