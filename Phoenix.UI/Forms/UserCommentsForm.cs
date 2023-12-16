using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using Phoenix.UI.Models;
using Phoenix.UI.Services;

namespace Phoenix.UI.Forms
{
    public partial class UserCommentsForm : Form
    {
        private readonly IUserCommentService _userCommentService;
        private int _pageSize = 5;
        private int _pageIndex = 1;

        public UserCommentsForm(IUserCommentService userCommentService)
        {
            _userCommentService = userCommentService;
            InitializeComponent();
        }


        private void BindData(List<CommentDto> data)
        {
            dataGridView1.DataSource = data;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.pageSizeCombox.SelectedIndex = 0;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _pageSize = int.Parse(this.pageSizeCombox.Items[0].ToString());
            BindData(_userCommentService.GetCommentsFromDb().ToList());
        }


        private void pageSizeCombox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearTextBoxes();
            _pageSize = int.Parse(this.pageSizeCombox.SelectedItem.ToString());
            BindData(_userCommentService.GetCommentsFromDb(_pageSize, _pageIndex, searchTextBox.Text).ToList());
            this.dataGridView1.Refresh();
        }

        private void nextLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            clearTextBoxes();
            _pageIndex++;
            BindData(_userCommentService.GetCommentsFromDb(_pageSize, _pageIndex, searchTextBox.Text).ToList());
            this.pageCounterTextBox.Text = _pageIndex.ToString();
            this.dataGridView1.Refresh();
        }

        private void prevLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_pageIndex > 1)
            {
                clearTextBoxes();
                _pageIndex--;
                BindData(_userCommentService.GetCommentsFromDb(_pageSize, _pageIndex, searchTextBox.Text).ToList());
                this.pageCounterTextBox.Text = _pageIndex.ToString();
                this.dataGridView1.Refresh();
            }
            else
            {
                MessageBox.Show("first page");
            }
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            var data = _userCommentService.GetCommentsFromDb(_pageSize, _pageIndex, searchTextBox.Text);
            BindData(data.ToList());
            dataGridView1.Refresh();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedComment = GetSelectedRowData();
            CreateObjectFromSelectedRow(selectedComment);
        }

        private CommentDto GetSelectedRowData()
        {
            return dataGridView1.SelectedRows[0].DataBoundItem as CommentDto;
        }

        private void CreateObjectFromSelectedRow(CommentDto? selectedComment)
        {
            idTextBox.Text = selectedComment.Id.ToString();
            nameTextBox.Text = selectedComment.Name;
            dateTextBox.Text = selectedComment.Date;
            commentTextBox.Text = selectedComment.Comment;
        }


        private void clearTextBoxes()
        {
            idTextBox.Clear();
            nameTextBox.Clear();
            dateTextBox.Clear();
            commentTextBox.Clear();
        }


        private void fetchBtn_Click(object sender, EventArgs e)
        {
            var data = _userCommentService.GetCommentsFromApi("/api").ToList();
            BindData(data);
            dataGridView1.Refresh();
        }

        private void postBtn_Click(object sender, EventArgs e)
        {
            var result = _userCommentService.PostData(new CommentDto()
            {
                Date = dateTextBox.Text,
                Comment = commentTextBox.Text,
                Name = nameTextBox.Text
            });
            MessageBox.Show(result);
            fetchBtn.PerformClick();
        }

        private void clrBtn_Click(object sender, EventArgs e)
        {
            clearTextBoxes();
        }

        private void localDbBtn_Click(object sender, EventArgs e)
        {
            this.pageSizeCombox.SelectedIndex = 0;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _pageSize = int.Parse(this.pageSizeCombox.Items[0].ToString());
            BindData(_userCommentService.GetCommentsFromDb().ToList());
            MessageBox.Show("Data fetched from Local db");
        }

        private void updateDatabaseBtn_Click(object sender, EventArgs e)
        {
            _userCommentService.SynchronizeDatabaseWithServer();
            MessageBox.Show("Synchronized Database with Server");
        }

        private void clearDbBtn_Click(object sender, EventArgs e)
        {
            _userCommentService.ClearLocalTable();
            BindData(_userCommentService.GetCommentsFromApi("/api").ToList());
            dataGridView1.Refresh();
            MessageBox.Show("Database cleared and table is fetched from API");
        }
    }
}