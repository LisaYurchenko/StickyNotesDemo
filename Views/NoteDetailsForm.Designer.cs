namespace StickyNotesDemo
{
    partial class NoteDetailsForm : BaseForm
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
            titleTextBox = new TextBox();
            contentTextEdit = new RichTextBox();
            tableLayoutPanel = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).BeginInit();
            tableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBoxClose
            // 
            pictureBoxClose.Location = new Point(236, 3);
            // 
            // titleTextBox
            // 
            titleTextBox.BackColor = Color.WhiteSmoke;
            titleTextBox.BorderStyle = BorderStyle.FixedSingle;
            tableLayoutPanel.SetColumnSpan(titleTextBox, 2);
            titleTextBox.Dock = DockStyle.Fill;
            titleTextBox.Location = new Point(10, 42);
            titleTextBox.Margin = new Padding(10, 6, 10, 3);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(256, 23);
            titleTextBox.TabIndex = 0;
            titleTextBox.Enter += TitleTextBox_Enter;
            titleTextBox.Leave += TitleTextBox_Leave;
            // 
            // contentTextEdit
            // 
            contentTextEdit.BackColor = Color.LightYellow;
            contentTextEdit.BorderStyle = BorderStyle.None;
            tableLayoutPanel.SetColumnSpan(contentTextEdit, 2);
            contentTextEdit.Dock = DockStyle.Fill;
            contentTextEdit.ForeColor = Color.Gray;
            contentTextEdit.Location = new Point(10, 76);
            contentTextEdit.Margin = new Padding(10, 20, 10, 3);
            contentTextEdit.Name = "contentTextEdit";
            contentTextEdit.Size = new Size(256, 267);
            contentTextEdit.TabIndex = 1;
            contentTextEdit.Text = "Please enter note content...";
            contentTextEdit.Enter += ContentTextEdit_Enter;
            contentTextEdit.Leave += ContentTextEdit_Leave;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel.ColumnCount = 3;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel.Controls.Add(pictureBoxClose, 1, 0);
            tableLayoutPanel.Controls.Add(titleTextBox, 0, 1);
            tableLayoutPanel.Controls.Add(contentTextEdit, 0, 2);
            tableLayoutPanel.Location = new Point(12, 12);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 3;
            tableLayoutPanel.RowStyles.Add(new RowStyle());
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel.Size = new Size(276, 346);
            tableLayoutPanel.TabIndex = 0;
            tableLayoutPanel.Controls.SetChildIndex(contentTextEdit, 0);
            tableLayoutPanel.Controls.SetChildIndex(titleTextBox, 0);
            tableLayoutPanel.Controls.SetChildIndex(pictureBoxClose, 0);
            // 
            // NoteDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(300, 370);
            Controls.Add(tableLayoutPanel);
            MinimumSize = new Size(300, 370);
            Name = "NoteDetailsForm";
            Text = "NoteDetailsForm";
            FormClosed += NoteDetailsForm_FormClosed;
            Shown += NoteDetailsForm_Shown;
            ((System.ComponentModel.ISupportInitialize)pictureBoxClose).EndInit();
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox titleTextBox;
        private RichTextBox contentTextEdit;
        private TableLayoutPanel tableLayoutPanel;
        private ListView notesListView;
    }
}