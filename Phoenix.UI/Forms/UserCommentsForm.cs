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


        private void BindData(IEnumerable<CommentDto> data)
        {
            commentsDataGridView.DataSource = data;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
             this.pageSizeComboBox.SelectedIndex = 0;
             commentsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

             _pageSize = int.Parse(this.pageSizeComboBox.Items[0].ToString());
             BindData(_userCommentService.GetCommentsFromDb().ToList());
             this.commentsDataGridView.Refresh();
        }


        private void pageSizeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClearTextBoxes();
            _pageSize = int.Parse(this.pageSizeComboBox.SelectedItem.ToString());
            BindData(_userCommentService.GetCommentsFromDb(_pageSize, _pageIndex, searchTextBox.Text).ToList());
            this.commentsDataGridView.Refresh();
        }

        private void nextLabelLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ClearTextBoxes();
            _pageIndex++;
            BindData(_userCommentService.GetCommentsFromDb(_pageSize, _pageIndex, searchTextBox.Text).ToList());
            this.pageIndexlabel.Text = _pageIndex.ToString();
            this.commentsDataGridView.Refresh();
        }

        private void prevLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_pageIndex > 1)
            {
                ClearTextBoxes();
                _pageIndex--;
                BindData(_userCommentService.GetCommentsFromDb(_pageSize, _pageIndex, searchTextBox.Text).ToList());

                this.pageIndexlabel.Text = _pageIndex.ToString();
                this.commentsDataGridView.Refresh();
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


        private void fetchBtn_Click(object sender, EventArgs e)
        {
            var data = _userCommentService.GetCommentsFromApi("api");
            BindData(data);
            commentsDataGridView.Refresh();
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

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            ClearTextBoxes();
        }

        private void LocalDbBtn_Click(object sender, EventArgs e)
        {
            this.pageSizeComboBox.SelectedIndex = 0;
            commentsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            _pageSize = int.Parse(this.pageSizeComboBox.Items[0].ToString());
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
            // var data = await Task.Run(() => _userCommentService.GetCommentsFromApi("/api"))
            // .ConfigureAwait(false);
            commentsDataGridView.DataSource = Array.Empty<CommentDto>();
            commentsDataGridView.Refresh();
            MessageBox.Show("DONE!");
        }
    }
}