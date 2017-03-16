using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Fadderullan_BI_Bergen {
	public partial class MainPage : TabbedPage {
		public MainPage() {
			InitializeComponent();

			NavigationPage.SetHasNavigationBar(this, false);
		}
	}
}
