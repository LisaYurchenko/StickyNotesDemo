using StickyNotesDemo.Presenters;

namespace StickyNotesDemo
{
    public partial class NoteDetailsForm : BaseForm, INoteDetailsForm
    {
        private const string ContentPlaceholderText = "Please enter note content...";
        private const string TitlePlaceholderText = "Please enter note title...";

        public string Title
        {
            get; set;
        }
        public string Content
        {
            get; set;
        }
        public INoteDetailsFormPresenter NoteDetailsFormPresenter
        {
            get;
            internal set;
        }

        public NoteDetailsForm(string title = "", string content = "")
        {
            InitializeComponent();
            contentTextEdit.Text = ContentPlaceholderText;
            contentTextEdit.ForeColor = Color.Gray;
            titleTextBox.Text = TitlePlaceholderText;
            titleTextBox.ForeColor = Color.Gray;
            Title = title;
            Content = content;
        }

        private void NoteDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Title = titleTextBox.Text;
            Content = contentTextEdit.Text;
        }

        private void NoteDetailsForm_Shown(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Title))
            {
                return;
            }
            titleTextBox.Text = Title;
            contentTextEdit.Text = Content;
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

        void INoteDetailsForm.ShowDialog()
        {
            ShowDialog();
        }
    }
}
