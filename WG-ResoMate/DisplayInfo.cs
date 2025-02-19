using System;
using System.Runtime.InteropServices;

namespace WG_ResoMate
{
    public static class DisplayInfo
    {
        // Import necessary Windows API functions
        [DllImport("user32.dll")]
        private static extern bool EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        [DllImport("Shcore.dll", SetLastError = true)]
        private static extern int GetScaleFactorForMonitor(IntPtr hmonitor, out uint scaleFactor);

        [DllImport("Shcore.dll", SetLastError = true)]
        private static extern int GetDpiForMonitor(IntPtr hmonitor, MONITOR_DPI_TYPE dpiType, out uint dpiX, out uint dpiY);

        [DllImport("user32.dll")]
        private static extern IntPtr MonitorFromWindow(IntPtr hwnd, uint dwFlags);

        // Constants for EnumDisplaySettings
        private const int ENUM_CURRENT_SETTINGS = -1;
        private const int ENUM_REGISTRY_SETTINGS = -2;

        // Constants for MonitorFromWindow
        private const uint MONITOR_DEFAULTTOPRIMARY = 0x00000001;

        // Enum for DPI type
        private enum MONITOR_DPI_TYPE
        {
            MDT_Effective_DPI = 0,
            MDT_Angular_DPI = 1,
            MDT_Raw_DPI = 2,
            MDT_Default = MDT_Effective_DPI
        }

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
        /// Gets the current resolution and scaling factor of the primary monitor.
        /// </summary>
        public static (string resolution, double scaling) GetCurrentResolutionAndScaling()
        {
            DEVMODE devMode = new DEVMODE();
            devMode.dmSize = (short)Marshal.SizeOf(devMode);

            if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref devMode))
            {
                int width = devMode.dmPelsWidth;
                int height = devMode.dmPelsHeight;

                // Calculate scaling percentage using GetPrimaryMonitorScaling
                double scaling = GetPrimaryMonitorScaling();

                return ($"{width}x{height}", scaling);
            }

            return ("Unknown", 100.0);
        }

        /// <summary>
        /// Gets the scaling percentage for the primary monitor.
        /// </summary>
        public static double GetPrimaryMonitorScaling()
        {
            IntPtr monitor = MonitorFromWindow(IntPtr.Zero, MONITOR_DEFAULTTOPRIMARY);
            if (monitor != IntPtr.Zero)
            {
                // Try using GetScaleFactorForMonitor first
                int result = GetScaleFactorForMonitor(monitor, out uint scaleFactor);
                if (result == 0) // Success
                {
                    return scaleFactor; // Return the scaling factor directly (e.g., 100, 125, 150)
                }

                // Fallback to DPI-based calculation
                if (GetDpiForMonitor(monitor, MONITOR_DPI_TYPE.MDT_Default, out uint dpiX, out uint _) == 0)
                {
                    double scaling = Math.Round((dpiX / 96.0) * 100, 2); // Base DPI is 96
                    return scaling;
                }
            }

            return 100.0; // Default scaling if unable to retrieve scale factor
        }
    }
}