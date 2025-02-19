using System;
using System.Runtime.InteropServices;

namespace WG_ResoMate
{
    public static class DisplayInfo
    {
        // Import necessary Windows API functions
        [DllImport("user32.dll")]
        private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        // Constants for EnumDisplaySettings
        private const int ENUM_CURRENT_SETTINGS = -1;

        // Structure to hold display settings
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
        private struct DEVMODE
        {
            private const int CCHDEVICENAME = 32;
            private const int CCHFORMNAME = 32;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName;
            public short dmSpecVersion;
            public short dmDriverVersion;
            public short dmSize;
            public short dmDriverExtra;
            public int dmFields;

            public int dmPositionX;
            public int dmPositionY;
            public int dmDisplayOrientation;
            public int dmDisplayFixedOutput;

            public short dmColor;
            public short dmDuplex;
            public short dmYResolution;
            public short dmTTOption;
            public short dmCollate;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName;

            public short dmLogPixels;
            public int dmBitsPerPel;
            public int dmPelsWidth;
            public int dmPelsHeight;
            public int dmDisplayFlags;
            public int dmDisplayFrequency;
            public int dmICMMethod;
            public int dmICMIntent;
            public int dmMediaType;
            public int dmDitherType;
            public int dmReserved1;
            public int dmReserved2;
            public int dmPanningWidth;
            public int dmPanningHeight;
        }

        /// <summary>
        /// Gets the native resolution of the primary monitor.
        /// </summary>
        public static string GetNativeResolution()
        {
            int maxWidth = 0;
            int maxHeight = 0;

            DEVMODE devMode = new DEVMODE();
            devMode.dmSize = (short)Marshal.SizeOf(devMode);

            // Iterate through all display modes
            for (int modeNum = 0; EnumDisplaySettings(null, modeNum, ref devMode); modeNum++)
            {
                if (devMode.dmPelsWidth > maxWidth || devMode.dmPelsHeight > maxHeight)
                {
                    maxWidth = devMode.dmPelsWidth;
                    maxHeight = devMode.dmPelsHeight;
                }
            }

            return $"{maxWidth}x{maxHeight}";
        }

        /// <summary>
        /// Gets the current resolution of the primary monitor.
        /// </summary>
        public static string GetCurrentResolution()
        {
            DEVMODE devMode = new DEVMODE();
            devMode.dmSize = (short)Marshal.SizeOf(devMode);

            if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref devMode))
            {
                int width = devMode.dmPelsWidth;
                int height = devMode.dmPelsHeight;

                return $"{width}x{height}";
            }

            return "Unknown";
        }
    }
}