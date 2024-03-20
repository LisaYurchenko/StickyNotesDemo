using StickyNotesDemo.Models;

namespace StickyNotesDemo
{
    public partial class NoteForm : BaseForm
    {
        private const string SearchPlaceholderText = "Search...";
        readonly List<Note> _notesList = new();

        public NoteForm()
        {
            InitializeComponent();
            notesListView.BackColor = Color.LightYellow;
        }

        private void PictureBoxAdd_Click(object sender, EventArgs e)
        {
            NoteDetailsForm noteDetailsForm = new();
            noteDetailsForm.ShowDialog();

            var note = noteDetailsForm.Note;
            var noteListItem = new ListViewItem(new string[] { note.Title, note.CreationDate.ToString() });
            notesListView.Items.Add(noteListItem);
            _notesList.Add(note);
            ResizeColumnHeaders();
        }

        private void ResizeColumnHeaders()
        {
            for (int i = 0; i < notesListView.Columns.Count - 1; i++)
            {
                notesListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            notesListView.Columns[notesListView.Columns.Count - 1].Width = -2;
        }

        private void PictureBoxAdd_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAdd.BackColor = Color.LightGray;
        }

        private void PictureBoxAdd_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAdd.BackColor = Color.Transparent;
        }

        private void PictureBoxMore_Click(object sender, EventArgs e)
        {

        }

        private void PictureBoxClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NotesForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeColumnHeaders();
        }

        private void NotesListView_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = notesListView.SelectedItems[0];
            var index = selectedItem.Index;
            var note = _notesList.FirstOrDefault(x => x.Title.Equals(selectedItem.Text));
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
            ResizeColumnHeaders();
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            notesListView.Items.Clear();

            foreach (var item in _notesList)
            {
                if (item.Title.Contains(textBoxSearch.Text))
                {
                    notesListView.Items.Add(new ListViewItem(new string[] { item.Title, item.CreationDate.ToString() }));
                }
            }
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Equals(SearchPlaceholderText))
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.Black;
            }
        }

        private void textBoxSearch_Leave(object sender, EventArgs e)
        {

        }
    }
}
