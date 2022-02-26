using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XamarinPrvoPredavanje.Models;

namespace XamarinPrvoPredavanje.DataAccess
{
    internal class NotesRepository
    {
        private List<Note> _notes = new List<Note>();
        public NotesRepository()
        {
            _notes.Add(new Note("this is short title", "very short description"));
            _notes.Add(new Note("this is even shorter title", "short description"));
        }
        public void AddNote(Note note)
        {
            _notes.Add(note);
        }
        public void DeleteNote(Guid id)
        {
            _notes = _notes.Where(note => note.Id !=id).ToList();
        }
        public IEnumerable<Note> GetAllNotes()
        {
            return new List<Note>(_notes);
        }
    }
}
