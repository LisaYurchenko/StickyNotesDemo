namespace StickyNotesDemo
{
    partial class NotesForm
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
            notesListView = new ListView();
            buttonAdd = new Button();
            SuspendLayout();
            // 
            // notesListView
            // 
            notesListView.Location = new Point(-3, 36);
            notesListView.Name = "notesListView";
            notesListView.Size = new Size(332, 325);
            notesListView.TabIndex = 0;
            notesListView.UseCompatibleStateImageBehavior = false;
            // 
            // buttonAdd
            // 
            buttonAdd.Location = new Point(-3, 7);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(41, 23);
            buttonAdd.TabIndex = 1;
            buttonAdd.Text = "+";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // NotesForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(328, 359);
            Controls.Add(buttonAdd);
            Controls.Add(notesListView);
            Name = "NotesForm";
            Text = "NotesForm";
            ResumeLayout(false);
        }

        #endregion

        private ListView notesListView;
        private Button buttonAdd;
    }
}