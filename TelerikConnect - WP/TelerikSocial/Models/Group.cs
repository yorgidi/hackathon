using System;
using System.Collections.Generic;
using System.Linq;

namespace TelerikSocial.Models
{
	public class Group<T> : List<T>
	{
		public Group(IEnumerable<T> items) : base(items)
		{
		}

		public override bool Equals(object obj)
		{
			var that = obj as Group<T>;

			return (that != null) && (this.Title.Equals(that.Title));
		}

		public string Title { get; set; }

		public string Color { get; set; }
	}
}