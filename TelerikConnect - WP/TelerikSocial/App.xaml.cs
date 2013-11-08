using GalaSoft.MvvmLight.Ioc;
using Microsoft.Phone.Controls;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Navigation;
using Microsoft.Practices.ServiceLocation;
using TelerikSocial.Resources;
using TelerikSocial.Services;
using TelerikSocial.Services.Implementation;
using TelerikSocial.ViewModels;

namespace TelerikSocial
{
	public partial class App : Application
	{
		public static PhoneApplicationFrame RootFrame { get; private set; }

		public App()
		{
			this.UnhandledException += this.Application_UnhandledException;

			this.SetupContainer();
			this.InitializeComponent();
			this.InitializePhoneApplication();
			this.InitializeLanguage();
		}

		private void SetupContainer()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<DailyMenuViewModel>();
			SimpleIoc.Default.Register<LeavesViewModel>();
			SimpleIoc.Default.Register<LunchViewModel>();

			SimpleIoc.Default.Register<IUserService, UserService>();
			SimpleIoc.Default.Register<ILunchSchedulingService, LunchSchedulingService>();
			SimpleIoc.Default.Register<IDailyMenuService, DailyMenuService>();
		}

		private void Application_UnhandledException(object sender, ApplicationUnhandledExceptionEventArgs e)
		{
			if (!Debugger.IsAttached)
			{
				e.Handled = true;
			}
		}

		#region Phone application initialization

		private bool phoneApplicationInitialized = false;

		private void InitializePhoneApplication()
		{
			if (this.phoneApplicationInitialized)
			{
				return;
			}

			RootFrame = new PhoneApplicationFrame();
			RootFrame.Navigated += this.CompleteInitializePhoneApplication;
			RootFrame.Navigated += this.CheckForResetNavigation;
			this.phoneApplicationInitialized = true;
		}

		private void CompleteInitializePhoneApplication(object sender, NavigationEventArgs e)
		{
			if (this.RootVisual != RootFrame)
			{
				this.RootVisual = RootFrame;
			}

			RootFrame.Navigated -= this.CompleteInitializePhoneApplication;
		}

		private void CheckForResetNavigation(object sender, NavigationEventArgs e)
		{
			if (e.NavigationMode == NavigationMode.Reset)
			{
				RootFrame.Navigated += this.ClearBackStackAfterReset;
			}
		}

		private void ClearBackStackAfterReset(object sender, NavigationEventArgs e)
		{
			RootFrame.Navigated -= this.ClearBackStackAfterReset;

			if (e.NavigationMode != NavigationMode.New && e.NavigationMode != NavigationMode.Refresh)
			{
				return;
			}

			while (RootFrame.RemoveBackEntry() != null)
			{
			}
		}

		#endregion

		private void InitializeLanguage()
		{
			try
			{
				RootFrame.Language = XmlLanguage.GetLanguage(AppResources.ResourceLanguage);
				var flow = (FlowDirection)Enum.Parse(typeof(FlowDirection), AppResources.ResourceFlowDirection);
				RootFrame.FlowDirection = flow;
			}
			catch
			{
			}
		}
	}
}