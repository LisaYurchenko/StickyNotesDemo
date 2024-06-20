
using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using FlaUI.Core.AutomationElements;

namespace StickyNotesDemoTests.UiAutomation.ScreenPlay.Tasks
{
    public class NoteTitle : Performable<string>, IQuestion<string>
    {
        protected override string GetReport(INamed actor)
        {
            return $"{actor.Name} reads the note title.";
        }

        protected override string PerformAs(IPerformer actor)
        {
            var automation = actor.GetAbility<InteractWithStickyNotes>().Automation;
            var mainWindow = actor.GetAbility<InteractWithStickyNotes>().App.GetMainWindow(automation);

            var listView = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("notesListView")).AsListBox();
            var text = listView.Items[0].Text;
            return text;
        }
        public static IQuestion<string> FromTheList() => new NoteTitle();
    }
}

