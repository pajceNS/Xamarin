using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using XamarinPrvoPredavanje.DataAccess;
using XamarinPrvoPredavanje.Services;
using XamarinPrvoPredavanje.Views;

namespace XamarinPrvoPredavanje.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
        private readonly INotesRepository _notesRepository;
        private readonly INavigationService _navigationService;
        private ObservableCollection<NoteItemViewModel> _notesSource;
        private NoteItemViewModel _selectedNote;
        
        public MainViewModel(INotesRepository notesRepository, INavigationService navigationService)
        {
            _notesRepository = notesRepository;
            _navigationService = navigationService;
            AddNoteCommand = new Command(OnAddNoteCommand);
            SelectedNoteChangedCommand = new Command(OnSelectedNoteChangedCommand);
            LoadNotes();
        }
        public ObservableCollection<NoteItemViewModel> NotesSource
        {
            get { return _notesSource; }
            set 
            { 
                _notesSource = value;
                OnPropertyChanged(nameof(NotesSource));
            }
        }
        public NoteItemViewModel SelectedNote
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
        public void LoadNotes()
        {
            var notes = _notesRepository.GetAllNotes().Select(n => new NoteItemViewModel(n));
            NotesSource = new ObservableCollection<NoteItemViewModel>(notes);
        }
        private void OnSelectedNoteChangedCommand()
        {
            if (SelectedNote != null)
            {
                _navigationService.NavigateToNoteEditor(SelectedNote.Note);
            }
            SelectedNote = null;
        }
        private void OnAddNoteCommand()
        {
            _navigationService.NavigateToNewNoteEditor();
        }
    }
}
