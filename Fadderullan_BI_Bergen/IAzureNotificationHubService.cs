using System;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;


namespace Fadderullan_BI_Bergen {
	public interface IAzureNotificationHubService {
		Task RegisterNativeAsync(string deviceId);
		Task UnregisterNativeAsync();
	}
}
