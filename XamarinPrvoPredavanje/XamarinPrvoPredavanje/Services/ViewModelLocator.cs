using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using XamarinPrvoPredavanje.ViewModels;

namespace XamarinPrvoPredavanje.Services
{
    internal class ViewModelLocator
    {
        private readonly IServiceProvider _serviceProvider;
        public ViewModelLocator(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public MainViewModel MainViewModel => _serviceProvider.GetService<MainViewModel>();

        public NoteEditorViewModel NoteEditorViewModel => _serviceProvider.GetService<NoteEditorViewModel>();
    }
}
