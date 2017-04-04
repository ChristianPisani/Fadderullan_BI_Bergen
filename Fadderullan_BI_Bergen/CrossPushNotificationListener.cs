using System;
using Newtonsoft.Json.Linq;
using PushNotification.Plugin;
using PushNotification.Plugin.Abstractions;
using Xamarin.Forms;

namespace Fadderullan_BI_Bergen {
	public class CrossPushNotificationListener : IPushNotificationListener {

		public void OnMessage(JObject values, DeviceType deviceType) {
			throw new NotImplementedException();
		}

		public async void OnRegistered(string token, DeviceType deviceType) {
			await _azureNotificationHubService.RegisterNativeAsync(deviceType.ToString());
		}

		public async void OnUnregistered(DeviceType deviceType) {
			await _azureNotificationHubService.UnregisterNativeAsync();
		}

		public void OnError(string message, DeviceType deviceType) {

		}

		public bool ShouldShowNotification() {

			return true;
		}

		IAzureNotificationHubService _azureNotificationHubService;

		public CrossPushNotificationListener() {
			_azureNotificationHubService = DependencyService.Get<IAzureNotificationHubService>();
		}
	}

}
