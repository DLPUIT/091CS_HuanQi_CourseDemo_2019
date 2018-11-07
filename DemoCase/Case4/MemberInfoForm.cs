namespace Case4
{
    using System;

    #region using directives

    using System.Windows.Forms;
    using DlpuManager.Service;

    #endregion using directives

    public partial class MemberInfoForm : Form
    {
        private readonly DlpuManagerService service = new DlpuManagerService();
        private readonly User user;
        private readonly EditMode mode;

        public MemberInfoForm(User user, EditMode mode)
        {
            this.InitializeComponent();
            this.user = user ?? new User();
            this.mode = mode;
            this.InitializeData();
        }

        private void InitializeData()
        {
            if (this.mode == EditMode.View)
            {
                this.textBoxName.ReadOnly = true;
                this.textBoxClassId.ReadOnly = true;
                this.textBoxCredit.ReadOnly = true;
                this.textBoxGitHub.ReadOnly = true;
            }
            this.textBoxName.Text = this.user.Name;
            this.textBoxClassId.Text = this.user.ClassId;
            this.textBoxCredit.Text = this.user.Credits.ToString();
            this.textBoxGitHub.Text = this.user.GitHub;
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            switch (this.mode)
            {
                case EditMode.Create:
                    this.service.AddMember(this.user);
                    break;

                case EditMode.Edit:
                    this.service.UpdateMember(this.user);
                    break;

                case EditMode.View:
                    break;
            }
            this.Close();
        }
    }
}