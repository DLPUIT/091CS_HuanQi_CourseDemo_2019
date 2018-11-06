namespace Case4
{
    #region using directives

    using DlpuManager.Service;
    using System;
    using System.Data;
    using System.Windows.Forms;

    #endregion using directives

    public partial class MainForm : Form
    {
        private readonly DlpuManagerService service = new DlpuManagerService();

        public MainForm()
        {
            this.InitializeComponent();
            this.LoadData();
        }

        public void LoadData()
        {
            // Way 1: 水军写法
            var allMember = this.service.GetAllMember();
            this.dataGridViewAllUser.DataSource = allMember;

            // Way 2: 正规写法
            var dataTable = new DataTable();
            dataTable.Columns.Add("姓名", typeof(string));
            dataTable.Columns.Add("班级 ID", typeof(string));
            dataTable.Columns.Add("积分", typeof(int));
            dataTable.Columns.Add("GitHub", typeof(string));
            dataTable.Columns.Add("Id", typeof(string));

            foreach (var user in allMember)
            {
                dataTable.Rows.Add(user.Name, user.ClassId, user.Credits, user.GitHub, user.Id);
            }

            this.dataGridViewAllUser.DataSource = dataTable;
            this.dataGridViewAllUser.Columns["Id"].Visible = false;
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //var name = this.dataGridViewAllUser.CurrentRow.Cells[1].Value;

            // SelectionMode 属性！！！

            if (this.dataGridViewAllUser.SelectedRows.Count < 1) { return; }
            var currentSelectedMemberName = (string)this.dataGridViewAllUser.SelectedRows[0].Cells["姓名"].Value;
            var confirmResult = MessageBox.Show("你确定要删除这位成员吗?", "删除成员", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);
            if (confirmResult == DialogResult.Yes)
            {
                this.service.DeleteMember(currentSelectedMemberName);
                this.LoadData();
            }
        }

        private void buttonSync_Click(object sender, EventArgs e)
        {
            this.LoadData();
        }
    }
}