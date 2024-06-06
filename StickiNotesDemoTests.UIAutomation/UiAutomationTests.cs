using FlaUI.Core;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Input;
using FlaUI.Core.Tools;
using FlaUI.Core.WindowsAPI;
using FlaUI.UIA3;

namespace StickyNotesDemoTests.UIAutomation
{
    public class UIAutomationTests
    {
        private string _appPath;
        private Application? _app;
        private UIA3Automation _automation;
        private Window _mainWindow;
        private ListBox _listView => _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("notesListView")).AsListBox();
        private AutomationElement _pictureBoxAdd => _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("pictureBoxAdd"));
        AutomationElement _noteDetailsForm => GetNoteDetailsForm();

        [SetUp]
        public void SetUp()
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\..\"));
            _appPath = Path.Combine(solutionDirectory, @"StickyNotesApp\bin\Debug\net6.0-windows\StickyNotesDemo.exe");
            _automation = new UIA3Automation();
            LaunchApp();
        }

        [TearDown]
        public void TearDown()
        {
            ClearListView();
            _app?.Close();
            _automation.Dispose();
        }

        [Test]
        public void ItemIsAdded()
        {
            //2) Click "+" pictureBoxAdd
            _pictureBoxAdd.Click();

            //4) Enter title "Test" titleTextBox
            EnterTitle("Test");

            //5) Click "X" pictureBoxClose on NoteDetailsForm
            CloseNoteDetailsForm();

            //6) Verify "Test" notesListView ListViewSubItem-0 (ListItem) "Test"
            Assert.Multiple(() =>
            {
                Assert.That(_listView.Items.Count(), Is.EqualTo(1));
                Assert.That(_listView.Items[0].Text, Is.EqualTo("Test"));
            });

            //7) Click "X" pictureBoxClose on main form
            CloseApp();

            //8) Re-open an app
            LaunchApp();

            Assert.Multiple(() =>
            {
                Assert.That(_listView.Items.Count(), Is.EqualTo(1));
                Assert.That(_listView.Items[0].Text, Is.EqualTo("Test"));
            });
        }

        [Test]
        public void ItemTitleIsModified()
        {
            //2) Click "+" pictureBoxAdd
            _pictureBoxAdd.Click();

            //4) Enter title "Test" titleTextBox
            EnterTitle("Test");

            //5) Click "X" pictureBoxClose on NoteDetailsForm
            CloseNoteDetailsForm();

            //6) Verify "Test" notesListView ListViewSubItem-0 (ListItem) "Test"

            Assert.Multiple(() =>
            {
                Assert.That(_listView.Items.Count(), Is.EqualTo(1));
                Assert.That(_listView.Items[0].Text, Is.EqualTo("Test"));
            });

            _listView.FindFirstDescendant(x => x.ByName("Test").And(x.ByControlType(FlaUI.Core.Definitions.ControlType.Text)))
                .DoubleClick();

            EnterTitle("Changed");

            //5) Click "X" pictureBoxClose on NoteDetailsForm
            CloseNoteDetailsForm();

            Assert.Multiple(() =>
            {
                Assert.That(_listView.Items.Count(), Is.EqualTo(1));
                Assert.That(_listView.Items[0].Text, Is.EqualTo("Changed"));
            });
            //7) Click "X" pictureBoxClose on main form
            CloseApp();

            //8) Re-open an app
            LaunchApp();

            Assert.Multiple(() =>
            {
                Assert.That(_listView.Items.Count(), Is.EqualTo(1));
                Assert.That(_listView.Items[0].Text, Is.EqualTo("Changed"));
            });
        }

        private void LaunchApp()
        {

            _app = Application.Launch(_appPath);
            _mainWindow = _app.GetMainWindow(_automation);
        }

        private void CloseApp()
        {
            _mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("pictureBoxClose")).Click();
            _app.Close();
        }

        private void CloseNoteDetailsForm()
        {
            _noteDetailsForm.FindFirstDescendant(cf => cf.ByAutomationId("pictureBoxClose")).Click();
        }

        private void EnterTitle(string v)
        {
            var titleTextBox = _noteDetailsForm.FindFirstDescendant(cf => cf.ByAutomationId("titleTextBox")).AsTextBox();
            titleTextBox.Enter(v);
        }

        private AutomationElement GetNoteDetailsForm()
        {
            AutomationElement noteDetailsForm = null;
            Retry.WhileException(() =>
            {
                var appWindows = _mainWindow.ModalWindows;
                noteDetailsForm = appWindows.FirstOrDefault(w => w.AutomationId == "NoteDetailsForm");
                return noteDetailsForm;
            }, TimeSpan.FromSeconds(5));
            return noteDetailsForm;
        }

        private void ClearListView()
        {
            foreach (var item in _listView.Items)
            {
                // Select the item
                item.Focus();
                item.Select();

                // Send the Delete key to the selected item
                Keyboard.Press(VirtualKeyShort.DELETE);
            }
            Retry.WhileFalse(() => _listView.Items.Count() == 0, TimeSpan.FromSeconds(1));
        }
    }
}