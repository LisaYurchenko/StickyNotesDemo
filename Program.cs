using StickyNotesDemo.Models;
using StickyNotesDemo.Presenters;

namespace StickyNotesDemo
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            SQLitePCL.Batteries.Init();

            using var context = new NotesContext();
            context.Database.EnsureCreated();

            var notesRepository = new NotesRepository(context);
            var mainView = new NoteForm();

            // Poor Man's Dependency Injection/Pure Dependency Injection, Main() is the Composition Root.
            // See https://github.com/mrts/winforms-mvp/issues/2.
            var presenter = new NotesFormPresenter(mainView, notesRepository);
            mainView.NotesFormPresenter = presenter;
            Application.Run(mainView);
        }
    }
}