using StickyNotesDemo.Models;

namespace StickyNotesDemo
{
    public partial class NoteForm : BaseForm
    {
        List<Note> Items = new List<Note>();

        public NoteForm()
        {
            InitializeComponent();
            notesListView.BackColor = Color.LightYellow;
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            NoteDetailsForm noteDetailsForm = new NoteDetailsForm();
            noteDetailsForm.ShowDialog();

            var note = noteDetailsForm.Note;
            var noteListItem = new ListViewItem(new string[] { note.Title, note.CreationDate.ToString() });
            notesListView.Items.Add(noteListItem);
            Items.Add(note);
            ResizeColumnHeaders();
        }

        private void ResizeColumnHeaders()
        {
            for (int i = 0; i < this.notesListView.Columns.Count - 1; i++)
                this.notesListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            this.notesListView.Columns[this.notesListView.Columns.Count - 1].Width = -2;
        }

        private void pictureBoxAdd_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAdd.BackColor = Color.LightGray;
        }

        private void pictureBoxAdd_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAdd.BackColor = Color.Transparent;
        }

        private void pictureBoxMore_Click(object sender, EventArgs e)
        {

        }

        private void pictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotesForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeColumnHeaders();
        }

        private void notesListView_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = notesListView.SelectedItems[0];
            var index = selectedItem.Index;
            var note = Items.FirstOrDefault(x => x.Title.Equals(selectedItem.Text));
            if (note == null)
            {
                return;
            }
            var showWnd = new NoteDetailsForm
            {
                Note = note
            };
            showWnd.ShowDialog();
            note.Title = showWnd.Note.Title;
            note.Content = showWnd.Note.Content;

            notesListView.Items.RemoveAt(index);
            notesListView.Items.Insert(index, new ListViewItem(new string[] { note.Title, note.CreationDate.ToString() }));
            notesListView.Refresh();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            notesListView.Items.Clear();

            foreach (var item in Items)
            {
                if (item.Title.Contains(textBoxSearch.Text))
                {
                    notesListView.Items.Add(new ListViewItem(new string[] { item.Title, item.CreationDate.ToString() }));
                }
            }
        }
    }
}
