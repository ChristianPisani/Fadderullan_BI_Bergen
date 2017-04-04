using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;

using Newtonsoft.Json.Linq;

using PushNotification.Plugin;

namespace Fadderullan_BI_Bergen.iOS {
	[Register("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate {



		public override bool FinishedLaunching(UIApplication app, NSDictionary options) {
			global::Xamarin.Forms.Forms.Init();

			CrossPushNotification.Initialize<CrossPushNotificationListener>();

			LoadApplication(new App());

			Xamarin.FormsMaps.Init();



			return base.FinishedLaunching(app, options);
		}


		public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error) {
			if (CrossPushNotification.Current is IPushNotificationHandler) {
				((IPushNotificationHandler)CrossPushNotification.Current).OnErrorReceived(error);
			}
		}

		public override void RegisteredForRemoteNotifications(UIApplication application, NSData deviceToken) {
			if (CrossPushNotification.Current is IPushNotificationHandler) {
				((IPushNotificationHandler)CrossPushNotification.Current).OnRegisteredSuccess(deviceToken);
			}
		}

		public override void DidRegisterUserNotificationSettings(UIApplication application, UIUserNotificationSettings notificationSettings) {
			application.RegisterForRemoteNotifications();
		}

		public void DidReceiveRemoteNotification(UIApplication application, NSDictionary userInfo, Action completionHandler) {
			if (CrossPushNotification.Current is IPushNotificationHandler) {
				((IPushNotificationHandler)CrossPushNotification.Current).OnMessageReceived(userInfo);
			}
		}

		public override void ReceivedRemoteNotification(UIApplication application, NSDictionary userInfo) {
			if (CrossPushNotification.Current is IPushNotificationHandler) {
				((IPushNotificationHandler)CrossPushNotification.Current).OnMessageReceived(userInfo);
			}
		}

	}
}
