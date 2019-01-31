using Newtonsoft.Json;

namespace BJIoM.MTG.CardData.Model {
	public class Legality {
		[JsonProperty("1v1")]
		public string OneVsOne { get; set; }

		[JsonProperty("brawl")]
		public string Brawl { get; set; }

		[JsonProperty("commander")]
		public string Commander { get; set; }

		[JsonProperty("duel")]
		public string Duel { get; set; }

		[JsonProperty("frontier")]
		public string Frontier { get; set; }

		[JsonProperty("future")]
		public string Future { get; set; }

		[JsonProperty("legacy")]
		public string Legacy { get; set; }

		[JsonProperty("modern")]
		public string Modern { get; set; }

		[JsonProperty("standard")]
		public string Standard { get; set; }

		[JsonProperty("vintage")]
		public string Vintage { get; set; }

		[JsonProperty("penny")]
		public string Penny { get; set; }

		[JsonProperty("pauper")]
		public string Pauper { get; set; }
	}
}