using Newtonsoft.Json;

namespace BJIoM.MTG.PriceChecker.Model.CardsData.Model {
	public class ForeignData {
		[JsonProperty("language")]
		public string Language { get; set; }

		[JsonProperty("multiverseId")]
		public int MultiverseId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("flavorText")]
		public string FlavorText { get; set; }
	}
}