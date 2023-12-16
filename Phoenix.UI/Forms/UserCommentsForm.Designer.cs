using System.Numerics;

namespace Phoenix.UI.Forms
{
    partial class UserCommentsForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            commentsDataGridView = new DataGridView();
            pageSizeComboBox = new ComboBox();
            nextLabelLink = new LinkLabel();
            prevLinkLabel = new LinkLabel();
            searchTextBox = new TextBox();
            searchBtn = new Button();
            idTextBox = new TextBox();
            nameTextBox = new TextBox();
            dateTextBox = new TextBox();
            commentTextBox = new TextBox();
            postBtn = new Button();
            fetchBtn = new Button();
            clrBtn = new Button();
            updateDatabaseBtn = new Button();
            localDbBtn = new Button();
            clearDbBtn = new Button();
            pageIndexlabel = new Label();
            // ((System.ComponentModel.ISupportInitialize)commentsDataGridView).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            commentsDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            commentsDataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            commentsDataGridView.BackgroundColor = Color.LavenderBlush;
            commentsDataGridView.GridColor = SystemColors.ActiveCaption;
            commentsDataGridView.Location = new Point(12, 402);
            commentsDataGridView.Name = "commentsDataGridView";
            commentsDataGridView.Size = new Size(565, 253);
            commentsDataGridView.TabIndex = 0;
            commentsDataGridView.CellClick += CommentsDataGridViewCellClick;
            // 
            // pageSizeCombox
            // 
            pageSizeComboBox.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            pageSizeComboBox.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pageSizeComboBox.FormattingEnabled = true;
            pageSizeComboBox.Items.AddRange(new object[] { "5", "10", "20", "50" });
            pageSizeComboBox.Location = new Point(456, 681);
            pageSizeComboBox.Name = "pageSizeComboBox";
            pageSizeComboBox.Size = new Size(121, 25);
            pageSizeComboBox.TabIndex = 3;
            pageSizeComboBox.SelectedIndexChanged += pageSizeComboBox_SelectedIndexChanged;
            // 
            // nextLabelLink
            // 
            nextLabelLink.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            nextLabelLink.AutoSize = true;
            nextLabelLink.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nextLabelLink.Location = new Point(185, 684);
            nextLabelLink.Name = "nextLabelLink";
            nextLabelLink.Size = new Size(37, 17);
            nextLabelLink.TabIndex = 6;
            nextLabelLink.TabStop = true;
            nextLabelLink.Text = "Next";
            nextLabelLink.LinkClicked += nextLabelLink_LinkClicked;
            // 
            // prevLinkLabel
            // 
            prevLinkLabel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            prevLinkLabel.AutoSize = true;
            prevLinkLabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            prevLinkLabel.Location = new Point(70, 681);
            prevLinkLabel.Name = "prevLinkLabel";
            prevLinkLabel.Size = new Size(54, 17);
            prevLinkLabel.TabIndex = 7;
            prevLinkLabel.TabStop = true;
            prevLinkLabel.Text = "Previous";
            prevLinkLabel.LinkClicked += prevLinkLabel_LinkClicked;
            // 
            // searchTextBox
            // 
            searchTextBox.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchTextBox.Location = new Point(353, 20);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Name or Description";
            searchTextBox.Size = new Size(224, 24);
            searchTextBox.TabIndex = 9;
            // 
            // searchBtn
            // 
            searchBtn.BackColor = Color.SeaGreen;
            searchBtn.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            searchBtn.ForeColor = SystemColors.Control;
            searchBtn.Location = new Point(516, 49);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(60, 30);
            searchBtn.TabIndex = 10;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = false;
            searchBtn.Click += searchBtn_Click;
            // 
            // idTextBox
            // 
            idTextBox.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTextBox.Location = new Point(12, 20);
            idTextBox.Name = "idTextBox";
            idTextBox.PlaceholderText = "Id";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(221, 24);
            idTextBox.TabIndex = 11;
            // 
            // nameTextBox
            // 
            nameTextBox.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nameTextBox.Location = new Point(12, 49);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.PlaceholderText = "Name";
            nameTextBox.Size = new Size(221, 24);
            nameTextBox.TabIndex = 12;
            // 
            // dateTextBox
            // 
            dateTextBox.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTextBox.Location = new Point(12, 78);
            dateTextBox.Name = "dateTextBox";
            dateTextBox.PlaceholderText = "Date";
            dateTextBox.Size = new Size(221, 24);
            dateTextBox.TabIndex = 13;
            // 
            // commentTextBox
            // 
            commentTextBox.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            commentTextBox.Location = new Point(12, 107);
            commentTextBox.Name = "commentTextBox";
            commentTextBox.PlaceholderText = "Comment";
            commentTextBox.Size = new Size(221, 24);
            commentTextBox.TabIndex = 14;
            // 
            // postBtn
            // 
            postBtn.BackColor = Color.SeaGreen;
            postBtn.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            postBtn.ForeColor = SystemColors.Control;
            postBtn.Location = new Point(12, 136);
            postBtn.Name = "postBtn";
            postBtn.Size = new Size(60, 30);
            postBtn.TabIndex = 21;
            postBtn.Text = "Post Server";
            postBtn.UseVisualStyleBackColor = false;
            postBtn.Click += postBtn_Click;
            // 
            // fetchBtn
            // 
            fetchBtn.BackColor = Color.SeaGreen;
            fetchBtn.Font = new Font("Comic Sans MS", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            fetchBtn.ForeColor = SystemColors.Control;
            fetchBtn.Location = new Point(12, 325);
            fetchBtn.Name = "fetchBtn";
            fetchBtn.Size = new Size(120, 60);
            fetchBtn.TabIndex = 22;
            fetchBtn.Text = "Populate local Db From API";
            fetchBtn.UseVisualStyleBackColor = false;
            fetchBtn.Click += fetchBtn_Click;
            // 
            // clrBtn
            // 
            clrBtn.BackColor = Color.SeaGreen;
            clrBtn.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clrBtn.ForeColor = SystemColors.Control;
            clrBtn.Location = new Point(173, 136);
            clrBtn.Name = "clrBtn";
            clrBtn.Size = new Size(60, 30);
            clrBtn.TabIndex = 23;
            clrBtn.Text = "Clear";
            clrBtn.UseVisualStyleBackColor = false;
            clrBtn.Click += ClearBtn_Click;
            // 
            // updateDatabaseBtn
            // 
            updateDatabaseBtn.BackColor = Color.SeaGreen;
            updateDatabaseBtn.Font = new Font("Comic Sans MS", 9F, FontStyle.Italic, GraphicsUnit.Point, 0);
            updateDatabaseBtn.ForeColor = SystemColors.Control;
            updateDatabaseBtn.Location = new Point(142, 325);
            updateDatabaseBtn.Name = "updateDatabaseBtn";
            updateDatabaseBtn.Size = new Size(120, 60);
            updateDatabaseBtn.TabIndex = 24;
            updateDatabaseBtn.Text = "Sync Local Database";
            updateDatabaseBtn.UseVisualStyleBackColor = false;
            updateDatabaseBtn.Click += updateDatabaseBtn_Click;
            // 
            // localDbBtn
            // 
            localDbBtn.BackColor = Color.SeaGreen;
            localDbBtn.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            localDbBtn.ForeColor = SystemColors.Control;
            localDbBtn.Location = new Point(456, 325);
            localDbBtn.Name = "localDbBtn";
            localDbBtn.Size = new Size(120, 60);
            localDbBtn.TabIndex = 25;
            localDbBtn.Text = "Populate Table From LocalDB";
            localDbBtn.UseVisualStyleBackColor = false;
            localDbBtn.Click += LocalDbBtn_Click;
            // 
            // clearDbBtn
            // 
            clearDbBtn.BackColor = Color.SeaGreen;
            clearDbBtn.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clearDbBtn.ForeColor = SystemColors.Control;
            clearDbBtn.Location = new Point(325, 325);
            clearDbBtn.Name = "clearDbBtn";
            clearDbBtn.Size = new Size(120, 60);
            clearDbBtn.TabIndex = 26;
            clearDbBtn.Text = "Clear local Table";
            clearDbBtn.UseVisualStyleBackColor = false;
            clearDbBtn.Click += clearDbBtn_Click;
            // 
            // pageIndexlabel
            // 
            pageIndexlabel.AutoSize = true;
            pageIndexlabel.Font = new Font("Comic Sans MS", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            pageIndexlabel.Location = new Point(142, 681);
            pageIndexlabel.Name = "pageIndexlabel";
            pageIndexlabel.Size = new Size(13, 17);
            pageIndexlabel.TabIndex = 27;
            pageIndexlabel.Text = "1";
            // 
            // UserCommentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Lavender;
            ClientSize = new Size(589, 715);
            Controls.Add(pageIndexlabel);
            Controls.Add(clearDbBtn);
            Controls.Add(localDbBtn);
            Controls.Add(updateDatabaseBtn);
            Controls.Add(clrBtn);
            Controls.Add(fetchBtn);
            Controls.Add(postBtn);
            Controls.Add(commentTextBox);
            Controls.Add(dateTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(idTextBox);
            Controls.Add(searchBtn);
            Controls.Add(searchTextBox);
            Controls.Add(prevLinkLabel);
            Controls.Add(nextLabelLink);
            Controls.Add(pageSizeComboBox);
            Controls.Add(commentsDataGridView);
            MinimumSize = new Size(600, 520);
            Name = "UserCommentsForm";
            Text = "Names";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)commentsDataGridView).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView commentsDataGridView;
        private ComboBox pageSizeComboBox;
        private LinkLabel nextLabelLink;
        private LinkLabel prevLinkLabel;
        private TextBox searchTextBox;
        private Button searchBtn;
        private TextBox idTextBox;
        private TextBox nameTextBox;
        private TextBox dateTextBox;
        private TextBox commentTextBox;
        private Button postBtn;
        private Button fetchBtn;
        private Button clrBtn;
        private Button updateDatabaseBtn;
        private Button localDbBtn;
        private Button clearDbBtn;
        private Label pageIndexlabel;
    }
}

