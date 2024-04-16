
using Microsoft.EntityFrameworkCore;

namespace StickyNotesDemo.Models
{
    public interface INotesContext
    {
        DbSet<Note> Notes
        {
            get;
            set;
        }
    }
}