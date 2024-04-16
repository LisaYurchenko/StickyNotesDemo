namespace StickyNotesDemo.Models
{
    public class Note
    {
        private DateTime _creationDate;
        private readonly Guid _id = Guid.NewGuid();

        public Note()
        {
        }

        public Note(string title = "", string content = "")
        {
            Title = title;
            Content = content;
        }

        public Guid Id => _id;

        public string Title
        {
            get; set;
        } = string.Empty;

        public string Content
        {
            get; set;
        } = string.Empty;

        public DateTime CreationDate
        {
            get
            {
                if (_creationDate == default)
                {
                    _creationDate = DateTime.Now;
                }
                return _creationDate;
            }
            set
            {
                _creationDate = value;
            }
        }
    }
}
