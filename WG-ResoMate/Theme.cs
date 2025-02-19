using System;
using System.Drawing;
using System.Windows.Forms;

namespace WG_ResoMate
{
    public static class ThemeManager
    {
        /// <summary>
        /// Applies Dark Mode styling to the specified form.
        /// </summary>
        /// <param name="form">The form to apply Dark Mode to.</param>
        public static void ApplyDarkMode(Form form)
        {
            // Set form background and foreground colors
            form.BackColor = Color.FromArgb(32, 32, 32); // Dark gray background
            form.ForeColor = Color.White;               // White text

            // Apply dark mode to all controls
            foreach (Control control in form.Controls)
            {
                ApplyDarkModeToControl(control);
            }

            // Update menu strip appearance
            if (form.MainMenuStrip != null)
            {
                form.MainMenuStrip.BackColor = Color.FromArgb(48, 48, 48); // Darker gray for menu strip
                form.MainMenuStrip.ForeColor = Color.White;               // White text for menu strip

                // Apply dark mode to menu items
                foreach (ToolStripItem menuItem in form.MainMenuStrip.Items)
                {
                    ApplyDarkModeToMenuItem(menuItem);
                }
            }
        }

        /// <summary>
        /// Applies Light Mode styling to the specified form.
        /// </summary>
        /// <param name="form">The form to apply Light Mode to.</param>
        public static void ApplyLightMode(Form form)
        {
            // Reset to default light mode styles
            form.BackColor = SystemColors.Control;
            form.ForeColor = SystemColors.ControlText;

            // Apply light mode to all controls
            foreach (Control control in form.Controls)
            {
                ApplyLightModeToControl(control);
            }

            // Update menu strip appearance
            if (form.MainMenuStrip != null)
            {
                form.MainMenuStrip.BackColor = SystemColors.Control; // Default light mode color
                form.MainMenuStrip.ForeColor = SystemColors.ControlText; // Default light mode text

                // Apply light mode to menu items
                foreach (ToolStripItem menuItem in form.MainMenuStrip.Items)
                {
                    ApplyLightModeToMenuItem(menuItem);
                }
            }
        }

        private static void ApplyDarkModeToControl(Control control)
        {
            if (control is Button button)
            {
                button.FlatStyle = FlatStyle.Flat;
                button.BackColor = Color.FromArgb(64, 64, 64); // Darker gray for buttons
                button.ForeColor = Color.White;               // White text
                button.FlatAppearance.BorderColor = Color.FromArgb(96, 96, 96); // Border color
            }
            else if (control is Label label)
            {
                label.ForeColor = Color.White; // White text for labels
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = Color.FromArgb(64, 64, 64); // Darker gray for textboxes
                textBox.ForeColor = Color.White;               // White text
            }

            // Recursively apply to child controls (e.g., Panels, GroupBoxes)
            foreach (Control childControl in control.Controls)
            {
                ApplyDarkModeToControl(childControl);
            }
        }

        private static void ApplyLightModeToControl(Control control)
        {
            if (control is Button button)
            {
                button.FlatStyle = FlatStyle.Standard;
                button.BackColor = SystemColors.Control;
                button.ForeColor = SystemColors.ControlText;
            }
            else if (control is Label label)
            {
                label.ForeColor = SystemColors.ControlText;
            }
            else if (control is TextBox textBox)
            {
                textBox.BackColor = SystemColors.Window;
                textBox.ForeColor = SystemColors.WindowText;
            }

            // Recursively apply to child controls (e.g., Panels, GroupBoxes)
            foreach (Control childControl in control.Controls)
            {
                ApplyLightModeToControl(childControl);
            }
        }

        private static void ApplyDarkModeToMenuItem(ToolStripItem menuItem)
        {
            menuItem.BackColor = Color.FromArgb(48, 48, 48); // Darker gray for menu items
            menuItem.ForeColor = Color.White;               // White text for menu items
        }

        private static void ApplyLightModeToMenuItem(ToolStripItem menuItem)
        {
            menuItem.BackColor = SystemColors.Control;      // Default light mode color
            menuItem.ForeColor = SystemColors.ControlText;  // Default light mode text
        }
    }
}