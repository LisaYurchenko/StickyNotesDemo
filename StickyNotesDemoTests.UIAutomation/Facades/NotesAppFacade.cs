using StickyNotesDemoTests.UIAutomation.Factories;
using StickyNotesDemoTests.UIAutomation.Models;

namespace StickyNotesDemoTests.UIAutomation.Facades
{
    public class NotesAppFacade
    {
        private readonly NotesForm _notesForm;
        private readonly NoteDetailsFormFactory _noteDetailsFormFactory;

        public NotesAppFacade(NotesForm notesForm, NoteDetailsFormFactory noteDetailsFormFactory)
        {
            _notesForm = notesForm;
            _noteDetailsFormFactory = noteDetailsFormFactory;
        }

        public void AddNoteWithTitle(string title)
        {
            var noteDetailsForm = _notesForm.AddNote();
            noteDetailsForm.EnterTitle(title).Close();
        }

        public void EditNoteTitle(string originalTitle, string newTitle)
        {
            var noteDetailsForm = _notesForm.OpenNoteWithTitle(originalTitle);
            noteDetailsForm.EnterTitle(newTitle).Close();
        }
    }
}
