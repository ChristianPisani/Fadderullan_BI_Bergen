using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Fadderullan_BI_Bergen {
	public partial class EventsPage : ContentPage {
		ObservableCollection<Event> events = new ObservableCollection<Event>();

		public EventsPage() { 
			InitializeComponent();

			Events.ItemsSource = events;

			Event e = new Event("Togafest", DateTime.Today);
			e.description = "Reis tilbake i tid med årets feteste togafest!";
			Events.SetBinding(TextCell.TextProperty, e.name);


			events.Add(e);
			e = new Event("Bar til bar", DateTime.Today);
			e.description = "Opplev hva bergens uteliv har å tilby";
			events.Add(e);
			e = new Event("Mer ting", DateTime.Today);
			e.description = "Mer";
			events.Add(e);
		}

		async void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e) {
			Event ev = (Event)Events.SelectedItem;
			String detail = ev.description;

			DetailView dt = new DetailView(detail);
			Navigation.PushAsync(dt);
		}
	}
}
