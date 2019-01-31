using System.Collections.Generic;
using Newtonsoft.Json;

namespace BJIoM.MTG.PriceChecker.Model.CardsData.Model {
	public class Token {
		[JsonProperty("artist")]
		public string Artist { get; set; }

		[JsonProperty("borderColor")]
		public string BorderColor { get; set; }

		[JsonProperty("colorIdentity")]
		public IList<string> ColorIdentity { get; set; }

		[JsonProperty("colors")]
		public IList<string> Colors { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("number")]
		public string Number { get; set; }

		[JsonProperty("power")]
		public string Power { get; set; }

		[JsonProperty("reverseRelated")]
		public IList<string> ReverseRelated { get; set; }

		[JsonProperty("scryfallId")]
		public string ScryfallId { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("toughness")]
		public string Toughness { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("uuid")]
		public string Uuid { get; set; }
	}
}