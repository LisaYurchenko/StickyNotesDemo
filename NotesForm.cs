namespace StickyNotesDemo
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
        }
    }
}
