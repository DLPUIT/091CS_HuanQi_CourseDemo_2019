using System;
using System.Windows.Forms;

namespace MyBrowser
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // script error c# winform hide
            // https://stackoverflow.com/questions/2476360/disable-javascript-error-in-webbrowser-control
            this.webBrowser.ScriptErrorsSuppressed = true;
        }

        private void LoadPage()
        {
            var url = new Uri(this.textBoxUrl.Text);
            this.webBrowser.Url = url;
            this.webBrowser.Refresh();
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            this.LoadPage();
        }

        private void textBoxUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.LoadPage();
            }
        }

        private void webBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            this.textBoxUrl.Text = this.webBrowser.Url?.AbsoluteUri;
        }
    }
}