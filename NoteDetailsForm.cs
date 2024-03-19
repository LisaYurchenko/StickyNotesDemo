namespace StickyNotesDemo
{
    public partial class NoteDetailsForm : Form
    {
        public NoteDetailsForm()
        {
            InitializeComponent();
        }
        public string Title
        {
            get; set;
        }
        public string Content
        {
            get; set;
        }
        public DateTime CreationDate
        {
            get;
            set;
        }

        private void NoteDetailsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Title = titleTextBox.Text;
            Content = contentTextEdit.Text;
            CreationDate = DateTime.Now;
        }

        private void NoteDetailsForm_Shown(object sender, EventArgs e)
        {
            titleTextBox.Text = Title;
        }
    }
}
