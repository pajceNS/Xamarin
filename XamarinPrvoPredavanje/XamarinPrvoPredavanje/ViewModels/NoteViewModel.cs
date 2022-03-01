using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinPrvoPredavanje.Models;

namespace XamarinPrvoPredavanje.ViewModels
{
    internal class NoteViewModel : BaseViewModel
    {
        private Action _action;
        private string _title;
        private string _description;
        private Guid _noteId;
        public bool IsNewNote { get;}
        public NoteViewModel(Action action)
        {
            _action = action;
            IsNewNote = true;
            IsNewNote = false;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
            DeleteNoteCommand = new Command(OnDeleteNoteCommand);
        }
        
        public NoteViewModel(Note note, Action action) : this(action)
        {
            _noteId = note.Id;
            IsNewNote = false;
            IsNewNote = true;
            Title = note.Title;
            Description = note.Description;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
        }

        private void OnSaveNoteCommand()
        {
           var note = new Note(Title, Description);
            App.NotesRepository.AddNote(note);
            _action.Invoke();
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
        //public bool IsNewNote { get; }

        public ICommand SaveNoteCommand { get; }
        public ICommand DeleteNoteCommand { get; }
        public string Title 
        { 
            get=>_title; 
            set
            {
                _title = value;
                OnPropertyChanged(nameof(Title));
            }
        }
        public string Description
        {
            get => _description; 
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }
        private void OnDeleteNoteCommand(object obj)
        {
            App.NotesRepository.DeleteNote(_noteId);
            _action.Invoke();
            Application.Current.MainPage.Navigation.PopModalAsync();
        }
    }
}
