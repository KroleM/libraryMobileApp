using LibraryMobile.Services;
using LibraryMobile.Views;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryMobile
{
	public partial class App : Application
	{

		public App()
		{
			InitializeComponent();

			DependencyService.Register<AuthorDataStore>();
			DependencyService.Register<BookDataStore>();
			DependencyService.Register<CategoryDataStore>();
			DependencyService.Register<PublisherDataStore>();
			DependencyService.Register<ReaderDataStore>();
			DependencyService.Register<ReaderBookDataStore>();
			DependencyService.Register<ReaderBookScoreDataStore>();
			MainPage = new AppShell();
		}

		protected override void OnStart()
		{
		}

		protected override void OnSleep()
		{
		}

		protected override void OnResume()
		{
		}
	}
}
