﻿namespace StickyNotesDemo
{
    partial class NoteForm : BaseForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NoteForm));
            notesListView = new ListView();
            colTitle = new ColumnHeader();
            colDateTime = new ColumnHeader();
            pictureBoxAdd = new PictureBox();
            pictureBoxMore = new PictureBox();
            tableLayoutPanel = new TableLayoutPanel();
            textBoxSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdd).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMore).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxClose
            // 
            pictureBoxClose.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pictureBoxClose.Location = new Point(322, 3);
            // 
            // notesListView
            // 
            notesListView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            notesListView.BorderStyle = BorderStyle.None;
            notesListView.Columns.AddRange(new ColumnHeader[] { colTitle, colDateTime });
            tableLayoutPanel.SetColumnSpan(notesListView, 3);
            notesListView.HeaderStyle = ColumnHeaderStyle.None;
            notesListView.Location = new Point(10, 76);
            notesListView.Margin = new Padding(10, 20, 10, 0);
            notesListView.Name = "notesListView";
            notesListView.Size = new Size(342, 346);
            notesListView.TabIndex = 0;
            notesListView.UseCompatibleStateImageBehavior = false;
            notesListView.View = View.Details;
            notesListView.DoubleClick += NotesListView_DoubleClick;
            notesListView.KeyDown += notesListView_KeyDown;
            // 
            // colTitle
            // 
            colTitle.Text = "";
            colTitle.Width = 150;
            // 
            // colDateTime
            // 
            colDateTime.Text = "";
            colDateTime.TextAlign = HorizontalAlignment.Right;
            colDateTime.Width = 150;
            // 
            // pictureBoxAdd
            // 
            pictureBoxAdd.BackColor = Color.Transparent;
            pictureBoxAdd.Image = (Image)resources.GetObject("pictureBoxAdd.Image");
            pictureBoxAdd.InitialImage = (Image)resources.GetObject("pictureBoxAdd.InitialImage");
            pictureBoxAdd.Location = new Point(10, 3);
            pictureBoxAdd.Margin = new Padding(10, 3, 3, 3);
            pictureBoxAdd.Name = "pictureBoxAdd";
            pictureBoxAdd.Size = new Size(30, 30);
            pictureBoxAdd.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxAdd.TabIndex = 4;
            pictureBoxAdd.TabStop = false;
            pictureBoxAdd.Click += PictureBoxAdd_Click;
            pictureBoxAdd.MouseEnter += PictureBoxAdd_MouseEnter;
            pictureBoxAdd.MouseLeave += PictureBoxAdd_MouseLeave;
            // 
            // pictureBoxMore
            // 
            pictureBoxMore.Image = (Image)resources.GetObject("pictureBoxMore.Image");
            pictureBoxMore.Location = new Point(279, 3);
            pictureBoxMore.Margin = new Padding(3, 3, 10, 3);
            pictureBoxMore.Name = "pictureBoxMore";
            pictureBoxMore.Size = new Size(30, 30);
            pictureBoxMore.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBoxMore.TabIndex = 5;
            pictureBoxMore.TabStop = false;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.Controls.Add(notesListView, 0, 2);
            tableLayoutPanel.Controls.Add(pictureBoxMore, 1, 0);
            tableLayoutPanel.Controls.Add(pictureBoxAdd, 0, 0);
            tableLayoutPanel.Controls.Add(pictureBoxClose, 2, 0);
            tableLayoutPanel.Controls.Add(textBoxSearch, 0, 1);
            tableLayoutPanel.Location = new Point(9, 9);
            tableLayoutPanel.Margin = new Padding(0, 0, 0, 10);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(362, 422);
            tableLayoutPanel.TabIndex = 7;
            tableLayoutPanel.Controls.SetChildIndex(textBoxSearch, 0);
            tableLayoutPanel.Controls.SetChildIndex(pictureBoxClose, 0);
            tableLayoutPanel.Controls.SetChildIndex(pictureBoxAdd, 0);
            tableLayoutPanel.Controls.SetChildIndex(pictureBoxMore, 0);
            tableLayoutPanel.Controls.SetChildIndex(notesListView, 0);
            // 
            // textBoxSearch
            // 
            textBoxSearch.BackColor = Color.WhiteSmoke;
            tableLayoutPanel.SetColumnSpan(textBoxSearch, 3);
            textBoxSearch.Dock = DockStyle.Fill;
            textBoxSearch.Location = new Point(10, 42);
            textBoxSearch.Margin = new Padding(10, 6, 10, 6);
            textBoxSearch.Name = "textBoxSearch";
            textBoxSearch.Size = new Size(342, 23);
            textBoxSearch.TabIndex = 7;
            textBoxSearch.TextChanged += TextBoxSearch_TextChanged;
            textBoxSearch.Enter += textBoxSearch_Enter;
            // 
            // NoteForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(380, 450);
            Controls.Add(tableLayoutPanel);
            MinimumSize = new Size(380, 450);
            Name = "NoteForm";
            Text = "NotesForm";
            SizeChanged += NotesForm_SizeChanged;
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxAdd).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBoxMore).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private ListView notesListView;
        private PictureBox pictureBoxAdd;
        private PictureBox pictureBoxMore;
        private TableLayoutPanel tableLayoutPanel;
        private ColumnHeader colTitle;
        private ColumnHeader colDateTime;
        private TextBox textBoxSearch;
    }
}