using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;


namespace ImageEditor
{
    class ImageHandler
    {
       private BitmapImage _currentBitmap;
        private BitmapImage _currentBitmap2;
        private WriteableBitmap _currentWritableBitmap;
        private WriteableBitmap _currentWritableBitmap2;
        private string _BitmapPath;
        private string _BitmapPath2;
        database dd = new database();
        insertText t = new insertText();
        private BitmapImage _bitmapbeforeProcessing;
        private RenderTargetBitmap rendered;
        private string path;
                                           // OpenFileDialog op;

        public ImageHandler() { }
        public string savedPath {
            get
            {
                return path;
            }
            set
            {
                path = value;
            } }
        public RenderTargetBitmap RenderTarget {
            get
            {
                rendered = new RenderTargetBitmap(_currentWritableBitmap.PixelWidth, _currentWritableBitmap.PixelHeight,
                    _currentWritableBitmap.DpiX, _currentWritableBitmap.DpiY, PixelFormats.Bgr32);
                return rendered;
            }
            set
            {
                rendered = value;
            }
        }

        public BitmapImage CurrentBitmap {
            get
            {
                if (_currentBitmap == null) {
                    _currentBitmap = new BitmapImage();
                }
                return _currentBitmap;
            }
            set
            {
                _currentBitmap = value;
            }
        }
        public BitmapImage CurrentBitmap2
        {
            get
            {
                if (_currentBitmap2 == null)
                {
                    _currentBitmap2 = new BitmapImage(new Uri(_BitmapPath2));
                }
                return _currentBitmap2;
            }
            set
            {
                _currentBitmap = value;
            }
        }
        public BitmapImage BitmapBeforeProcessing
        {
            get {
             //   _bitmapbeforeProcessing = new BitmapImage(new Uri(_BitmapPath));
                return _bitmapbeforeProcessing; }
            set { _bitmapbeforeProcessing = value; }
        }
        public String BitmapPath {
            get
            {
                return _BitmapPath;
            }
            set
            {
                _BitmapPath = value;
            }
        }
        public String BitmapPath2
        {
            get
            {
                return _BitmapPath2;
            }
            set
            {
                _BitmapPath2 = value;
            }
        }

        public WriteableBitmap CurrentWritableBitmap
        {
             get
             {
                if ((_currentWritableBitmap == null && _currentBitmap == null))
                {
                    _currentWritableBitmap = new WriteableBitmap(_currentBitmap.PixelWidth, _currentBitmap.PixelHeight,
                        _currentBitmap.DpiX, _currentBitmap.DpiY, PixelFormats.Indexed8, BitmapPalettes.Gray256);

                }
               
                return _currentWritableBitmap;
             } set
             {
                _currentWritableBitmap = value;
             }
        }
        public WriteableBitmap CurrentWritableBitmap2
        {
            get
            {
                if (_currentWritableBitmap2 == null && _currentBitmap2 == null)
                {
                    _currentWritableBitmap2 = new WriteableBitmap(_currentBitmap2 as BitmapSource);
                }
                return _currentWritableBitmap2;
            }
            set
            {
                _currentWritableBitmap2 = value;
            }
        }
        public BitmapImage ResetBitmap()
        {
            if (_currentBitmap != null && _bitmapbeforeProcessing != null)
            {
                BitmapImage temp = (BitmapImage)_currentBitmap.Clone();
                _currentBitmap = (BitmapImage)_bitmapbeforeProcessing.Clone();
                _bitmapbeforeProcessing = (BitmapImage)temp.Clone();
            }
            return _bitmapbeforeProcessing;
        }
        public BitmapImage clear() {
            return _currentBitmap = new BitmapImage();
        }
        public string save(BitmapImage bi) {
            bi = (BitmapImage)_currentBitmap.Clone();
            SaveFileDialog sDlg = new SaveFileDialog();
            sDlg.RestoreDirectory = true;
            sDlg.InitialDirectory = "C:\\Users\\hp-\\Pictures\\";
            sDlg.FilterIndex = 1;
            sDlg.Filter = "jpg Files (*.jpg)|*.jpg|gif Files (*.gif)|*.gif|png Files (*.png)|*.png |bmp Files (*.bmp)|*.bmp";
            if (sDlg.ShowDialog() == true)
            {

                var encoder = new JpegBitmapEncoder();
                encoder.Frames.Add(BitmapFrame.Create(bi));
                using (var stream = sDlg.OpenFile())
                {
                    encoder.Save(stream);
                    path =  Path.GetFileName(sDlg.FileName);

                }

            }
            return path;
        }

        public BitmapImage SetBrightness(int brightness, WriteableBitmap temp2) {
           
            brightness = brightness * 255 / 100;
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();
            uint[] PixelData = new uint[temp2.PixelWidth * temp2.PixelHeight];
            temp2.CopyPixels(PixelData, 4 * temp2.PixelWidth, 0);
            for (uint i = 0; i < temp2.PixelHeight; i++)
            {
                for (uint j = 0; j < temp2.PixelWidth; j++)
                {
                    uint pixel = PixelData[i * temp2.PixelWidth + j];
                    byte[] dd = BitConverter.GetBytes(pixel);
                    int B = (int)dd[0] + brightness;
                    int G = (int)dd[1] + brightness;
                    int R = (int)dd[2] + brightness;
                    if (B < 0) B = 0;
                    if (B > 255) B = 255;
                    if (G < 0) G = 0;
                    if (G > 255) G = 255;
                    if (R < 0) R = 0;
                    if (R > 255) R = 255;
                    dd[0] = (byte)B;
                    dd[1] = (byte)G;
                    dd[2] = (byte)R;
                    PixelData[i * temp2.PixelWidth + j] = BitConverter.ToUInt32(dd, 0);
                }
            }
            temp2.WritePixels(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight), PixelData, 4 * temp2.PixelWidth, 0);
             _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
        }
        public BitmapImage SetContrast(double contrast, WriteableBitmap temp2)
        {

            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();
            uint[] PixelData = new uint[temp2.PixelWidth * temp2.PixelHeight];
            temp2.CopyPixels(PixelData, 4 * temp2.PixelWidth, 0);
            for (uint i = 0; i < temp2.PixelHeight; i++)
            {
                for (uint j = 0; j < temp2.PixelWidth; j++)
                {
                    uint pixel = PixelData[i * temp2.PixelWidth + j];
                    byte[] dd = BitConverter.GetBytes(pixel);
                    int B = (int)dd[0];
                    int G = (int)dd[1];
                    int R = (int)dd[2];

                    double pr = R / 255.0;
                    pr -= 0.5;
                    pr *= contrast;
                    pr += 0.5;
                    pr *= 255;
                    if (pr < 0) pr = 0;
                    if (pr > 255) pr = 255;

                    double pg = G / 255.0;
                    pg -= 0.5;
                    pg *= contrast;
                    pg += 0.5;
                    pg *= 255;
                    if (pg < 0) pg = 0;
                    if (pg > 255) pg = 255;

                    double pb = B / 255.0;
                    pb -= 0.5;
                    pb *= contrast;
                    pb += 0.5;
                    pb *= 255;
                    if (pb < 0) pb = 0;
                    if (pb > 255) pb = 255;

                    dd[0] = (byte)pb;
                    dd[1] = (byte)pg;
                    dd[2] = (byte)pr;
                    PixelData[i * temp2.PixelWidth + j] = BitConverter.ToUInt32(dd, 0);
                }
            }
            temp2.WritePixels(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight), PixelData, 4 * temp2.PixelWidth, 0);
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
            
        }
        public BitmapImage SetInvert(WriteableBitmap temp2)
        {

            // brightness = brightness * 255 / 100;
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();
            uint[] PixelData = new uint[temp2.PixelWidth * temp2.PixelHeight];
            temp2.CopyPixels(PixelData, 4 * temp2.PixelWidth, 0);
            for (uint i = 0; i < temp2.PixelHeight; i++)
            {
                for (uint j = 0; j < temp2.PixelWidth; j++)
                {
                    uint pixel = PixelData[i * temp2.PixelWidth + j];
                    byte[] dd = BitConverter.GetBytes(pixel);
                    int B = (int)dd[0];
                    int G = (int)dd[1];
                    int R = (int)dd[2];

                    byte one = (byte)(255 - R);
                    byte two = (byte)(255 - G);
                    byte three = (byte)(255 - B);

                    dd[0] = three;
                    dd[1] = two;
                    dd[2] = one;
                    PixelData[i * temp2.PixelWidth + j] = BitConverter.ToUInt32(dd, 0);
                }
            }
            temp2.WritePixels(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight), PixelData, 4 * temp2.PixelWidth, 0);
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
        }

        public enum ColorFilterTypes
        {
            Red,
            Green,
            Blue
        };

        public BitmapImage SetColorFilter(ColorFilterTypes colorFilterType, WriteableBitmap temp2)
        {
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();
            uint[] PixelData = new uint[temp2.PixelWidth * temp2.PixelHeight];
            temp2.CopyPixels(PixelData, 4 * temp2.PixelWidth, 0);
            for (uint i = 0; i < temp2.PixelHeight; i++)
            {
                for (uint j = 0; j < temp2.PixelWidth; j++)
                {
                    uint pixel = PixelData[i * temp2.PixelWidth + j];
                    byte[] dd = BitConverter.GetBytes(pixel);
                    int B = (int)dd[0];
                    int G = (int)dd[1];
                    int R = (int)dd[2];
                    int nPixelR = 0;
                    int nPixelG = 0;
                    int nPixelB = 0;
                    if (colorFilterType == ColorFilterTypes.Red)
                    {
                        nPixelR = R;
                        nPixelG = G - 255;
                        nPixelB = B - 255;
                    }
                    else if (colorFilterType == ColorFilterTypes.Green)
                    {
                        nPixelR = R - 255;
                        nPixelG = G;
                        nPixelB = B - 255;
                    }
                    else if (colorFilterType == ColorFilterTypes.Blue)
                    {
                        nPixelR = R - 255;
                        nPixelG = G - 255;
                        nPixelB = B;
                    }

                    nPixelR = Math.Max(nPixelR, 0);
                    nPixelR = Math.Min(255, nPixelR);

                    nPixelG = Math.Max(nPixelG, 0);
                    nPixelG = Math.Min(255, nPixelG);

                    nPixelB = Math.Max(nPixelB, 0);
                    nPixelB = Math.Min(255, nPixelB);

                    dd[0] = (byte)nPixelB;
                    dd[1] = (byte)nPixelG;
                    dd[2] = (byte)nPixelR;
                    PixelData[i * temp2.PixelWidth + j] = BitConverter.ToUInt32(dd, 0);

                }
            }
            temp2.WritePixels(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight), PixelData, 4 * temp2.PixelWidth, 0);
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
        }
        private byte[] CreateGammaArray(double color)
        {
            byte[] gammaArray = new byte[256];
            for (int i = 0; i < 256; ++i)
            {
                gammaArray[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));
            }
            return gammaArray;
        }
        public BitmapImage SetGamma(double red, double green, double blue, WriteableBitmap temp2)
        {
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();
            uint[] PixelData = new uint[temp2.PixelWidth * temp2.PixelHeight];
            temp2.CopyPixels(PixelData, 4 * temp2.PixelWidth, 0);
            byte[] redGamma = CreateGammaArray(red);
            byte[] greenGamma = CreateGammaArray(green);
            byte[] blueGamma = CreateGammaArray(blue);
            for (uint i = 0; i < temp2.PixelHeight; i++)
            {
                for (uint j = 0; j < temp2.PixelWidth; j++)
                {
                    uint pixel = PixelData[i * temp2.PixelWidth + j];
                    byte[] dd = BitConverter.GetBytes(pixel);
                    int B = (int)dd[0];
                    int G = (int)dd[1];
                    int R = (int)dd[2];

                    dd[0] = blueGamma[B];
                    dd[1] = greenGamma[G];
                    dd[2] = greenGamma[R];
                    PixelData[i * temp2.PixelWidth + j] = BitConverter.ToUInt32(dd, 0);

                }
            }
            temp2.WritePixels(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight), PixelData, 4 * temp2.PixelWidth, 0);
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
        }
        public BitmapImage SetGrayScale(WriteableBitmap temp2)
        {

            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();
            uint[] PixelData = new uint[temp2.PixelWidth * temp2.PixelHeight];
            temp2.CopyPixels(PixelData, 4 * temp2.PixelWidth, 0);
            for (uint i = 0; i < temp2.PixelHeight; i++)
            {
                for (uint j = 0; j < temp2.PixelWidth; j++)
                {
                    uint pixel = PixelData[i * temp2.PixelWidth + j];
                    byte[] dd = BitConverter.GetBytes(pixel);
                    int B = (int)dd[0];
                    int G = (int)dd[1];
                    int R = (int)dd[2];

                    byte gray = (byte)(.299 * R + .587 * G + .114 * B);


                    dd[0] = gray;
                    dd[1] = gray;
                    dd[2] = gray;
                    PixelData[i * temp2.PixelWidth + j] = BitConverter.ToUInt32(dd, 0);
                }
            }
            temp2.WritePixels(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight), PixelData, 4 * temp2.PixelWidth, 0);
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
        }
        public BitmapImage change(WriteableBitmap wb  , BitmapImage bi, Rotation type) {
            bi = new BitmapImage();
            using (MemoryStream stream = new MemoryStream())
            {
                PngBitmapEncoder encod = new PngBitmapEncoder();
                encod.Frames.Add(BitmapFrame.Create(wb));
                encod.Save(stream);
                bi.BeginInit();
                bi.CacheOption = BitmapCacheOption.OnLoad;
                bi.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
                bi.StreamSource = stream;
                bi.Rotation = type;
                bi.EndInit();
               
                bi.Freeze();
                

            }
            return bi;

        }
        public BitmapImage rotation(WriteableBitmap temp2, Rotation type) {
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap =  change(_currentWritableBitmap, _currentBitmap, type);
            return _currentBitmap;
        }
       
        public BitmapImage Resize(WriteableBitmap temp2, int h, int w)
        {
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();
            WriteableBitmap newwb;
            uint[] PixelData = new uint[temp2.PixelWidth * temp2.PixelHeight];
            temp2.CopyPixels(PixelData, 4 * temp2.PixelWidth, 0);

            int width = (int)temp2.PixelWidth;
            int height = (int)temp2.PixelHeight;

            double wfactor = (double)width / (double)w;
            double hfactor = (double)height / (double)h;
            uint p1, p2, p3, p4;

            byte b1, b2;

            double fx, fy, ox, oy;
            int cx, cy, flx, fly;
            //     int ns = w * ((temp2.Format.BitsPerPixel + 7) / 8);
            uint[] PixelData1 = new uint[w * h];

            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    flx = (int)Math.Floor(j * wfactor);
                    fly = (int)Math.Floor(i * hfactor);

                    cx = flx + 1;
                    if (cx >= width) cx = flx;

                    cy = fly + 1;
                    if (cy >= height) cy = fly;

                    fx = j * wfactor - flx;
                    fy = i * hfactor - fly;

                    ox = 1.0 - fx;
                    oy = 1.0 - fy;

                    p1 = PixelData[flx + fly * width];
                    p2 = PixelData[cx + fly * width];
                    p3 = PixelData[flx + cy * width];
                    p4 = PixelData[cx + cy * width];
                    byte[] aa = BitConverter.GetBytes(p1);
                    byte[] bb = BitConverter.GetBytes(p2);
                    byte[] cc = BitConverter.GetBytes(p3);
                    byte[] dd = BitConverter.GetBytes(p4);

                    int nPixelR = 0;
                    int nPixelG = 0;
                    int nPixelB = 0;

                    int Ba = (int)aa[0];
                    int Ga = (int)aa[1];
                    int Ra = (int)aa[2];

                    int Bb = (int)bb[0];
                    int Gb = (int)bb[1];
                    int Rb = (int)bb[2];

                    int Bc = (int)cc[0];
                    int Gc = (int)cc[1];
                    int Rc = (int)cc[2];

                    int Bd = (int)dd[0];
                    int Gd = (int)dd[1];
                    int Rd = (int)dd[2];

                    b1 = (byte)(ox * Ba + fx * Bb);
                    b2 = (byte)(ox * Bc + fx * Bd);
                    nPixelB = (int)(oy * (double)(b1) + fy * (double)(b2));

                    b1 = (byte)(ox * Ga + fx * Gb);
                    b2 = (byte)(ox * Gc + fx * Gd);
                    nPixelG = (int)(oy * (double)(b1) + fy * (double)(b2));

                    b1 = (byte)(ox * Ra + fx * Rb);
                    b2 = (byte)(ox * Rc + fx * Rd);
                    nPixelR = (int)(oy * (double)(b1) + fy * (double)(b2));

                    aa[0] = (byte)nPixelB; aa[1] = (byte)nPixelG; aa[2] = (byte)nPixelR;
                    bb[0] = (byte)nPixelB; bb[1] = (byte)nPixelG; bb[2] = (byte)nPixelR;
                    cc[0] = (byte)nPixelB; cc[1] = (byte)nPixelG; cc[2] = (byte)nPixelR;
                    dd[0] = (byte)nPixelB; dd[1] = (byte)nPixelG; dd[2] = (byte)nPixelR;
                    PixelData[i * w + j] = BitConverter.ToUInt32(aa, 0);
                    PixelData[i * w + j] = BitConverter.ToUInt32(bb, 0);
                    PixelData[i * w + j] = BitConverter.ToUInt32(cc, 0);
                    PixelData[i * w + j] = BitConverter.ToUInt32(dd, 0);
                }
            }
            newwb = new WriteableBitmap(w, h, 96, 96, PixelFormats.Bgr32, null);
            newwb.WritePixels(new Int32Rect(0, 0, w, h), PixelData, 4 * w, 0);
            _currentWritableBitmap = (WriteableBitmap)newwb.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
        }
        

        public BitmapImage insertImage(WriteableBitmap temp2, double x, double y)
        {
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();


            OpenFileDialog op = new OpenFileDialog();
            if (op.ShowDialog() == true)
            {
                _BitmapPath2 = op.FileName;
                _currentBitmap2 = new BitmapImage(new Uri(_BitmapPath2));
                _currentWritableBitmap2 = new WriteableBitmap(_currentBitmap2);
            }

            var visual = new DrawingVisual();
            using (var r = visual.RenderOpen())
            {
                r.DrawImage(temp2, new Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight));
                r.DrawImage(_currentWritableBitmap2, new Rect(x, y, _currentWritableBitmap2.PixelWidth / 2, _currentWritableBitmap2.PixelHeight / 2));

            }
            RenderTargetBitmap target = new RenderTargetBitmap(temp2.PixelWidth, temp2.PixelHeight,
                temp2.DpiX, temp2.DpiY, PixelFormats.Pbgra32);
            target.Render(visual);
            temp2.Lock();
            Int32Rect rc = new Int32Rect(0, 0, target.PixelWidth, target.PixelHeight);
            
            target.CopyPixels(rc,temp2.BackBuffer, temp2.BackBufferStride*temp2.PixelHeight, temp2.BackBufferStride);
            temp2.AddDirtyRect(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight));
            temp2.Unlock();
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
         


        }
        public BitmapImage resize(WriteableBitmap temp2, int width, int height ){ 
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();

            
            var visual = new DrawingVisual();
            using (var r = visual.RenderOpen())
            {
                r.DrawImage(temp2, new Rect(0,0,width, height));
            }
            RenderTargetBitmap target = new RenderTargetBitmap(temp2.PixelWidth, temp2.PixelHeight,
                temp2.DpiX, temp2.DpiY, PixelFormats.Pbgra32);
            target.Render(visual);
            temp2.Lock();
            Int32Rect rc = new Int32Rect(0, 0, target.PixelWidth, target.PixelHeight);

            target.CopyPixels(rc, temp2.BackBuffer, temp2.BackBufferStride * temp2.PixelHeight, temp2.BackBufferStride);
            temp2.AddDirtyRect(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight));
            temp2.Unlock();
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;

          
        }
        public BitmapImage crop(WriteableBitmap temp2, BitmapImage bi, int x, int y, int width, int height)
        {
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();


            var visual = new DrawingVisual();
            using (var r = visual.RenderOpen())
            {
                r.DrawImage(temp2, new Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight));
            }
            RenderTargetBitmap target = new RenderTargetBitmap(temp2.PixelWidth, temp2.PixelHeight,
                temp2.DpiX, temp2.DpiY, PixelFormats.Pbgra32);
            target.Render(visual);
            CroppedBitmap cp = new CroppedBitmap(target, new Int32Rect(x, y, width, height));
            WriteableBitmap wb = new WriteableBitmap(cp);
           
            _currentWritableBitmap = (WriteableBitmap)wb.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
           
        }
        public BitmapImage RestorePrevious()
        {
            _bitmapbeforeProcessing = _currentBitmap;
            return _bitmapbeforeProcessing;
        }
        public BitmapImage insertText(WriteableBitmap temp2, FormattedText ft, double x, double y)
        {
             
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();

            var visual = new DrawingVisual();

            using (var r = visual.RenderOpen())
            {
                
                r.DrawImage(temp2, new Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight));
                r.DrawText(ft, new Point(x, y));

            }
            
            RenderTargetBitmap target = new RenderTargetBitmap(_currentWritableBitmap.PixelWidth, _currentWritableBitmap.PixelHeight,
                _currentWritableBitmap.DpiX, _currentWritableBitmap.DpiY, PixelFormats.Pbgra32);
            target.Render(visual);
            temp2.Lock();
            Int32Rect rc = new Int32Rect(0, 0, target.PixelWidth, target.PixelHeight);

            target.CopyPixels(rc, temp2.BackBuffer, temp2.BackBufferStride * temp2.PixelHeight, temp2.BackBufferStride);
            temp2.AddDirtyRect(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight));
            temp2.Unlock();
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
        }
        public BitmapImage insertShape(WriteableBitmap temp2, ShapeType shapeType, Brush b, Brush b1, double thickness, double radiusx=0, double radiusy=0, Double px=0, double py=0 ,double rx=0, double ry=0, double rx1=0, double ry1 =0)
        {
            WriteableBitmap temp = (WriteableBitmap)_currentWritableBitmap;
            temp2 = (WriteableBitmap)temp.Clone();

            var visual = new DrawingVisual();
            
            using (var r = visual.RenderOpen())
            {
                
                r.DrawImage(temp2, new Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight));
                
                Pen pen = new Pen();
                switch (shapeType)
                {
                    case ShapeType.Ellipse:
                        
                        r.DrawEllipse(b, new Pen(b1, thickness), new Point(px, py), radiusx, radiusy);
                        break;
                    case ShapeType.Rectangle:
                        r.DrawRectangle(b, new Pen(b1, thickness), new Rect(rx, ry, rx1, ry1));
                        break;
                    case ShapeType.RoundedRectangle:
                        r.DrawRoundedRectangle(b, new Pen(b1, thickness), new Rect(rx, ry, rx1, ry1), radiusx, radiusy);
                        break;
                }
            }
            RenderTargetBitmap target = new RenderTargetBitmap(temp2.PixelWidth, temp2.PixelHeight,
                temp2.DpiX, temp2.DpiY, PixelFormats.Pbgra32);
            target.Render(visual);

            temp2.Lock();
            Int32Rect rc = new Int32Rect(0, 0, target.PixelWidth, target.PixelHeight);

            target.CopyPixels(rc, temp2.BackBuffer, temp2.BackBufferStride * temp2.PixelHeight, temp2.BackBufferStride);
            temp2.AddDirtyRect(new Int32Rect(0, 0, temp2.PixelWidth, temp2.PixelHeight));
            temp2.Unlock();
            _currentWritableBitmap = (WriteableBitmap)temp2.Clone();
            _currentBitmap = change(_currentWritableBitmap, _currentBitmap, Rotation.Rotate0);
            return _currentBitmap;
        }
        public enum ShapeType {
            Rectangle,
            Ellipse,
            RoundedRectangle
        }
       

    }
}
