using System.Resources;
using Microsoft.Extensions.Localization;
using Phoenix.Infrastructure.Abstractions;
using Phoenix.Infrastructure.Models;
using Phoenix.Infrastructure.Models.DataTransferObjects;

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


        private async void MainForm_Load(object sender, EventArgs e)
        {
            this.pageSizeComboBox.SelectedIndex = 0;
            commentsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _pageSize = int.Parse(this.pageSizeComboBox.Items[0].ToString());
            commentsDataGridView.DataSource = await _userCommentService.GetCommentsFromDbAsync();
            this.commentsDataGridView.Refresh();
        }


        private async void pageSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTextBoxes();
            _pageSize = int.Parse(this.pageSizeComboBox.SelectedItem.ToString());
            commentsDataGridView.DataSource =
                await _userCommentService.GetCommentsFromDbAsync(_pageSize, _pageIndex, searchTextBox.Text);
            this.commentsDataGridView.Refresh();
        }

        private async void nextLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearTextBoxes();
            _pageIndex++;
            commentsDataGridView.DataSource =
                await _userCommentService.GetCommentsFromDbAsync(_pageSize, _pageIndex, searchTextBox.Text);
            this.pageIndexlabel.Text = _pageIndex.ToString();
            this.commentsDataGridView.Refresh();
        }

        private async void prevLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_pageIndex > 1)
            {
                ClearTextBoxes();
                _pageIndex--;
                commentsDataGridView.DataSource =
                    await _userCommentService.GetCommentsFromDbAsync(_pageSize, _pageIndex, searchTextBox.Text);

                this.pageIndexlabel.Text = _pageIndex.ToString();
                this.commentsDataGridView.Refresh();
            }
            else
            {
                MessageBox.Show("first page");
            }
        }

        private async void searchBtn_Click(object sender, EventArgs e)
        {
            var data = await _userCommentService.GetCommentsFromDbAsync(_pageSize, _pageIndex, searchTextBox.Text);
            commentsDataGridView.DataSource = data;
            commentsDataGridView.Refresh();
        }

        private void CommentsDataGridViewCellClick(object sender, DataGridViewCellEventArgs e)
        {
            var selectedComment = GetSelectedRowData();
            FillTextBoxesFromSelectedRow(selectedComment);
        }

        private CommentDto GetSelectedRowData()
        {
            return commentsDataGridView.SelectedRows[0].DataBoundItem as CommentDto;
        }

        private void FillTextBoxesFromSelectedRow(CommentDto? selectedComment)
        {
            idTextBox.Text = selectedComment.Id.ToString();
            nameTextBox.Text = selectedComment.Name;
            dateTextBox.Text = selectedComment.Date;
            commentTextBox.Text = selectedComment.Comment;
        }


        private void ClearTextBoxes()
        {
            idTextBox.Clear();
            nameTextBox.Clear();
            dateTextBox.Clear();
            commentTextBox.Clear();
        }


        private async void fetchBtn_Click(object sender, EventArgs e)
        {
            var data = await _userCommentService.GetCommentsFromApiAsync("api");
            commentsDataGridView.DataSource = data;
            commentsDataGridView.Refresh();
        }

        private async void postBtn_Click(object sender, EventArgs e)
        {
            var result = await _userCommentService.PostDataAsync(new CommentDto()
            {
                Date = dateTextBox.Text,
                Comment = commentTextBox.Text,
                Name = nameTextBox.Text
            });
            MessageBox.Show(result);
            fetchBtn.PerformClick();
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private async void LocalDbBtn_Click(object sender, EventArgs e)
        {
            this.pageSizeComboBox.SelectedIndex = 0;
            commentsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _pageSize = int.Parse(this.pageSizeComboBox.Items[0].ToString());
            commentsDataGridView.DataSource = await _userCommentService.GetCommentsFromDbAsync();
            commentsDataGridView.Refresh();
            MessageBox.Show("Data fetched from Local db");
        }

        private async void updateDatabaseBtn_Click(object sender, EventArgs e)
        {
            await _userCommentService.SynchronizeDatabaseWithServerAsync();
            MessageBox.Show("Synchronized Database with Server");
        }

        private async void clearDbBtn_Click(object sender, EventArgs e)
        {
            await _userCommentService.ClearLocalTableAsync();
            // var data = await Task.Run(() => _userCommentService.GetCommentsFromApiAsync("/api"))
            // .ConfigureAwait(false);
            commentsDataGridView.DataSource = Array.Empty<CommentDto>();
            commentsDataGridView.Refresh();
            MessageBox.Show("DONE!");
        }

        private async void ClearTableBtn_Click(object sender, EventArgs e)
        {
           await _userCommentService.ClearLocalTableAsync();
        }
    }
}