using StickyNotesDemo.Models;

namespace StickyNotesDemo
{
    public partial class NoteDetailsForm : BaseForm
    {
        private Note _note;
        public NoteDetailsForm() : base()
        {
            InitializeComponent();
        }

        internal Note Note
        {
            get
            {
                if (_note == null)
                {
                    _note = new Note("", "");
                }
                return _note;
            }
        }

        private void NoteDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _note = new Note(titleTextBox.Text, contentTextEdit.Text);
            var creationDate = _note.CreationDate;
        }

        private void NoteDetailsForm_Shown(object sender, EventArgs e)
        {
            titleTextBox.Text = Note.Title;
            contentTextEdit.Text = Note.Content;
        }
    }
}
