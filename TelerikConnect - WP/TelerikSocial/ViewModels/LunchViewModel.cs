using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Threading;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Ioc;
using TelerikSocial.Models;
using TelerikSocial.Services;

namespace TelerikSocial.ViewModels
{
	public class LunchViewModel : CustomViewModelBase
	{
		private static readonly Random random = new Random();

		private readonly ILunchSchedulingService lunchSchedulingService = SimpleIoc.Default.GetInstance<ILunchSchedulingService>();

		private readonly DispatcherTimer timeLeftTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };

		private readonly int voteDeadline = 12;

		private string selectedTeam;

		public ObservableCollection<string> Teams { get; private set; }

		public ObservableCollection<VotingOption> Venues { get; private set; }

		public RelayCommand<VotingOption> VoteOptionCommand { get; private set; }

		public ObservableCollection<VotingOption> TimeSlots { get; private set; }

		public string SelectedTeam
		{
			get
			{
				return this.selectedTeam;
			}
			set
			{
				if (this.selectedTeam != value)
				{
					this.selectedTeam = value;
					this.RaisePropertyChanged();
					this.RaisePropertyChanged("HasSelectedTeam");
					this.LoadDataForCurrentTeam();
					this.RefreshItemsView();
				}
			}
		}

		public string DecisionText
		{
			get
			{
				var winnerVenues = this.Venues.Where(v => v.JoinedCount == this.TopVenueVoteCount);
				var venueCount = winnerVenues.Count();
				var winnerTimeSlots = this.TimeSlots.Where(t => t.JoinedCount == this.TopTimeSlotCount);
				var timeSlotCount = winnerTimeSlots.Count();
				if (venueCount == 0 || timeSlotCount == 0)
				{
					return "";
				}

				var winnerVenue = venueCount > 1 ? winnerVenues.ElementAt(random.Next(venueCount)) : winnerVenues.First();
				var winnerTimeSlot = timeSlotCount > 1 ? winnerTimeSlots.ElementAt(random.Next(timeSlotCount)) : winnerTimeSlots.First();

				return string.Format("the team has decided!\nvenue: {0}\ntime: {1}", winnerVenue.Name.ToUpper(), winnerTimeSlot.Name);
			}
		}

		public bool HasSelectedTeam
		{
			get
			{
				return !string.IsNullOrEmpty(this.SelectedTeam);
			}
		}

		public int TimeLeft
		{
			get
			{
				var now = DateTime.Now;
				if (now.Hour >= this.voteDeadline)
				{
					return 0;
				}
				var nextLunch = now.Date.AddHours(this.voteDeadline);
				return (int)(nextLunch - now).TotalSeconds;
			}
		}

		public string TimeLeftString
		{
			get
			{
				var timeLeft = this.TimeLeft;
				return string.Format("{0}:{1:00}:{2:00}", timeLeft / 3600, timeLeft / 60 % 60, timeLeft % 60);
			}
		}

		public int TopVenueVoteCount
		{
			get
			{
				return this.Venues.Count == 0 ? 0 : this.Venues.Max(v => v.JoinedCount);
			}
		}

		public int TopTimeSlotCount
		{
			get
			{
				return this.TimeSlots.Count == 0 ? 0 : this.TimeSlots.Max(t => t.JoinedCount);
			}
		}

		public LunchViewModel()
		{
			this.Teams = new ObservableCollection<string>(new[]
			{
				"Icenium",
				"Ice - Mist",
				"Ice - Core",
				"JustCode",
				"JustTrace",
				"Мръсно",
			});

			this.Venues = new ObservableCollection<VotingOption>();
			this.TimeSlots = new ObservableCollection<VotingOption>();

			this.timeLeftTimer.Start();
			this.timeLeftTimer.Tick += this.OnTimerTick;

			this.VoteOptionCommand = new RelayCommand<VotingOption>(this.VoteOption);
		}

		private async void LoadDataForCurrentTeam()
		{
			var venues = await this.lunchSchedulingService.GetVenuesForTeam(this.SelectedTeam);
			var timeSlots = await this.lunchSchedulingService.GetTimeSlotsForTeam(this.SelectedTeam);

			this.Venues.Clear();
			foreach (var venue in venues)
			{
				this.Venues.Add(venue);
			}

			this.TimeSlots.Clear();
			foreach (var timeSlot in timeSlots)
			{
				this.TimeSlots.Add(timeSlot);
			}

			this.RaisePropertyChanged("DecisionText");
		}

		private async void VoteOption(VotingOption option)
		{
			await this.lunchSchedulingService.VoteOption(option);
			this.RefreshItemsView();
		}

		private void RefreshItemsView()
		{
			this.RaisePropertyChanged("TopTimeSlotCount");
			this.RaisePropertyChanged("TopVenueVoteCount");

			foreach (var option in this.Venues)
			{
				option.RaiseJoinedCountChanged();
			}

			foreach (var option in this.TimeSlots)
			{
				option.RaiseJoinedCountChanged();
			}

			this.RaisePropertyChanged("DecisionText");
		}

		private void OnTimerTick(object sender, EventArgs e)
		{
			this.RaisePropertyChanged("TimeLeft");
			this.RaisePropertyChanged("TimeLeftString");
		}
	}
}