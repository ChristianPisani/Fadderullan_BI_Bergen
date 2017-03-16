using System;
namespace Fadderullan_BI_Bergen {
	public class FadderProfil {
		public String navn;
		public String tlf;

		public FadderProfil() {
			this.navn = "";
			this.tlf = "";
		}

		public FadderProfil(String navn, String tlf) {
			this.navn = navn;
			this.tlf = tlf;
		}


	}
}
