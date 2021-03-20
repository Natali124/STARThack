using System.Collections;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
public class Test
{

    [DllImport("user32.dll")]
    public static extern IntPtr GetDC(IntPtr hWnd);

    [DllImport("gdi32.dll")]
    public static extern bool SetDeviceGammaRamp(IntPtr hDC, ref RAMP lpRamp);

    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct RAMP
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public UInt16[] Red;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public UInt16[] Green;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public UInt16[] Blue;
    }

    public static void SetGamma(int gammar, int  gammag, int gammab)
    {
        if (gammar <= 256 && gammar >= 1)
        {
            RAMP ramp = new RAMP();
            ramp.Red = new ushort[256];
            ramp.Green = new ushort[256];
            ramp.Blue = new ushort[256];
            for (int i = 1; i < 256; i++)
            {
                int iArrayValue = i * (gammar + 128);

                if (iArrayValue > 65535)
                    iArrayValue = 65535;
                ramp.Red[i] = (ushort)iArrayValue;
            }

            for (int i = 1; i < 256; i++)
            {
                int iArrayValue = i * (gammag + 128);

                if (iArrayValue > 65535)
                    iArrayValue = 65535;
                ramp.Green[i] = (ushort)iArrayValue;
            }

            for (int i = 1; i < 256; i++)
            {
                int iArrayValue = i * (gammab + 128);

                if (iArrayValue > 65535)
                    iArrayValue = 65535;
                ramp.Blue[i] = (ushort)iArrayValue;
            }
            SetDeviceGammaRamp(GetDC(IntPtr.Zero), ref ramp);
        }
    }

    public static void Main(string[] args)
    {
  //      string ent = "";
        int g = 0;
        int b = 0;
        int r = 0;
//        Console.WriteLine(args[0]);
        
        try
        {
            r = Convert.ToInt32(args[0]);
            g = Convert.ToInt32(args[1]);
            b = Convert.ToInt32(args[2]);
        } catch
        {
            Console.WriteLine("Argument");
            return;
        }

        
        

        //while (ent != "EXIT")
        //{
//        Console.WriteLine("Enter new Gamma (or 'EXIT' to quit):");
//            //ent = Console.ReadLine();
//            g = Convert.ToInt32(Console.ReadLine());
//            r = Convert.ToInt32(Console.ReadLine());
//            b = Convert.ToInt32(Console.ReadLine());
            //try
            //{
            //    g = int.Parse(ent);

           SetGamma(g,b,r);
//        while (ent != "EXIT") {
//            ent = Console.ReadLine();
//        }
        //}
    }
}