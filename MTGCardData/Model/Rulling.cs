using Newtonsoft.Json;

namespace BJIoM.MTG.PriceChecker.Model.CardsData.Model {
	public class Ruling {
		[JsonProperty("date")]
		public string Date { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }
	}
}