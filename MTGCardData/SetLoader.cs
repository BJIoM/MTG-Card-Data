using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using BJIoM.MTG.CardData.Exceptions;
using BJIoM.MTG.CardData.Model;
using Newtonsoft.Json;

namespace BJIoM.MTG.CardData {
	public class SetLoader {
		/// <summary>
		/// Web directory for set's data
		/// </summary>
		public string WebDirectory { get; set; } = "https://mtgjson.com/json";

		/// <summary>
		/// Directory to cache set's data
		/// </summary>
		public string LocalDirectory { get; set; } = "CardData";

		/// <summary>
		/// Allow save set's data to <see cref="LocalDirectory"/>
		/// </summary>
		public bool AllowCaching { get; set; } = true;

		/// <summary>
		/// Load card set
		/// </summary>
		/// <param name="setCode">Set code</param>
		public Set LoadSet(string setCode) {
			if (AllowCaching && _cachedSets.Count == 0) {
				ScanLocalDirectory();
			}

			var setData = _cachedSets.Contains(setCode)
				? LoadSetDataFromLocalStorage(setCode)
				: LoadSetDataFromWebStorage(setCode);

			var set = JsonConvert.DeserializeObject<Set>(setData);

			foreach (var card in set.Cards) {
				card.SetCode = setCode;
			}

			return set;
		}

		private readonly IList<string> _cachedSets = new List<string>();

		private string LoadSetDataFromLocalStorage(string setCode) => File.ReadAllText($"{LocalDirectory}/{setCode}.json");

		private string LoadSetDataFromWebStorage(string setCode) {
			using (var client = new WebClient()) {
				try {
					client.Encoding = Encoding.UTF8;
					var setData = client.DownloadString($"{WebDirectory}/{setCode.ToUpper()}.json");

					if (AllowCaching) {
						File.WriteAllText($"{LocalDirectory}/{setCode}.json", setData);
					}

					return setData;
				} catch (WebException) {
					throw new SetNotFoundException(setCode);
				}
			}
		}

		private void ScanLocalDirectory() {
			if (!Directory.Exists(LocalDirectory)) {
				Directory.CreateDirectory(LocalDirectory);
				return;
			}

			var directory = new DirectoryInfo(LocalDirectory);
			var setsFiles = directory.GetFiles("*.json");
			foreach (var setFile in setsFiles) {
				var setName = Path.GetFileNameWithoutExtension(setFile.Name);
				_cachedSets.Add(setName);
			}
		}
	}
}