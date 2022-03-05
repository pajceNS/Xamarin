using System;
using System.Collections.Generic;
using System.Text;
using XamarinPrvoPredavanje.Models;

namespace XamarinPrvoPredavanje.ViewModels
{
    internal class NoteItemViewModel : BaseViewModel
    {
        private string _title;
        private string _description;
        public NoteItemViewModel(Note note)
        {
            Note = note;
            Title = note.Title;
            Description = note.Description;
        }
        public Note Note { get; }
        public string Title
        {
            get => _title;
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
    }
}
