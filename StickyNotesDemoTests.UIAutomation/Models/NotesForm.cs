using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;
using StickyNotesDemoTests.UIAutomation.Factories;

namespace StickyNotesDemoTests.UIAutomation.Models
{
    public class NotesForm
    {
        private readonly UIA3Automation _automation;
        public readonly Window Instance;
        private NoteDetailsFormFactory _noteDetailsFormFactory;

        public NotesForm(UIA3Automation automation, Application app)
        {
            _automation = automation;
            Instance = app.GetMainWindow(automation);
            _noteDetailsFormFactory = new NoteDetailsFormFactory(automation, Instance);
        }

        public ListBox NotesListView => Instance.FindFirstDescendant(cf => cf.ByAutomationId("notesListView")).AsListBox();
        public AutomationElement PictureBoxAdd => Instance.FindFirstDescendant(cf => cf.ByAutomationId("pictureBoxAdd"));
        public AutomationElement PictureBoxClose => Instance.FindFirstDescendant(cf => cf.ByAutomationId("pictureBoxClose"));

        public NoteDetailsForm AddNote()
        {
            PictureBoxAdd.Click();
            return _noteDetailsFormFactory.Create();
        }

        public NoteDetailsForm OpenNoteWithTitle(string title)
        {
            NotesListView.FindFirstDescendant(x => x.ByName(title).And(x.ByControlType(FlaUI.Core.Definitions.ControlType.Text)))
                .DoubleClick();
            return _noteDetailsFormFactory.Create();
        }

        public NotesForm Close()
        {
            PictureBoxClose.Click();
            return this;
        }

        public NotesForm ClearListView()
        {
            foreach (var item in NotesListView.Items)
            {
                // Select the item
                item.Focus();
                item.Select();

                // Send the Delete key to the selected item
                Keyboard.Press(VirtualKeyShort.DELETE);
            }
            Retry.WhileFalse(() => NotesListView.Items.Count() == 0, TimeSpan.FromSeconds(1));
            return this;
        }
    }
}
