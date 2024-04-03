using StickyNotesDemo.Models;
using StickyNotesDemo.Presenters;

namespace StickyNotesDemo
{
    public partial class NoteForm : BaseForm, INoteForm
    {
        private const string SearchPlaceholderText = "Search...";
        public INotesFormPresenter NotesFormPresenter
        {
            private get;
            set;
        }
        public NoteForm()
        {
            InitializeComponent();
            notesListView.BackColor = Color.LightYellow;
        }

        private void PictureBoxAdd_Click(object sender, EventArgs e)
        {
            var note = NotesFormPresenter.CreateNote();
            InsertItem(note);
            ResizeColumnHeaders();
        }

        private void PictureBoxAdd_MouseEnter(object sender, EventArgs e)
        {
            pictureBoxAdd.BackColor = Color.LightGray;
        }

        private void PictureBoxAdd_MouseLeave(object sender, EventArgs e)
        {
            pictureBoxAdd.BackColor = Color.Transparent;
        }

        private void NotesForm_SizeChanged(object sender, EventArgs e)
        {
            ResizeColumnHeaders();
        }

        private void NotesListView_DoubleClick(object sender, EventArgs e)
        {
            var selectedItem = notesListView.SelectedItems[0];
            var index = selectedItem.Index;

            var item = NotesFormPresenter.UpdateNote(Guid.Parse(selectedItem.Tag.ToString()));

            notesListView.Items.RemoveAt(index);
            InsertItem(item, index);
            notesListView.Refresh();
            ResizeColumnHeaders();
        }

        private void TextBoxSearch_TextChanged(object sender, EventArgs e)
        {
            notesListView.Items.Clear();
            NotesFormPresenter.FindItems(textBoxSearch.Text);
        }

        private void textBoxSearch_Enter(object sender, EventArgs e)
        {
            if (textBoxSearch.Text.Equals(SearchPlaceholderText))
            {
                textBoxSearch.Text = "";
                textBoxSearch.ForeColor = Color.Black;
            }
        }

        public void InsertItem(Note note, int id = -1)
        {
            var newItem = new ListViewItem(new string[] { note.Title, note.CreationDate.ToString() })
            {
                Tag = note.Id
            };
            if (id == -1)
            {
                notesListView.Items.Add(newItem);
            }
            else
            {
                notesListView.Items.Insert(id, newItem);
            }
            return;
        }

        private void ResizeColumnHeaders()
        {
            for (int i = 0; i < notesListView.Columns.Count - 1; i++)
            {
                notesListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            notesListView.Columns[^1].Width = -2;
        }

        public void SetData(IEnumerable<Note> notes)
        {
            foreach (var item in notes)
            {
                InsertItem(item);
            }
        }

        private void notesListView_KeyDown(object sender, KeyEventArgs e)
        {
            var selectedItem = notesListView.SelectedItems[0];
            var index = selectedItem.Index;

            NotesFormPresenter.DeleteNote(Guid.Parse(selectedItem.Tag.ToString()));

            notesListView.Items.RemoveAt(index);
            notesListView.Refresh();
            ResizeColumnHeaders();
        }
    }
}
