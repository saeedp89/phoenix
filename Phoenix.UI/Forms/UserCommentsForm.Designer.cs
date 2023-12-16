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
            dataGridView1 = new DataGridView();
            pageCounterTextBox = new TextBox();
            pageSizeCombox = new ComboBox();
            nextLabelLink = new LinkLabel();
            prevLinkLabel = new LinkLabel();
            searchLabel = new Label();
            searchTextBox = new TextBox();
            searchBtn = new Button();
            idTextBox = new TextBox();
            nameTextBox = new TextBox();
            dateTextBox = new TextBox();
            commentTextBox = new TextBox();
            idLabel = new Label();
            nameLabel = new Label();
            dateLabel = new Label();
            commentLabel = new Label();
            postBtn = new Button();
            fetchBtn = new Button();
            clrBtn = new Button();
            updateDatabaseBtn = new Button();
            localDbBtn = new Button();
            clearDbBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridView1.Location = new Point(3, 196);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(589, 253);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellClick += dataGridView1_CellClick;
            // 
            // pageCounterTextBox
            // 
            pageCounterTextBox.Anchor = AnchorStyles.Bottom;
            pageCounterTextBox.Location = new Point(137, 459);
            pageCounterTextBox.Name = "pageCounterTextBox";
            pageCounterTextBox.ReadOnly = true;
            pageCounterTextBox.Size = new Size(43, 23);
            pageCounterTextBox.TabIndex = 2;
            pageCounterTextBox.Text = "1";
            // 
            // pageSizeCombox
            // 
            pageSizeCombox.FormattingEnabled = true;
            pageSizeCombox.Items.AddRange(new object[] { "5", "10", "20", "50" });
            pageSizeCombox.Location = new Point(456, 454);
            pageSizeCombox.Name = "pageSizeCombox";
            pageSizeCombox.Size = new Size(121, 23);
            pageSizeCombox.TabIndex = 3;
            pageSizeCombox.SelectedIndexChanged += pageSizeCombox_SelectedIndexChanged;
            // 
            // nextLabelLink
            // 
            nextLabelLink.AutoSize = true;
            nextLabelLink.Location = new Point(179, 462);
            nextLabelLink.Name = "nextLabelLink";
            nextLabelLink.Size = new Size(32, 15);
            nextLabelLink.TabIndex = 6;
            nextLabelLink.TabStop = true;
            nextLabelLink.Text = "Next";
            nextLabelLink.LinkClicked += nextLabelLink_LinkClicked;
            // 
            // prevLinkLabel
            // 
            prevLinkLabel.AutoSize = true;
            prevLinkLabel.Location = new Point(73, 462);
            prevLinkLabel.Name = "prevLinkLabel";
            prevLinkLabel.Size = new Size(52, 15);
            prevLinkLabel.TabIndex = 7;
            prevLinkLabel.TabStop = true;
            prevLinkLabel.Text = "Previous";
            prevLinkLabel.LinkClicked += prevLinkLabel_LinkClicked;
            // 
            // searchLabel
            // 
            searchLabel.AutoSize = true;
            searchLabel.Location = new Point(12, 15);
            searchLabel.Name = "searchLabel";
            searchLabel.Size = new Size(110, 15);
            searchLabel.TabIndex = 8;
            searchLabel.Text = "Name or Comment";
            // 
            // searchTextBox
            // 
            searchTextBox.Location = new Point(12, 33);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(150, 23);
            searchTextBox.TabIndex = 9;
            // 
            // searchBtn
            // 
            searchBtn.Location = new Point(12, 62);
            searchBtn.Name = "searchBtn";
            searchBtn.Size = new Size(75, 23);
            searchBtn.TabIndex = 10;
            searchBtn.Text = "Search";
            searchBtn.UseVisualStyleBackColor = true;
            searchBtn.Click += searchBtn_Click;
            // 
            // idTextBox
            // 
            idTextBox.Location = new Point(370, 15);
            idTextBox.Name = "idTextBox";
            idTextBox.ReadOnly = true;
            idTextBox.Size = new Size(168, 23);
            idTextBox.TabIndex = 11;
            // 
            // nameTextBox
            // 
            nameTextBox.Location = new Point(370, 44);
            nameTextBox.Name = "nameTextBox";
            nameTextBox.Size = new Size(168, 23);
            nameTextBox.TabIndex = 12;
            // 
            // dateTextBox
            // 
            dateTextBox.Location = new Point(370, 73);
            dateTextBox.Name = "dateTextBox";
            dateTextBox.Size = new Size(168, 23);
            dateTextBox.TabIndex = 13;
            // 
            // commentTextBox
            // 
            commentTextBox.Location = new Point(370, 102);
            commentTextBox.Name = "commentTextBox";
            commentTextBox.Size = new Size(168, 23);
            commentTextBox.TabIndex = 14;
            // 
            // idLabel
            // 
            idLabel.AutoSize = true;
            idLabel.Location = new Point(304, 23);
            idLabel.Name = "idLabel";
            idLabel.Size = new Size(17, 15);
            idLabel.TabIndex = 15;
            idLabel.Text = "Id";
            // 
            // nameLabel
            // 
            nameLabel.AutoSize = true;
            nameLabel.Location = new Point(304, 52);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(39, 15);
            nameLabel.TabIndex = 16;
            nameLabel.Text = "Name";
            // 
            // dateLabel
            // 
            dateLabel.AutoSize = true;
            dateLabel.Location = new Point(304, 81);
            dateLabel.Name = "dateLabel";
            dateLabel.Size = new Size(31, 15);
            dateLabel.TabIndex = 17;
            dateLabel.Text = "Date";
            // 
            // commentLabel
            // 
            commentLabel.AutoSize = true;
            commentLabel.Location = new Point(304, 110);
            commentLabel.Name = "commentLabel";
            commentLabel.Size = new Size(61, 15);
            commentLabel.TabIndex = 18;
            commentLabel.Text = "Comment";
            // 
            // postBtn
            // 
            postBtn.Location = new Point(370, 131);
            postBtn.Name = "postBtn";
            postBtn.Size = new Size(75, 23);
            postBtn.TabIndex = 21;
            postBtn.Text = "Post Server";
            postBtn.UseVisualStyleBackColor = true;
            postBtn.Click += postBtn_Click;
            // 
            // fetchBtn
            // 
            fetchBtn.Location = new Point(3, 167);
            fetchBtn.Name = "fetchBtn";
            fetchBtn.Size = new Size(119, 23);
            fetchBtn.TabIndex = 22;
            fetchBtn.Text = "Populate From API";
            fetchBtn.UseVisualStyleBackColor = true;
            fetchBtn.Click += fetchBtn_Click;
            // 
            // clrBtn
            // 
            clrBtn.Location = new Point(456, 131);
            clrBtn.Name = "clrBtn";
            clrBtn.Size = new Size(75, 23);
            clrBtn.TabIndex = 23;
            clrBtn.Text = "Clear";
            clrBtn.UseVisualStyleBackColor = true;
            clrBtn.Click += clrBtn_Click;
            // 
            // updateDatabaseBtn
            // 
            updateDatabaseBtn.Location = new Point(137, 131);
            updateDatabaseBtn.Name = "updateDatabaseBtn";
            updateDatabaseBtn.Size = new Size(143, 23);
            updateDatabaseBtn.TabIndex = 24;
            updateDatabaseBtn.Text = "Sync Local Database";
            updateDatabaseBtn.UseVisualStyleBackColor = true;
            updateDatabaseBtn.Click += updateDatabaseBtn_Click;
            // 
            // localDbBtn
            // 
            localDbBtn.Location = new Point(137, 167);
            localDbBtn.Name = "localDbBtn";
            localDbBtn.Size = new Size(143, 23);
            localDbBtn.TabIndex = 25;
            localDbBtn.Text = "Populate From LocalDB";
            localDbBtn.UseVisualStyleBackColor = true;
            localDbBtn.Click += localDbBtn_Click;
            // 
            // clearDbBtn
            // 
            clearDbBtn.Location = new Point(3, 131);
            clearDbBtn.Name = "clearDbBtn";
            clearDbBtn.Size = new Size(119, 23);
            clearDbBtn.TabIndex = 26;
            clearDbBtn.Text = "Clear local Table";
            clearDbBtn.UseVisualStyleBackColor = true;
            clearDbBtn.Click += clearDbBtn_Click;
            // 
            // UserCommentsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(589, 488);
            Controls.Add(clearDbBtn);
            Controls.Add(localDbBtn);
            Controls.Add(updateDatabaseBtn);
            Controls.Add(clrBtn);
            Controls.Add(fetchBtn);
            Controls.Add(postBtn);
            Controls.Add(commentLabel);
            Controls.Add(dateLabel);
            Controls.Add(nameLabel);
            Controls.Add(idLabel);
            Controls.Add(commentTextBox);
            Controls.Add(dateTextBox);
            Controls.Add(nameTextBox);
            Controls.Add(idTextBox);
            Controls.Add(searchBtn);
            Controls.Add(searchTextBox);
            Controls.Add(searchLabel);
            Controls.Add(prevLinkLabel);
            Controls.Add(nextLabelLink);
            Controls.Add(pageSizeCombox);
            Controls.Add(pageCounterTextBox);
            Controls.Add(dataGridView1);
            MinimumSize = new Size(600, 520);
            Name = "UserCommentsForm";
            Text = "Names";
            Load += MainForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox pageCounterTextBox;
        private ComboBox pageSizeCombox;
        private LinkLabel nextLabelLink;
        private LinkLabel prevLinkLabel;
        private Label searchLabel;
        private TextBox searchTextBox;
        private Button searchBtn;
        private TextBox idTextBox;
        private TextBox nameTextBox;
        private TextBox dateTextBox;
        private TextBox commentTextBox;
        private Label idLabel;
        private Label nameLabel;
        private Label dateLabel;
        private Label commentLabel;
        private Button postBtn;
        private Button fetchBtn;
        private Button clrBtn;
        private Button updateDatabaseBtn;
        private Button localDbBtn;
        private Button clearDbBtn;
    }
}
