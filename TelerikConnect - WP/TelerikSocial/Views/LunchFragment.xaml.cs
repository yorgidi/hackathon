using System;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using TelerikSocial.ViewModels;

namespace TelerikSocial.Views
{
	public partial class LunchFragment : UserControl
	{
		private readonly LunchViewModel viewModel = SimpleIoc.Default.GetInstance<LunchViewModel>();

		public LunchFragment()
		{
			this.InitializeComponent();

			this.DataContext = this.viewModel;
		}
	}
}