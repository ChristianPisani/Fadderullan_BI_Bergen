using System;
using System.Collections.Generic;

using Plugin.Geolocator;
using Plugin.Messaging;

using Xamarin.Forms;

namespace Fadderullan_BI_Bergen {
	public partial class SOSPage : ContentPage {
		public SOSPage() {
			InitializeComponent();
		}

		async void Handle_Clicked(object sender, System.EventArgs e) {
			var SmsTask = MessagingPlugin.SmsMessenger;

			var position = await CrossGeolocator.Current.GetPositionAsync(timeoutMilliseconds: 10000);
			String pos = "Fadderullan SOS knapp test \nhttp://maps.google.com/?q=" + position.Latitude + "," + position.Longitude;

			if (SmsTask.CanSendSms)
				SmsTask.SendSms("+4794438252", pos);
		}
	}
}
