using CSF.Screenplay.Abilities;
using FlaUI.Core;
using FlaUI.UIA3;

public class InteractWithStickyNotes : Ability
{
    public Application App
    {
        get; private set;
    }
    public UIA3Automation Automation
    {
        get; private set;
    }

    public InteractWithStickyNotes(Application app, UIA3Automation automation)
    {
        App = app;
        Automation = automation;
    }

    public static InteractWithStickyNotes With(Application app, UIA3Automation automation)
    {
        return new InteractWithStickyNotes(app, automation);
    }
}