namespace MyNotepad
{
    #region using directives

    using System;
    using System.IO;
    using System.Text;
    using System.Windows.Forms;

    #endregion

    public partial class MainForm : Form
    {
        private static readonly string productName = "神马™记事本";
        public MainForm()
        {
            this.InitializeComponent();
            this.Text = productName;
            this.openFileDialog.Filter = @"文本文件(*.txt)|*.txt|所有文件(*.*)|*.*";
        }

        private string currentOpenFilePath;

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.openFileDialog.ShowDialog();
            this.currentOpenFilePath = this.openFileDialog.FileName;

            using (var stream = new StreamReader(this.currentOpenFilePath, Encoding.Default))
            {
                this.textBox.Text = stream.ReadToEnd();
            }

            this.Text = $"{productName} - {this.openFileDialog.SafeFileName}";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(this.currentOpenFilePath))
            {
                // 新建文件的逻辑，应该放在这里
                return;
            }

            using (var stream = new StreamWriter(this.currentOpenFilePath, false))
            {
                stream.Write(this.textBox.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}