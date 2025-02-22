using System;
using System.Drawing;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Microsoft.Toolkit.Uwp.Notifications;
using System.Linq;

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
            this.KeyDown += Form1_KeyDown; // Link the KeyDown event
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
            // Toogle Auto Close Styling
            StyleToggleSwitch(ToggleAutoClose);

            // Dynamically set the footer text
            string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            labelFooter.Text = $"Version {version} - © {DateTime.Now.Year} Pangeran Wiguan. All Rights Reserved";

            // Tool Tip for Menu Strip Item
            ToolStripMenuItemAbout.ToolTipText = "About WG-ResoMate";
            
            // Tool Tip for label.
            toolTip.SetToolTip(ButtonChangeRes, "Click this button to change your display resolution immediately. Shortcut: Ctrl + C");
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

            // Load the saved auto-close preference
            ToggleAutoClose.Checked = Properties.Settings.Default.AutoCloseOnResolutionChange;

            // Enable key preview to capture global key events
            this.KeyPreview = true;

        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Check if Ctrl + R is pressed
            if (e.Control && e.KeyCode == Keys.C)
            {
                // Trigger the resolution change button click event
                ButtonChangeRes_Click(sender, e);
            }
        }

        /// <summary>
        /// Updates the dynamic button text based on the current resolution.
        /// </summary>
        private void UpdateButton(string currentResolution)
        {
            if (currentResolution == "1920x1080")
            {
                ButtonChangeRes.Text = "Set to 4K Resolution\n(3840x2160 pixels)\nShortcut : Ctrl + C";
                ButtonChangeRes.Tag = "4K"; // Store target resolution in Tag
            }
            else if (currentResolution == "3840x2160")
            {
                ButtonChangeRes.Text = "Set to 1080p Resolution\n(1920x1080 pixels)\nShortcut : Ctrl + C";
                ButtonChangeRes.Tag = "1080p";
            }
            else
            {
                // Default value. After setting to 1080p even from 2K res, it will have the option to change to 4K.
                ButtonChangeRes.Text = "Set to 1080p Resolution\n(1920x1080 pixels)\nShortcut : Ctrl + C";
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
                    ShowToastNotification("Success", "Resolution changed successfully.");
                }
                else
                {
                    ShowToastNotification("Error", "Failed to change resolution.");
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
                ShowToastNotification("Success", "Resolution set to 1080p.");
                UpdateButton("1920x1080"); // Simulate resolution change to 1080p
            }
            else if (targetResolution == "4K")
            {
                ChangeResolution(3840, 2160); // Change resolution to 3840x2160 (4K)
                ShowToastNotification("Success", "Resolution set to 4K.");
                UpdateButton("3840x2160"); // Simulate resolution change to 4K
            }

            // Update the current resolution label
            var currentResolution = DisplayInfo.GetCurrentResolution();
            LabelDisplayResolution.Text = $"Current Resolution: {currentResolution}";

            // Check if auto-close is enabled
            if (Properties.Settings.Default.AutoCloseOnResolutionChange)
            {
                this.Close(); // Close the application
            }
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
                ShowToastNotification("Dark Mode", "WG-ResoMate switched to Dark Mode.");
            }
            else
            {
                ThemeManager.ApplyLightMode(this); // Apply to the entire form
                ToggleTheme.Text = "Switch to Dark Mode";
                ShowToastNotification("Light Mode", "WG-ResoMate switched to Light Mode.");
            }

            // Save the preference
            Properties.Settings.Default.IsDarkMode = isDarkMode;
            Properties.Settings.Default.Save();

        }

        // Show Notification at Windows Notification.
        // Less distrubtion that Show Message Box.
        private void ShowToastNotification(string title, string message)
        {
            new ToastContentBuilder()
                .AddText(title) // Title of the notification
                .AddText(message) // Message body (limited to 2 lines)
                .Show(); // Display the notification
        }

        // Styling the check box for Toogle Auto Close
        // Make it look like Toggle Switch
        private void StyleToggleSwitch(CheckBox toggle)
        {
            toggle.Appearance = Appearance.Button; // Make it look like a button
            toggle.BackColor = toggle.Checked ? Color.Green : Color.Gray; // Change color based on state
            toggle.TextAlign = ContentAlignment.MiddleCenter; // Center the text
            toggle.FlatStyle = FlatStyle.Flat; // Flat style for a cleaner look
            toggle.FlatAppearance.BorderSize = 0; // Remove border
            
            // Update the label text and font color based on the toggle state
            toggle.Text = toggle.Checked ? "Auto Close App Enabled" : "Auto Close App Disabled";
            toggle.ForeColor = toggle.Checked ? Color.Black : Color.White; // Set font color dynamically

            // Update the tooltip text based on the toggle state
            string toolTipText = toggle.Checked
                ? "Auto Close Enabled: The application will close automatically after changing the resolution."
                : "Auto Close Disabled: The application will remain open after changing the resolution.";
            toolTip.SetToolTip(toggle, toolTipText);
        }

        private void ToggleAutoClose_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.AutoCloseOnResolutionChange = ToggleAutoClose.Checked;
            Properties.Settings.Default.Save();

            // Update the appearance
            StyleToggleSwitch(ToggleAutoClose);
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