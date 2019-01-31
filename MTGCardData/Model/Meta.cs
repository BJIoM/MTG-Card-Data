using Newtonsoft.Json;

namespace BJIoM.MTG.CardData.Model {
	public class Meta {
		[JsonProperty("date")]
		public string Date { get; set; }

		[JsonProperty("version")]
		public string Version { get; set; }
	}
}