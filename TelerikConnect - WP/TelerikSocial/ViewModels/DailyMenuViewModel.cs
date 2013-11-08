using System;
using System.Collections.ObjectModel;
using System.Linq;
using GalaSoft.MvvmLight.Ioc;
using TelerikSocial.Models;
using TelerikSocial.Services;

namespace TelerikSocial.ViewModels
{
	public class DailyMenuViewModel : CustomViewModelBase
	{
		private readonly IDailyMenuService dailyMenuService = SimpleIoc.Default.GetInstance<IDailyMenuService>();

		public ObservableCollection<Group<MenuItem>> Items { get; private set; }

		public DailyMenuViewModel()
		{
			this.Items = new ObservableCollection<Group<MenuItem>>();
			this.LoadMenu();
		}

		private async void LoadMenu()
		{
			var items = await this.dailyMenuService.GetDailyMenu();
			
			foreach (var item in items)
			{
				this.Items.Add(item);	
			}
		}
	}
}