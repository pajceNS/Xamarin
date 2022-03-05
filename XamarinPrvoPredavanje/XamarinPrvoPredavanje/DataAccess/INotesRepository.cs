using System;
using System.Collections.Generic;
using XamarinPrvoPredavanje.Models;

namespace XamarinPrvoPredavanje.DataAccess
{
    internal interface INotesRepository
    {
        void AddNote(Note note);
        void DeleteNote(Guid id);
        IEnumerable<Note> GetAllNotes();
    }
}