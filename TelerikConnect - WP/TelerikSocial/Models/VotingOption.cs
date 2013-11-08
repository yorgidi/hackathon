using System;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using GalaSoft.MvvmLight;

namespace TelerikSocial.Models
{
	public class VotingOption : ObservableObject
	{
		public ObservableCollection<string> PeopleJoined { get; private set; }

		public int JoinedCount
		{
			get
			{
				return this.PeopleJoined.Count;
			}
		}

		public string Name { get; private set; }

		public VotingOption(string name)
		{
			this.Name = name;
			this.PeopleJoined = new ObservableCollection<string>();
			this.PeopleJoined.CollectionChanged += this.OnPeopleJoinedCollectionChanged;
		}

		public void RaiseJoinedCountChanged()
		{
			this.RaisePropertyChanged("JoinedCount");
		}

		private void OnPeopleJoinedCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
		{
			this.RaisePropertyChanged("JoinedCount");
		}
	}
}