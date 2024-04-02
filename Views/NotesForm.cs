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
            string[] noteListItem = NotesFormPresenter.CreateNote();

            notesListView.Items.Add(new ListViewItem(noteListItem));
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

            var item = NotesFormPresenter.UpdateNote(selectedItem.Text);

            notesListView.Items.RemoveAt(index);
            InsertItem(item);
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

        public void InsertItem(string[]? strings, int id = -1)
        {
            if (id != -1)
            {
                notesListView.Items.Insert(id, new ListViewItem(strings));
                return;
            }
            notesListView.Items.Add(new ListViewItem(strings));
        }

        private void ResizeColumnHeaders()
        {
            for (int i = 0; i < notesListView.Columns.Count - 1; i++)
            {
                notesListView.AutoResizeColumn(i, ColumnHeaderAutoResizeStyle.ColumnContent);
            }
            notesListView.Columns[^1].Width = -2;
        }
    }
}
