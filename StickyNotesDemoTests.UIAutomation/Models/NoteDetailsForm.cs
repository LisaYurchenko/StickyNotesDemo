using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;
using FlaUI.UIA3;

namespace StickyNotesDemoTests.UIAutomation.Models
{
    public class NoteDetailsForm
    {
        private readonly UIA3Automation _automation;
        private readonly AutomationElement _form;

        public NoteDetailsForm(UIA3Automation automation, Window mainWindow)
        {
            _automation = automation;
            _form = GetNoteDetailsForm(mainWindow);
        }

        public NoteDetailsForm EnterTitle(string title)
        {
            var titleTextBox = _form.FindFirstDescendant(cf => cf.ByAutomationId("titleTextBox")).AsTextBox();
            titleTextBox.Enter(title);
            return this;
        }

        public NotesForm Close()
        {
            _form.FindFirstDescendant(cf => cf.ByAutomationId("pictureBoxClose")).Click();
            return null;
        }

        private AutomationElement GetNoteDetailsForm(Window mainWindow)
        {
            AutomationElement noteDetailsForm = null;
            Retry.WhileNull(() =>
            {
                var appWindows = mainWindow.ModalWindows;
                noteDetailsForm = appWindows.FirstOrDefault(w => w.AutomationId == "NoteDetailsForm");
                return noteDetailsForm;
            }, TimeSpan.FromSeconds(30));
            return noteDetailsForm;
        }
    }
}
