using CSF.Screenplay.Actors;
using CSF.Screenplay.Performables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotesDemoTests.UiAutomation.ScreenPlay.Tasks
{
    public class CloseTheApp : Performable
    {
        protected override void PerformAs(IPerformer actor)
        {
            var automation = actor.GetAbility<InteractWithStickyNotes>().Automation;
            var mainWindow = actor.GetAbility<InteractWithStickyNotes>().App.GetMainWindow(automation);
            var addNoteButton = mainWindow.FindFirstDescendant(cf => cf.ByAutomationId("pictureBoxClose"));
            addNoteButton.Click();
        }
    }
}
