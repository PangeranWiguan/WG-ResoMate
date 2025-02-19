using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WG_ResoMate
{
    public partial class Form1 : Form
    {
        // Import necessary Windows API constants
        private const int WM_DISPLAYCHANGE = 0x007E;

        private bool isDarkMode = false; // Track the current theme state
        // Use the fully qualified name to avoid ambiguity
        private readonly System.Windows.Forms.ToolTip toolTip = new System.Windows.Forms.ToolTip();

        // Constructor for the form
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Overrides the WndProc method to handle system messages.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DISPLAYCHANGE)
            {
                // Refresh display information when the display settings change
                RefreshDisplayInfo();
            }

            base.WndProc(ref m);
        }

        /// <summary>
        /// Refreshes the display information and updates the UI.
        /// </summary>
        private void RefreshDisplayInfo()
        {
            // Update native resolution
            string nativeResolution = DisplayInfo.GetNativeResolution();
            LabelNativeResolution.Text = $"Native Resolution: {nativeResolution}";

            // Update current resolution
            string currentResolution = DisplayInfo.GetCurrentResolution();
            LabelDisplayResolution.Text = $"Current Resolution: {currentResolution}";

            // Update the dynamic button
            UpdateButton(currentResolution);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Dynamically set the footer text
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            labelFooter.Text = $"Version {version} - © {DateTime.Now.Year} Pangeran Wiguan. All Rights Reserved";

            // Tool Tip for Menu Strip Item
            ToolStripMenuItemAbout.ToolTipText = "About WG-ResoMate";
            
            // Tool Tip for label.
            toolTip.SetToolTip(ButtonChangeRes, "Click this button to change your display resolution immediately.");
            toolTip.SetToolTip(LabelNativeResolution, "Shows your display native resolution. The value can be different from your set display resolution and it is fine.");
            toolTip.SetToolTip(LabelDisplayResolution, "This is what your current display resolution set to.");
            toolTip.SetToolTip(labelFooter, $"Version {version} - © {DateTime.Now.Year} Pangeran Wiguan. All Rights Reserved");

            // Load the saved theme preference
            isDarkMode = Properties.Settings.Default.IsDarkMode;

            // Apply the saved theme
            if (isDarkMode)
            {
                ThemeManager.ApplyDarkMode(this); // Apply to the entire form
                ToggleTheme.Text = "Switch to Light Mode";
                ToggleTheme.ToolTipText = "Switch to Light Mode";
            }
            else
            {
                ThemeManager.ApplyLightMode(this); // Apply to the entire form
                ToggleTheme.Text = "Switch to Dark Mode";
                ToggleTheme.ToolTipText = "Switch to Dark Mode";
            }

            // Initialize display information on form load
            RefreshDisplayInfo();

            
        }

        /// <summary>
        /// Updates the dynamic button text based on the current resolution.
        /// </summary>
        private void UpdateButton(string currentResolution)
        {
            if (currentResolution == "1920x1080")
            {
                ButtonChangeRes.Text = "Set to 4K Resolution\n(3840x2160 pixels)";
                ButtonChangeRes.Tag = "4K"; // Store target resolution in Tag
            }
            else if (currentResolution == "3840x2160")
            {
                ButtonChangeRes.Text = "Set to 1080p Resolution\n(1920x1080 pixels)";
                ButtonChangeRes.Tag = "1080p";
            }
            else
            {
                // Default value. After setting to 1080p even from 2K res, it will have the option to change to 4K.
                ButtonChangeRes.Text = "Set to 1080p Resolution\n(1920x1080 pixels)";
                ButtonChangeRes.Tag = "1080p";
            }
        }

        /// <summary>
        /// Changes the screen resolution using the Windows API.
        /// </summary>
        private void ChangeResolution(int width, int height)
        {
            DEVMODE dm = new DEVMODE
            {
                dmSize = (short)Marshal.SizeOf(typeof(DEVMODE)) // Set the size of the structure
            };

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
        /// Event handler for the dynamic resolution change button.
        /// </summary>
        private void ButtonChangeRes_Click(object sender, EventArgs e)
        {
            string targetResolution = ButtonChangeRes.Tag.ToString();

            if (targetResolution == "1080p")
            {
                ChangeResolution(1920, 1080); // Change resolution to 1920x1080
                MessageBox.Show("Resolution set to 1080p.");
                UpdateButton("1920x1080"); // Simulate resolution change to 1080p
            }
            else if (targetResolution == "4K")
            {
                ChangeResolution(3840, 2160); // Change resolution to 3840x2160 (4K)
                MessageBox.Show("Resolution set to 4K.");
                UpdateButton("3840x2160"); // Simulate resolution change to 4K
            }

            // Update the current resolution label
            var currentResolution = DisplayInfo.GetCurrentResolution();
            LabelDisplayResolution.Text = $"Current Resolution: {currentResolution}";
        }

        /// <summary>
        /// Event handler for the "About" menu item.
        /// </summary>
        private void ToolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            // Create an instance of the AboutForm
            AboutForm aboutForm = new AboutForm();

            // Show the AboutForm as a dialog
            aboutForm.ShowDialog();
        }

        /// <summary>
        /// Event handler for toggling the theme.
        /// </summary>
        private void ToggleTheme_Click(object sender, EventArgs e)
        {
            // Toggle the theme state
            isDarkMode = !isDarkMode;

            if (isDarkMode)
            {
                ThemeManager.ApplyDarkMode(this); // Apply to the entire form
                ToggleTheme.Text = "Switch to Light Mode";
            }
            else
            {
                ThemeManager.ApplyLightMode(this); // Apply to the entire form
                ToggleTheme.Text = "Switch to Dark Mode";
            }

            // Save the preference
            Properties.Settings.Default.IsDarkMode = isDarkMode;
            Properties.Settings.Default.Save();
        }

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
    }
}