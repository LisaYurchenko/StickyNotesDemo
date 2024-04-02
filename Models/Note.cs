namespace StickyNotesDemo.Models
{
    public class Note
    {
        private DateTime _creationDate;
        private readonly Guid _id = Guid.NewGuid();
        public Note(string title = "", string content = "")
        {
            Title = title;
            Content = content;
        }
        public Guid Id => _id;
        internal string Title
        {
            get; set;
        }
        internal string Content
        {
            get; set;
        }

        internal DateTime CreationDate
        {
            get
            {
                if (_creationDate == default)
                {
                    _creationDate = DateTime.Now;
                }
                return _creationDate;
            }
        }
    }
}
