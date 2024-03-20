using StickyNotesDemo.Models;

namespace StickyNotesDemo
{
    public partial class NoteDetailsForm : BaseForm
    {
        private const string ContentPlaceholderText = "Please enter note content...";
        private const string TitlePlaceholderText = "Please enter note title...";
        private Note _note;

        public NoteDetailsForm()
        {
            InitializeComponent();
            contentTextEdit.Text = ContentPlaceholderText;
            contentTextEdit.ForeColor = Color.Gray;
            titleTextBox.Text = TitlePlaceholderText;
            titleTextBox.ForeColor = Color.Gray;
        }

        internal Note Note
        {
            get
            {
                _note ??= new Note();
                return _note;
            }
            set
            {
                _note = value;
            }
        }

        private void NoteDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            _note = new Note(titleTextBox.Text, contentTextEdit.Text);
        }

        private void NoteDetailsForm_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Note.Title))
            {
                return;
            }
            titleTextBox.Text = Note.Title;
            contentTextEdit.Text = Note.Content;
        }

        private void ContentTextEdit_Enter(object sender, EventArgs e)
        {
            if (contentTextEdit.Text.Equals(ContentPlaceholderText))
            {
                contentTextEdit.Text = "";
                contentTextEdit.ForeColor = Color.Black;
            }
        }

        private void ContentTextEdit_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(contentTextEdit.Text))
            {
                contentTextEdit.Text = ContentPlaceholderText;
                contentTextEdit.ForeColor = Color.Gray;
            }
        }

        private void TitleTextBox_Enter(object sender, EventArgs e)
        {
            if (titleTextBox.Text.Equals(TitlePlaceholderText))
            {
                titleTextBox.Text = "";
                titleTextBox.ForeColor = Color.Black;
            }
        }

        private void TitleTextBox_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(titleTextBox.Text))
            {
                titleTextBox.Text = TitlePlaceholderText;
                titleTextBox.ForeColor = Color.Gray;
            }
        }
    }
}
