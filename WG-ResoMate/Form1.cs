using System;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

// Copyright Notice
// Copyright (c) 2025 Pangeran Wiguan. All rights reserved.
// WG-ResoMate: A tool to toggle between screen resolutions.

namespace WG_ResoMate
{
    public partial class Form1 : Form
    {
        // Import necessary Windows API functions for changing display settings
        [DllImport("user32.dll")]
        private static extern int EnumDisplaySettings(string deviceName, int modeNum, ref DEVMODE devMode);

        [DllImport("user32.dll")]
        private static extern int ChangeDisplaySettings(ref DEVMODE devMode, int flags);

        // Constants for display settings
        private const int ENUM_CURRENT_SETTINGS = -1; // Retrieves the current display settings
        private const int CDS_UPDATEREGISTRY = 0x01;  // Updates the registry with new settings
        private const int DISP_CHANGE_SUCCESSFUL = 0; // Indicates success when changing display settings

        // Struct representing the device mode (resolution, frequency, etc.)
        [StructLayout(LayoutKind.Sequential)]
        private struct DEVMODE
        {
            private const int CCHDEVICENAME = 32;
            private const int CCHFORMNAME = 32;

            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHDEVICENAME)]
            public string dmDeviceName; // Device name
            public short dmSpecVersion; // Version number
            public short dmDriverVersion; // Driver version
            public short dmSize; // Size of the DEVMODE structure
            public short dmDriverExtra; // Extra driver data
            public int dmFields; // Flags indicating which fields are valid
            public int dmPositionX; // X position of the monitor
            public int dmPositionY; // Y position of the monitor
            public int dmDisplayOrientation; // Display orientation
            public int dmDisplayFixedOutput; // Fixed output type
            public short dmColor; // Color resolution
            public short dmDuplex; // Duplex mode
            public short dmYResolution; // Vertical resolution
            public short dmTTOption; // TrueType options
            public short dmCollate; // Collation
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = CCHFORMNAME)]
            public string dmFormName; // Form name
            public short dmLogPixels; // Logical pixels (DPI)
            public int dmBitsPerPel; // Bits per pixel (color depth)
            public int dmPelsWidth; // Screen width in pixels
            public int dmPelsHeight; // Screen height in pixels
            public int dmDisplayFlags; // Display flags
            public int dmDisplayFrequency; // Refresh rate
            public int dmICMMethod; // ICM method
            public int dmICMIntent; // ICM intent
            public int dmMediaType; // Media type
            public int dmDitherType; // Dither type
            public int dmReserved1; // Reserved field
            public int dmReserved2; // Reserved field
            public int dmPanningWidth; // Panning width
            public int dmPanningHeight; // Panning height
        }

        // Constructor for the form
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Changes the screen resolution using the Windows API.
        /// Part of WG-ResoMate: A tool to toggle between screen resolutions.
        /// </summary>
        /// <param name="width">The desired screen width in pixels.</param>
        /// <param name="height">The desired screen height in pixels.</param>
        /// @since 2025-02-18
        private void ChangeResolution(int width, int height)
        {
            DEVMODE dm = new DEVMODE(); // Create a new DEVMODE structure
            dm.dmSize = (short)Marshal.SizeOf(typeof(DEVMODE)); // Set the size of the structure

            // Retrieve the current display settings
            if (EnumDisplaySettings(null, ENUM_CURRENT_SETTINGS, ref dm) != 0)
            {
                dm.dmPelsWidth = width; // Set the desired width
                dm.dmPelsHeight = height; // Set the desired height

                // Apply the new display settings
                int result = ChangeDisplaySettings(ref dm, CDS_UPDATEREGISTRY);
                if (result == DISP_CHANGE_SUCCESSFUL)
                {
                    MessageBox.Show("Resolution changed successfully.");
                }
                else
                {
                    MessageBox.Show("Failed to change resolution.");
                }
            }
        }

        /// <summary>
        /// Event handler for the "Set 1920x1080" button.
        /// Part of WG-ResoMate: A tool to toggle between screen resolutions.
        /// </summary>
        /// @since 2025-02-18
        private void btn1080p_Click(object sender, EventArgs e)
        {
            ChangeResolution(1920, 1080); // Change resolution to 1920x1080
        }

        /// <summary>
        /// Event handler for the "Set 4K" button.
        /// Part of WG-ResoMate: A tool to toggle between screen resolutions.
        /// </summary>
        /// @since 2025-02-18
        private void btn4K_Click(object sender, EventArgs e)
        {
            ChangeResolution(3840, 2160); // Change resolution to 3840x2160 (4K)
        }

        private void footer_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Dynamically set the footer text
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            labelFooter.Text = $"Version {version} - © {DateTime.Now.Year} Pangeran Wiguan. All Rights Reserved";
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            // Create an instance of the AboutForm
            AboutForm aboutForm = new AboutForm();

            // Show the AboutForm as a dialog
            aboutForm.ShowDialog();
        }
    }
}