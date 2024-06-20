using FlaUI.UIA3;

namespace StickyNotesDemoTests.UIAutomation.Singleton
{
    public static class AutomationSingleton
    {
        private static UIA3Automation? _instance;
        private static readonly object _lock = new();

        public static UIA3Automation Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new UIA3Automation();
                    return _instance;
                }
            }
        }
    }
}
