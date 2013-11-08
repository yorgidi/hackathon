using System;
using System.Linq;
using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;

namespace TelerikSocial.ViewModels
{
	public class CustomViewModelBase : ViewModelBase
	{
		protected override void RaisePropertyChanged([CallerMemberName]
													 string propertyName = null)
		{
			base.RaisePropertyChanged(propertyName);
		}
	}
}