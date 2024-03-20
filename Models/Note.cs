namespace StickyNotesDemo.Models
{
    internal class Note
    {
        private DateTime _creationDate;
        internal Note(string title = "", string content = "")
        {
            Title = title;
            Content = content;
        }
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
