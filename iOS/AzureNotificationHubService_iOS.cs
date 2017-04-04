using PushNotification.Plugin;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using XFormsPushNotifications.iOS.Services.Real;
using Fadderullan_BI_Bergen;
using Xamarin.Forms;

[assembly: Dependency(typeof(AzureNotificationHubService_iOS))]
namespace XFormsPushNotifications.iOS.Services.Real {
	public class AzureNotificationHubService_iOS : IAzureNotificationHubService {
		private MobileServiceClient _mobileServiceClient;
		private Push _push;

		public string CurrentDeviceId { get; private set; }

		public AzureNotificationHubService_iOS() {
			_mobileServiceClient = new MobileServiceClient("http://fadderullan-bi-bergen.azurewebsites.net");
			_push = _mobileServiceClient.GetPush();
		}

		public async Task UnregisterNativeAsync() {
			await _push.UnregisterAsync();
		}

		public async Task RegisterNativeAsync(string deviceId) {
			CurrentDeviceId = deviceId;
			await _push.RegisterAsync(deviceId);
		}
	}
}