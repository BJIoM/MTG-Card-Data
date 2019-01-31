using Newtonsoft.Json;

namespace BJIoM.MTG.CardData.Model {
	public class Ruling {
		[JsonProperty("date")]
		public string Date { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}