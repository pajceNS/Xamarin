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
        private NoteViewModel _selectedNote;
        
        public MainViewModel()
        {
            AddNoteCommand = new Command(OnAddNoteCommand);
            SelectedNoteChangedCommand = new Command(OnSelectedNoteChangedCommand);
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
        private NoteViewModel SelectedNote
        {
            get
            {
                return _selectedNote;
            }
            set
            {
                _selectedNote = value;
                OnPropertyChanged(nameof(SelectedNote));
            }
        }
        public ICommand AddNoteCommand { get; }
        public ICommand SelectedNoteChangedCommand { get; }
        private void LoadNotes()
        {
            var notes = App.NotesRepository.GetAllNotes().Select(n => new NoteViewModel(n, LoadNotes));
            NotesSource = new ObservableCollection<NoteViewModel>(notes);
        }
        private void OnSelectedNoteChangedCommand()
        {
            if (SelectedNote != null)
            {
                Application.Current.MainPage.Navigation.PushModalAsync(new NoteView { BindingContext = SelectedNote });
            }
            SelectedNote = null;
        }
        private void OnAddNoteCommand()
        {
            Application.Current.MainPage.Navigation.PushModalAsync(new NoteView() { BindingContext = new NoteViewModel(() => LoadNotes()) });
        }
    }
}
