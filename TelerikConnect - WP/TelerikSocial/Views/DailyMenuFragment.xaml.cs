using System;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using TelerikSocial.ViewModels;

namespace TelerikSocial.Views
{
	public partial class DailyMenuFragment : UserControl
	{
		private readonly DailyMenuViewModel viewModel = SimpleIoc.Default.GetInstance<DailyMenuViewModel>();

		public DailyMenuFragment()
		{
			this.InitializeComponent();

			this.DataContext = this.viewModel;
		}
	}
}