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
        public NoteViewModel(Action action)
        {
            _action = action;
        }
        public NoteViewModel(Note note)
        {
            Title = note.Title;
            Description = note.Description;
            SaveNoteCommand = new Command(OnSaveNoteCommand);
        }

        private void OnSaveNoteCommand()
        {
           var note = new Note(Title, Description);
            App.NotesRepository.AddNote(note);
        }

        public ICommand SaveNoteCommand { get; }
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
                Application.Current.MainPage.Navigation.PopModalAsync();
            }
        }
    }
}
