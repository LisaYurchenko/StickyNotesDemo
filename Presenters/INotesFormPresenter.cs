namespace StickyNotesDemo.Presenters
{
    public interface INotesFormPresenter
    {
        string[] CreateNote();
        void FindItems(string text);
        string[]? UpdateNote(string title);
    }
}