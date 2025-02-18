using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WG_ResoMate
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
            LoadAssemblyInformation();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadAssemblyInformation()
        {
            // Retrieve assembly information
            var assembly = Assembly.GetExecutingAssembly();
            var assemblyName = assembly.GetName();

            string title = AssemblyTitleAttribute();
            string description = AssemblyDescriptionAttribute();
            string company = AssemblyCompanyAttribute();
            string product = AssemblyProductAttribute();
            string copyright = AssemblyCopyrightAttribute();
            Version version = assemblyName.Version;

            // Assign values to labels
            headerFormAbout.Text = title;
            labelAbout.Text = $@"Thank you for downloading {product}. I make this application for testing and to serve my own needs.
This software means to do simple thing, which is:
""{description}"".";

            labelCompany.Text = $"Company: {company}";
            //labelProduct.Text = $"Product: {product}";
            labelCopyright.Text = $"Copyright: {copyright}";
            labelVersion.Text = $"Version: {version}";
        }

        private string AssemblyTitleAttribute()
        {
            var attribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyTitleAttribute), false)
                .OfType<AssemblyTitleAttribute>()
                .FirstOrDefault();
            return attribute?.Title ?? "No title available.";
        }

        private string AssemblyDescriptionAttribute()
        {
            var attribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false)
                .OfType<AssemblyDescriptionAttribute>()
                .FirstOrDefault();
            return attribute?.Description ?? "No description available.";
        }

        private string AssemblyCompanyAttribute()
        {
            var attribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyCompanyAttribute), false)
                .OfType<AssemblyCompanyAttribute>()
                .FirstOrDefault();
            return attribute?.Company ?? "No company available.";
        }

        private string AssemblyProductAttribute()
        {
            var attribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyProductAttribute), false)
                .OfType<AssemblyProductAttribute>()
                .FirstOrDefault();
            return attribute?.Product ?? "No product available.";
        }

        private string AssemblyCopyrightAttribute()
        {
            var attribute = Assembly.GetExecutingAssembly()
                .GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false)
                .OfType<AssemblyCopyrightAttribute>()
                .FirstOrDefault();
            return attribute?.Copyright ?? "No copyright information available.";
        }
    }

}
