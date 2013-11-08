using System;
using System.Linq;
using System.Windows.Navigation;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Phone.Controls;
using TelerikSocial.ViewModels;

namespace TelerikSocial
{
	public partial class MainPage : PhoneApplicationPage
	{
		private readonly MainViewModel viewModel = SimpleIoc.Default.GetInstance<MainViewModel>();

		public MainPage()
		{
			this.InitializeComponent();

			this.DataContext = this.viewModel;
		}

		// Load data for the ViewModel Items
		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			if (!this.viewModel.IsDataLoaded)
			{
				this.viewModel.LoadData();
			}
		}
	}
}