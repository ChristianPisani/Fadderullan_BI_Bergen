using System;
namespace Fadderullan_BI_Bergen {
	public class Event {
		public String name { get; set; }
		public DateTime date { get; set; }
		public String description { get; set; }

		public Event() {
			this.name = "";
			this.date = DateTime.Today;
		}

		public Event(String name, DateTime date) {
			this.name = name;
			this.date = date;
		}

		public override String ToString() {
			return name;
		}
	}
}
