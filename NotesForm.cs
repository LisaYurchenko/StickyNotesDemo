﻿namespace StickyNotesDemo
{
    public partial class NotesForm : Form
    {
        public NotesForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            NoteDetailsForm noteDetailsForm = new NoteDetailsForm();
            noteDetailsForm.ShowDialog();

            var title = noteDetailsForm.Title;
            var content = noteDetailsForm.Content;
            var creationDate = noteDetailsForm.CreationDate.ToString();

            notesListView.View = View.Details;
            notesListView.Columns.Add("colTitle");
            notesListView.Columns.Add("colDateTime");
            var noteListItem = new ListViewItem(new string[] { title, creationDate });
            notesListView.Items.Add(noteListItem);
        }
    }
}