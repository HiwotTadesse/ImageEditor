using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ImageEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ImageHandler imageHandler = new ImageHandler();
        OpenFileDialog op;
        database dd = new database();
        private bool opened = false;
        


        public MainWindow()
        {
            InitializeComponent();
            op = new OpenFileDialog();
            op.RestoreDirectory = true;
            op.InitialDirectory = "C:\\";
            op.FilterIndex = 1;
            op.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";
            
            INIT();



        }

        

        private void open(object sender, RoutedEventArgs e) {
           // imageHandler.RestorePrevious();
            if (op.ShowDialog() == true)
            {
                opened = true;
                imageHandler.BitmapPath = op.FileName;
                imageHandler.BitmapBeforeProcessing = new BitmapImage(new Uri(imageHandler.BitmapPath));
                imageHandler.CurrentBitmap = new BitmapImage(new Uri(imageHandler.BitmapPath));
                imageHandler.CurrentWritableBitmap = new WriteableBitmap(imageHandler.CurrentBitmap);
                this.img.Source = imageHandler.CurrentBitmap;
            }
            
        }

        

       private void save(object sender, RoutedEventArgs e)
        {
           if (opened == true) { string path = imageHandler.save(imageHandler.CurrentBitmap); }
          

        }
       /* public byte[] ToByte(BitmapImage bitmap)
        {
            bitmap = imageHandler.CurrentBitmap;
            using (MemoryStream ms = new MemoryStream())
            {
                
            }
        }*/
          
       
        private System.Windows.Point firstPoint = new System.Windows.Point();
        public void INIT()
        {
            img.MouseLeftButtonDown += (ss, ee) =>
            {
                firstPoint = ee.GetPosition(this);
                img.CaptureMouse();
            };

            img.MouseWheel += (ss, ee) => {
                Matrix mat = img.RenderTransform.Value;
                System.Windows.Point mouse = ee.GetPosition(img);

                if (ee.RightButton == MouseButtonState.Pressed)
                {
                    if (ee.Delta > 0)
                    {
                        mat.RotateAtPrepend(2, mouse.X, mouse.Y);
                    }
                    else
                    {
                        mat.RotateAtPrepend(-2, mouse.X, mouse.Y);
                    }

                }
                else
                {
                    if (ee.Delta > 0)
                    {
                        mat.ScaleAtPrepend(1.15, 1.15, mouse.X, mouse.Y);
                    }
                    else
                    {
                        mat.ScaleAtPrepend(1 / 1.15, 1 / 1.15, mouse.X, mouse.Y);
                    }

                }
                MatrixTransform mtf = new MatrixTransform(mat);
                img.RenderTransform = mtf;
            };
            img.MouseMove += (ss, ee) => {
                if (ee.LeftButton == MouseButtonState.Pressed)
                {
                    System.Windows.Point temp = ee.GetPosition(this);
                    System.Windows.Point res = new System.Windows.Point(firstPoint.X - temp.X, firstPoint.Y - temp.Y);

                    Canvas.SetLeft(img, Canvas.GetLeft(img) - res.X);
                    Canvas.SetTop(img, Canvas.GetTop(img) - res.Y);
                    firstPoint = temp;
                }
            };
            img.MouseUp += (ss, ee) => {
                img.ReleaseMouseCapture();

            };
        }
        private void exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void brightness(object sender, RoutedEventArgs e)
        {
            imageHandler.RestorePrevious();
            brightnesswin bb = new brightnesswin();
            bb.ShowDialog();
            this.img.Source = imageHandler.SetBrightness(bb.BrightnessValue, imageHandler.CurrentWritableBitmap);
            

        }
        private void undo(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                this.img.Source = imageHandler.ResetBitmap();
            }
        }
        private void clear(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                this.img.Source = imageHandler.clear();
            }
        }
        private void contrast(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                contrast c = new contrast();
                c.ShowDialog();
                this.img.Source = imageHandler.SetContrast(c.contrastValue, imageHandler.CurrentWritableBitmap);
            }
        }
        private void invert(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.SetInvert(imageHandler.CurrentWritableBitmap);
            }
        }
        private void blue(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.SetColorFilter(ImageHandler.ColorFilterTypes.Blue, imageHandler.CurrentWritableBitmap);
            }
        }
        private void green(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.SetColorFilter(ImageHandler.ColorFilterTypes.Green, imageHandler.CurrentWritableBitmap);
            }
        }
        private void red(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.SetColorFilter(ImageHandler.ColorFilterTypes.Red, imageHandler.CurrentWritableBitmap);
            }
            
        }
        
        private void gamma(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                gamma g = new gamma();
                g.ShowDialog();
                this.img.Source = imageHandler.SetGamma(g.RedValue, g.GreenValue, g.BlueValue, imageHandler.CurrentWritableBitmap);
            }
        }
        private void grayscale(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.SetGrayScale(imageHandler.CurrentWritableBitmap);
            }
        }
        private void rotation0(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.rotation(imageHandler.CurrentWritableBitmap, Rotation.Rotate0);
            }
        }
        private void rotation270(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.rotation(imageHandler.CurrentWritableBitmap, Rotation.Rotate270);
            }
        }
        private void rotation90(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.rotation(imageHandler.CurrentWritableBitmap, Rotation.Rotate90);
            }
        }
        private void rotation180(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.rotation(imageHandler.CurrentWritableBitmap, Rotation.Rotate180);
            }
        }
        private void crop(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                crop re = new crop();
                re.ShowDialog();
                this.img.Source = imageHandler.crop(imageHandler.CurrentWritableBitmap, imageHandler.CurrentBitmap, re.pointx, re.pointy,
                    re.Newwidth, re.Newheight);
            }
        }
        private void insertImage(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                insertImage im = new insertImage();
                im.ShowDialog();
                imageHandler.RestorePrevious();
                this.img.Source = imageHandler.insertImage(imageHandler.CurrentWritableBitmap, im.pointx, im.pointy);
            }
            
        }

        private void insertText(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                insertText iss = new insertText();
                iss.ShowDialog();

                this.img.Source = imageHandler.insertText(imageHandler.CurrentWritableBitmap, iss.ft, iss.pointx, iss.pointy);
            }
        }
        private void rectangle(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                Rectangle iS = new Rectangle();
                iS.ShowDialog();
                this.img.Source = imageHandler.insertShape(imageHandler.CurrentWritableBitmap, ImageHandler.ShapeType.Rectangle, iS.Color,
                    iS.Color1, iS.Size, iS.Pointx, iS.Pointy, iS.Newwidth, iS.Newheight);
            }
        }
        private void ellipse(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                Ecllipse iS = new Ecllipse();
                iS.ShowDialog();
                this.img.Source = imageHandler.insertShape(imageHandler.CurrentWritableBitmap, ImageHandler.ShapeType.Ellipse, iS.Color,
                    iS.Color1, iS.Size, iS.Pointx, iS.Pointy, iS.Newwidth, iS.Newheight);
            }
        }
        private void roundRectangle(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                RoundRectangle iS = new RoundRectangle();
                iS.ShowDialog();
                this.img.Source = imageHandler.insertShape(imageHandler.CurrentWritableBitmap, ImageHandler.ShapeType.RoundedRectangle, iS.Color,
                    iS.Color1, iS.Size, iS.Pointx, iS.Pointy, iS.Newwidth, iS.Newheight, iS.Radiusx, iS.Radiusy);
            }
        }
        private void resize(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                Resize re = new Resize();
                re.ShowDialog();
                this.img.Source = imageHandler.resize(imageHandler.CurrentWritableBitmap, re.Newwidth, re.Newheight);
            }
            
        }

        public void blur(object sender, RoutedEventArgs e)
        {
            if (opened == true)
            {
                imageHandler.RestorePrevious();
                blur b = new blur();
                b.ShowDialog();
                BlurBitmapEffect bbe = new BlurBitmapEffect();
                bbe.Radius = b.BlurValue;
                this.img.BitmapEffect = bbe;
            }
        }
        public void notes(object sender, RoutedEventArgs e)
        {

            Ttle nm = new Ttle();
            nm.ShowDialog();
            //tes nn = new notes(nm.ImageName);
            //.ShowDialog();
        }

        private void viewnote(object sender, RoutedEventArgs e)
        {
            viewNote vn = new viewNote();
            vn.ShowDialog();
        }

        
    }
}
