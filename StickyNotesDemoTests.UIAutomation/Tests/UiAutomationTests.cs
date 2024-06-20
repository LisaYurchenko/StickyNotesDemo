using FlaUI.Core;
using FlaUI.UIA3;
using StickyNotesDemoTests.UIAutomation.Facades;
using StickyNotesDemoTests.UIAutomation.Factories;
using StickyNotesDemoTests.UIAutomation.Models;
using StickyNotesDemoTests.UIAutomation.Singleton;

namespace StickyNotesDemoTests.UIAutomation.Tests
{
    public class UIAutomationTests
    {
        private string _appPath;
        private Application? _app;
        private NotesForm _notesForm;
        private NoteDetailsFormFactory? _noteDetailsFormFactory;
        private UIA3Automation _automation;
        private NotesAppFacade _notesAppFacade;

        [SetUp]
        public void SetUp()
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\"));
            _appPath = Path.Combine(solutionDirectory, @"bin\Debug\net8.0-windows\StickyNotesDemo.exe");
            LaunchApp();
            _notesAppFacade = new NotesAppFacade(_notesForm, _noteDetailsFormFactory);
        }

        [TearDown]
        public void TearDown()
        {
            _notesForm.ClearListView();
            _app?.Close();
            _automation.Dispose();
        }

        [Test]
        public void ItemIsAdded()
        {

            // Add a note, enter a title, and close the note details form
            _notesAppFacade.AddNoteWithTitle("Test");

            // Verify the note was added to the list
            VerifyNoteWithTitle("Test");

            // Close and reopen the application
            CloseApp();
            LaunchApp();

            // Verify the note is still present
            VerifyNoteWithTitle("Test");
        }

        [Test]
        public void ItemTitleIsModified()
        {
            // Add a note, enter a title, and close the note details form
            _notesAppFacade.AddNoteWithTitle("Test");

            // Verify the note was added with the title "Test"
            VerifyNoteWithTitle("Test");

            // Open the note, modify the title, and close the note details form
            _notesAppFacade.EditNoteTitle("Test", "Changed");

            // Verify the note title was changed
            VerifyNoteWithTitle("Changed");

            // Close and reopen the application
            CloseApp();
            LaunchApp();

            // Verify the note title is still "Changed"
            VerifyNoteWithTitle("Changed");
        }

        private void LaunchApp()
        {
            _automation = AutomationSingleton.Instance;
            _app = Application.Launch(_appPath);
            _notesForm = new NotesForm(_automation, _app);
            _noteDetailsFormFactory = new NoteDetailsFormFactory(_automation, _notesForm.Instance);
        }

        private void CloseApp()
        {
            _notesForm.PictureBoxClose.Click();
            _app.Close();
        }

        public void VerifyNoteWithTitle(string title)
        {
            Assert.Multiple(() =>
            {
                Assert.That(_notesForm.NotesListView.Items.Count(), Is.EqualTo(1));
                Assert.That(_notesForm.NotesListView.Items[0].Text, Is.EqualTo(title));
            });
        }


    }
}