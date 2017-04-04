using Xamarin.Forms;
using Microsoft.WindowsAzure.MobileServices;

using PushNotification.Plugin;

namespace Fadderullan_BI_Bergen {
	public partial class App : Application {
		public App() {
			InitializeComponent();

			MainPage = new NavigationPage(new MainPage());
		}

		protected override void OnStart() {
			// Handle when your app starts
			//CrossPushNotification.Current.Register();
		}

		protected override void OnSleep() {
			// Handle when your app sleeps
		}

		protected override void OnResume() {
			// Handle when your app resumes
		}
	}
}
