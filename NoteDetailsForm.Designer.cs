namespace StickyNotesDemo
{
    partial class NoteDetailsForm
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
            SuspendLayout();
            // 
            // titleTextBox
            // 
            titleTextBox.Location = new Point(12, 12);
            titleTextBox.Name = "titleTextBox";
            titleTextBox.Size = new Size(299, 23);
            titleTextBox.TabIndex = 0;
            // 
            // contentTextEdit
            // 
            contentTextEdit.Location = new Point(12, 51);
            contentTextEdit.Name = "contentTextEdit";
            contentTextEdit.Size = new Size(299, 291);
            contentTextEdit.TabIndex = 1;
            contentTextEdit.Text = "";
            // 
            // NoteDetailsForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(323, 354);
            Controls.Add(contentTextEdit);
            Controls.Add(titleTextBox);
            Name = "NoteDetailsForm";
            Text = "NoteDetailsForm";
            FormClosed += NoteDetailsForm_FormClosed;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox titleTextBox;
        private RichTextBox contentTextEdit;
    }
}