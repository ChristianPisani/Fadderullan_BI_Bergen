using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Fadderullan_BI_Bergen {
	public partial class DetailView : ContentPage {
		public String description { get; set; }

		public DetailView() {
			InitializeComponent();

			Description.Text = description;
		}

		public DetailView(String description) {
			InitializeComponent();

			this.description = description;
			Description.Text = description;
		}
	}
}
