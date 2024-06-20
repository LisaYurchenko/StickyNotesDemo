using CSF.Screenplay.NUnit;
using CSF.Screenplay;
using FlaUI.UIA3;
using FlaUI.Core;
using static CSF.Screenplay.StepComposer;
using StickyNotesDemoTests.UiAutomation.ScreenPlay.Tasks;

[TestFixture]
[Description("Users should be able to add notes via the application")]
public class UsersCanAddNotes
{
    private string _appPath;
    private Application? _app;
    private UIA3Automation _automation;

    [SetUp]
    public void SetUp()
    {
        var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
        string solutionDirectory = Path.GetFullPath(Path.Combine(currentDirectory, @"..\..\..\..\"));
        _appPath = Path.Combine(solutionDirectory, @"bin\Debug\net8.0-windows\StickyNotesDemo.exe");
        _automation = new UIA3Automation();
        _app = Application.Launch(_appPath);
    }

    [Test, Screenplay]
    [Description("Lisa Should see a new title in the list when adds a new note.")]
    public void LisaShouldSeeANewTitleInTheListWhenAddsANewNote(ICast cast)
    {
        var lisa = cast.Get("Lisa");
        lisa.IsAbleTo(InteractWithStickyNotes.With(_app, _automation));    
        When(lisa).AttemptsTo(AddNote.WithContent("Test"));
        var text = Then(lisa).ShouldRead(NoteTitle.FromTheList());
        Assert.That(text, Is.EqualTo("Test"));

        Then(lisa).Should(new CloseTheApp());
    }

    [TearDown]
    public void TearDown()
    {
        _app.Close();
        _automation.Dispose();
    }
}