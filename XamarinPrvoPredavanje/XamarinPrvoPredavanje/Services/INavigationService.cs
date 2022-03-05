using XamarinPrvoPredavanje.Models;

namespace XamarinPrvoPredavanje.Services
{
    internal interface INavigationService
    {
        void NavigateToNoteEditor(Note note);
        void NavigateToNewNoteEditor();
        void GoBack();
    }
}