using FlaUI.Core.AutomationElements;
using FlaUI.UIA3;
using StickyNotesDemoTests.UIAutomation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotesDemoTests.UIAutomation.Factories
{
    public class NoteDetailsFormFactory
    {
        private readonly UIA3Automation _automation;
        private readonly Window _mainWindow;

        public NoteDetailsFormFactory(UIA3Automation automation, Window mainWindow)
        {
            _automation = automation;
            _mainWindow = mainWindow;
        }

        public NoteDetailsForm Create()
        {
            // Logic to instantiate a new NoteDetailsForm.
            // This logic can be more complex if needed, e.g., handling different types of forms.
            return new NoteDetailsForm(_automation, _mainWindow);
        }
    }
}
