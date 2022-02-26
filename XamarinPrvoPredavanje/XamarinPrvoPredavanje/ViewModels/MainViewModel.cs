using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinPrvoPredavanje.DataAccess;
using XamarinPrvoPredavanje.Views;

namespace XamarinPrvoPredavanje.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private ObservableCollection<NoteViewModel> _notesSource;
        
        public MainViewModel()
        {
            AddNoteCommand = new Command(OnAddNoteCommand);
            LoadNotes();
        }
        public ObservableCollection<NoteViewModel> NotesSource
        {
            get { return _notesSource; }
            set 
            { 
                _notesSource = value;
                OnPropertyChanged(nameof(NotesSource));
            }
        }

        private void OnAddNoteCommand()
        {
          // Application.Current.MainPage.Navigation.PushModalAsync(new NoteView() { BindingContext = new NoteViewModel() });
        }

        public ICommand AddNoteCommand { get; }
        private void LoadNotes()
        {
            var notes = App.NotesRepository.GetAllNotes().Select(n => new NoteViewModel(n));
            NotesSource = new ObservableCollection<NoteViewModel>(notes);
        }
    }
}
