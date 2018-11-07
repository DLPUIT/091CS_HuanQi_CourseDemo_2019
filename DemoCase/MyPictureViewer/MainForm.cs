namespace MyPictureViewer
{
    #region using directives

    using System;
    using System.Windows.Forms;

    #endregion using directives

    public partial class MainForm : Form
    {
        private static readonly string productName = "奇葩™图片浏览器";
        private string currentOpenFilePath;

        public MainForm()
        {
            this.InitializeComponent();
            this.Text = productName;
            this.openFileDialog.Filter = @"图片文件 (*.jpg, *.jpeg, *.jpe, *.jfif, *.png) | *.jpg; *.jpeg; *.jpe; *.jfif; *.png";
        }

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
            this.currentOpenFilePath = this.openFileDialog.FileName;

            this.pictureBox.ImageLocation = this.currentOpenFilePath;

            this.Text = $"{productName} - {this.openFileDialog.SafeFileName}";
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}