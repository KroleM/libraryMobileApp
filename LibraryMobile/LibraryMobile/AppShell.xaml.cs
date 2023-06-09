using LibraryMobile.ViewModels;
using LibraryMobile.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace LibraryMobile
{
	public partial class AppShell : Xamarin.Forms.Shell
	{
		public AppShell()
		{
			InitializeComponent();
			Routing.RegisterRoute(nameof(AboutPage), typeof(AboutPage));
		}

		private async void OnMenuItemClicked(object sender, EventArgs e)
		{
			await Shell.Current.GoToAsync("//LoginPage");
		}
	}
}
