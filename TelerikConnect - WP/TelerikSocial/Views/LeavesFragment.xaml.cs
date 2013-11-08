using System;
using System.Linq;
using System.Windows.Controls;
using GalaSoft.MvvmLight.Ioc;
using TelerikSocial.ViewModels;

namespace TelerikSocial.Views
{
	public partial class LeavesFragment : UserControl
	{
		private readonly LeavesViewModel viewModel = SimpleIoc.Default.GetInstance<LeavesViewModel>();

		public LeavesFragment()
		{
			this.InitializeComponent();

			this.DataContext = this.viewModel;
		}
	}
}