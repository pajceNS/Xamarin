using Microsoft.Extensions.DependencyInjection;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinPrvoPredavanje.DataAccess;
using XamarinPrvoPredavanje.Services;
using XamarinPrvoPredavanje.ViewModels;

namespace XamarinPrvoPredavanje
{
    public partial class App : Application
    {
        private static IServiceProvider _serviceProvider;
        private static ViewModelLocator _viewLocator;
        public App(Action<ServiceCollection> action)
        {
            InitializeComponent();
            SetupServices(action);
            MainPage = new NavigationPage(new MainPage { BindingContext = Locator.MainViewModel});           
        }
        internal static ViewModelLocator Locator => _viewLocator ?? (_viewLocator = new ViewModelLocator(_serviceProvider));
        //if locator null vrati new model ??
        /*internal static ViewModelLocator Locator
        {
            get
            {
                if(_viewLocator == null)
                {
                    _viewLocator = new ViewModelLocator(_serviceProvider);
                }
                return _viewLocator;
            }
        }*/
        protected override void OnStart()
        {
        }
        protected override void OnSleep()
        {
        }
        protected override void OnResume()
        {
        }
        private void SetupServices(Action <ServiceCollection> action)
        {
            var serviceCollection = new ServiceCollection();
            action?.Invoke(serviceCollection);
            serviceCollection.AddTransient<MainViewModel>();
            serviceCollection.AddTransient<NoteEditorViewModel>();
            serviceCollection.AddSingleton<INotesRepository, NotesRepository>();
            serviceCollection.AddSingleton<INavigationService, NavigationService>();
            _serviceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
