using System;
using System.Collections.Generic;
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

    }
}
