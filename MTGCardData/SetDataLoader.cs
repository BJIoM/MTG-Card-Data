using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using BJIoM.MTG.PriceChecker.Model.CardsData.Model;
using Newtonsoft.Json;

namespace BJIoM.MTG.PriceChecker.Model.CardsData {
	public class SetDataLoader {
		public string WebDirectory { get; set; } = "https://mtgjson.com/json";
		public string LocalDirectory { get; set; } = "CardData";
		public bool AllowCaching { get; set; } = true;

		private readonly List<string> _localSets = new List<string>();
		
		public Set LoadSet(string setName) {
			if (_localSets.Count == 0) {
				ScanLocalStorage();
			}

			var setData = _localSets.Contains(setName)
				? LoadSetDataFromLocalStorage(setName)
				: LoadSetDataFromWebStorage(setName);

			return JsonConvert.DeserializeObject<Set>(setData);
		}

		private string LoadSetDataFromLocalStorage(string setName) => File.ReadAllText($"{LocalDirectory}/{setName}.json");

		private string LoadSetDataFromWebStorage(string setName) {
			using (var client = new WebClient()) {
				client.Encoding = Encoding.UTF8;
				var setData = client.DownloadString($"{WebDirectory}/{setName.ToUpper()}.json");

				if (AllowCaching) {
					File.WriteAllText($"{LocalDirectory}/{setName}.json", setData);
				}

				return setData;
			}
		}

		private void ScanLocalStorage() {
			if (!AllowCaching) { return; }

			if (!Directory.Exists(LocalDirectory)) {
				Directory.CreateDirectory(LocalDirectory);
			}

			var directory = new DirectoryInfo(LocalDirectory);
			var setsFiles = directory.GetFiles("*.json");
			_localSets.Clear();
			foreach (var setFile in setsFiles) {
				var setName = Path.GetFileNameWithoutExtension(setFile.Name);
				_localSets.Add(setName);
			}
		}
	}
}