using Newtonsoft.Json;

namespace BJIoM.MTG.PriceChecker.Model.CardsData.Model {
	public class Meta {
		[JsonProperty("date")]
		public string Date { get; set; }

		[JsonProperty("version")]
		public string Version { get; set; }
	}
}