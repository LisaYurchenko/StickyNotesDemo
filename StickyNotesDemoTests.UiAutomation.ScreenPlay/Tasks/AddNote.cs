using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using FlaUI.Core.AutomationElements;
using FlaUI.Core.Tools;

public class AddNote : Performable
{
    private readonly string _noteContent;

    public AddNote(string noteContent)
    {
        _noteContent = noteContent;
    }

    public static AddNote WithContent(string noteContent)
    {
        return new AddNote(noteContent);
    }

    protected override void PerformAs(IPerformer actor)
    {
        var automation = actor.GetAbility<InteractWithStickyNotes>().Automation;
        var mainWindow = actor.GetAbility<InteractWithStickyNotes>().App.GetMainWindow(automation);
        var addNoteButton = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("pictureBoxAdd"));
        addNoteButton.Click();

        AutomationElement noteDetailsForm = null;
        Retry.WhileNull(() =>
        {
            var appWindows = mainWindow.ModalWindows;
            noteDetailsForm = appWindows.FirstOrDefault(w => w.AutomationId == "NoteDetailsForm");
            return noteDetailsForm;
        }, TimeSpan.FromSeconds(30));

        var noteTextBox = noteDetailsForm.FindFirstDescendant(cf => cf.ByAutomationId("titleTextBox")).AsTextBox();
        noteTextBox.Enter(_noteContent);

        noteDetailsForm.FindFirstDescendant(cf => cf.ByAutomationId("pictureBoxClose")).Click();
    }
}
