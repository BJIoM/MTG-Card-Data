using System.Collections.Generic;
using Newtonsoft.Json;

namespace BJIoM.MTG.CardData.Model {
	public class Set {
		[JsonProperty("baseSetSize")]
		public int BaseSetSize { get; set; }

		[JsonProperty("block")]
		public string Block { get; set; }

		[JsonProperty("boosterV3")]
		public IList<object> BoosterV3 { get; set; }

		[JsonProperty("cards")]
		public IList<Card> Cards { get; set; }

		[JsonProperty("code")]
		public string Code { get; set; }

		[JsonProperty("meta")]
		public Meta Meta { get; set; }

		[JsonProperty("mtgoCode")]
		public string MtgoCode { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("releaseDate")]
		public string ReleaseDate { get; set; }

		[JsonProperty("tcgplayerGroupId")]
		public int TcgplayerGroupId { get; set; }

		[JsonProperty("tokens")]
		public IList<Token> Tokens { get; set; }

		[JsonProperty("totalSetSize")]
		public int TotalSetSize { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}