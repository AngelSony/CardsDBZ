using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CardsDBZ
{
    public static class Fonts
    {
        public static PrivateFontCollection pfc;
        public static void LoadFonts()
        {
            pfc = new PrivateFontCollection();
            Assembly assembly = Assembly.GetExecutingAssembly();

            Stream fontStream = assembly.GetManifestResourceStream("CartasDBZ.Resources.BITSUMIS.TTF");

            if (fontStream == null)
            {
                throw new ArgumentException($"Resource 'BITSUMIS.TTF' not found.");
            }

            byte[] fontData = new byte[fontStream.Length];
            fontStream.Read(fontData, 0, (int)fontStream.Length);
            fontStream.Close();

            IntPtr fontPtr = Marshal.AllocCoTaskMem(fontData.Length);
            Marshal.Copy(fontData, 0, fontPtr, fontData.Length);

            pfc.AddMemoryFont(fontPtr, fontData.Length);

            Marshal.FreeCoTaskMem(fontPtr);
            Console.WriteLine("Fuente cargada");
        }
    }
    class ImageMaker
    {
        public static Image GetImage(Card card)
        {
            Image img = new Bitmap(700, 1050);
            if (card.IDCard != 0)
            {
                Graphics drawing = Graphics.FromImage(img);
                drawing.DrawImage((Image)Properties.Resources.ResourceManager.GetObject("CardFront"), 0, 0);

                Title(drawing, card);
                Description(drawing, card);
                AtkDefPoints(drawing, card);
                DragonBalls(drawing, card);
                MainImage(drawing, card);
                drawing.Dispose();
            }
            else
            {
                img = (Image)Properties.Resources.ResourceManager.GetObject("CardReverse");
            }
            return img;
        }
        public static void MainImage(Graphics drawing, Card card)
        {
            Image image = (Image)Properties.Resources.ResourceManager.GetObject("_" + card.IDCard.ToString());
            drawing.DrawImage(image, 44, 144);
        }
        public static void AtkDefPoints(Graphics drawing, Card card)
        {
            //Font font = new Font(Fonts.pfc.Families[0], 80, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Gray);
            StringFormat format = new StringFormat();
            format.LineAlignment = StringAlignment.Center;
            format.Alignment = StringAlignment.Near;
            //drawing.DrawString(card.DefPoints.ToString(), font, brush, 60, 820, format);

            GraphicsPath path = new GraphicsPath();
            Pen pen = new Pen(Color.Black, 3);
            path.AddString(card.DefPoints.ToString(), Fonts.pfc.Families[0], (int)FontStyle.Bold, 80, new Point(60, 830), format);
            format.Alignment = StringAlignment.Far;
            path.AddString(card.AtkPoints.ToString(), Fonts.pfc.Families[0], (int)FontStyle.Bold, 80, new Point(640, 830), format);
            drawing.FillPath(brush, path);
            drawing.DrawPath(pen, path);
        }
        public static void Title(Graphics drawing, Card card)
        {
            Font font = new Font(Fonts.pfc.Families[0], 40, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            RectangleF bounds = new RectangleF(55, 40, 590, 72);
            SizeF size = drawing.MeasureString(card.Title, font);
            if (size.Width > 560 && size.Width <= 590)
            {
                font = new Font(Fonts.pfc.Families[0], 37, FontStyle.Bold);
            }
            else if (size.Width > 590)
            {
                font = new Font(Fonts.pfc.Families[0], 33, FontStyle.Bold);
            }
            drawing.DrawString(card.Title, font, brush, bounds, format);
        }
        public static void Description(Graphics drawing, Card card)
        {
            Font font = new Font("Arial Narrow", 20, FontStyle.Bold);
            SolidBrush brush = new SolidBrush(Color.Black);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            RectangleF bounds = new RectangleF(55, 880, 590, 130);
            drawing.DrawString(card.Description.ToUpper(), font, brush, bounds, format);
        }
        public static void DragonBalls(Graphics drawing, Card card)
        {
            Image ballImage = (Image)Properties.Resources.ResourceManager.GetObject("_" + card.DragonBalls[0].ToString() + "_Ball");
            Rectangle bounds = new Rectangle(307, 798, 86, 86);
            drawing.DrawImage(ballImage, bounds);
        }
    }
}
