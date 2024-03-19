namespace StickyNotesDemo
{
    public partial class NotesForm : BaseForm
    {
        List<string> Items = new List<string>();

        public NotesForm()
        {
            InitializeComponent();
            notesListView.BackColor = Color.LightYellow;
        }

        private void pictureBoxAdd_Click(object sender, EventArgs e)
        {
            NoteDetailsForm noteDetailsForm = new NoteDetailsForm();
            noteDetailsForm.ShowDialog();

            var title = noteDetailsForm.Note.Title;
            var content = noteDetailsForm.Note.Content;
            var creationDate = noteDetailsForm.Note.CreationDate.ToString();

            notesListView.View = View.Details;
            var noteListItem = new ListViewItem(new string[] { title, creationDate });
            notesListView.Items.Add(noteListItem);
            Items.Add(title);
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
            var showWnd = new NoteDetailsForm();
            showWnd.Note.Title = selectedItem.Text;
            showWnd.ShowDialog();
            selectedItem.Text = showWnd.Note.Title;
            notesListView.Refresh();
        }

        private void textBoxSearch_TextChanged(object sender, EventArgs e)
        {
            notesListView.Items.Clear();

            foreach (var item in Items)
            {
                if (item.Contains(textBoxSearch.Text))
                {
                    notesListView.Items.Add(item);
                }
            }
        }
    }
}
