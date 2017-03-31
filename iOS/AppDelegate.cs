using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Newtonsoft.Json.Linq;
using Microsoft.WindowsAzure.MobileServices;
using Microsoft.WindowsAzure.MobileServices.Eventing;

namespace Fadderullan_BI_Bergen.iOS {
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate {


		public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
			global::Xamarin.Forms.Forms.Init();

			Microsoft.WindowsAzure.MobileServices.CurrentPlatform.Init();

			// Register for push notifications.
			UIApplication.SharedApplication.RegisterForRemoteNotificationTypes(
		UIRemoteNotificationType.Alert |
		UIRemoteNotificationType.Badge |
		UIRemoteNotificationType.Sound);


			LoadApplication(new App());

			Xamarin.FormsMaps.Init();


			return base.FinishedLaunching(app, options);
		}

	/*	public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken) {
			Hub = new AzureNotificationHub.AzureNotificationHub(Constants.ConnectionString, Constants.ApplicationURL);


		}
*/
		public override void RegisteredForRemoteNotifications(UIApplication app, NSData deviceToken) {
			// Connection string from your azure dashboard
			var cs = SBConnectionString.CreateListenAccess(
				new NSUrl("sb://yourservicebus-ns.servicebus.windows.net/"),
				"YOUR-KEY");

			// Register our info with Azure
			var hub = new SBNotificationHub(cs, "your-hub-name");
			hub.RegisterNativeAsync(deviceToken, null, err => {
				if (err != null)
					Console.WriteLine("Error: " + err.Description);
				else
					Console.WriteLine("Success");
			});
		}

		/*public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo) {
			ProcessNotification(userInfo, false);
		}*/

		public override void DidReceiveRemoteNotification(UIApplication application,
	 NSDictionary userInfo, Action<UIBackgroundFetchResult> completionHandler) {
			NSDictionary aps = userInfo.ObjectForKey(new NSString("aps")) as NSDictionary;

			string alert = string.Empty;
			if (aps.ContainsKey(new NSString("alert")))
				alert = (aps[new NSString("alert")] as NSString).ToString();

			//show alert
			if (!string.IsNullOrEmpty(alert)) {
				UIAlertView avAlert = new UIAlertView("Notification", alert, null, "OK", null);
				avAlert.Show();
			}
		}



		void ProcessNotification(NSDictionary options, bool fromFinishedLaunching) {
			// Check to see if the dictionary has the aps key.  This is the notification payload you would have sent
			if (null != options && options.ContainsKey(new NSString("aps"))) {
				//Get the aps dictionary
				NSDictionary aps = options.ObjectForKey(new NSString("aps")) as NSDictionary;

				string alert = string.Empty;

				//Extract the alert text
				// NOTE: If you're using the simple alert by just specifying
				// "  aps:{alert:"alert msg here"}  ", this will work fine.
				// But if you're using a complex alert with Localization keys, etc.,
				// your "alert" object from the aps dictionary will be another NSDictionary.
				// Basically the JSON gets dumped right into a NSDictionary,
				// so keep that in mind.
				if (aps.ContainsKey(new NSString("alert")))
					alert = (aps[new NSString("alert")] as NSString).ToString();

				//If this came from the ReceivedRemoteNotification while the app was running,
				// we of course need to manually process things like the sound, badge, and alert.
				if (!fromFinishedLaunching) {
					//Manually show an alert
					if (!string.IsNullOrEmpty(alert)) {
						UIAlertView avAlert = new UIAlertView("Notification", alert, null, "OK", null);
						avAlert.Show();
					}
				}
			}
		}
	}
}
