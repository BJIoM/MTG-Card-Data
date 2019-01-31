using System.Collections.Generic;
using Newtonsoft.Json;

namespace BJIoM.MTG.CardData.Model {
	public class Card {
		[JsonProperty("artist")]
		public string Artist { get; set; }

		[JsonProperty("borderColor")]
		public string BorderColor { get; set; }

		[JsonProperty("colorIdentity")]
		public IList<string> ColorIdentity { get; set; }

		[JsonProperty("colors")]
		public IList<string> Colors { get; set; }

		[JsonProperty("convertedManaCost")]
		public double ConvertedManaCost { get; set; }

		[JsonProperty("foreignData")]
		public IList<ForeignData> ForeignData { get; set; }

		[JsonProperty("frameVersion")]
		public string FrameVersion { get; set; }

		[JsonProperty("hasFoil")]
		public bool HasFoil { get; set; }

		[JsonProperty("hasNonFoil")]
		public bool HasNonFoil { get; set; }

		[JsonProperty("layout")]
		public string Layout { get; set; }

		[JsonProperty("legalities")]
		public Legality Legalities { get; set; }

		[JsonProperty("manaCost")]
		public string ManaCost { get; set; }

		[JsonProperty("multiverseId")]
		public int MultiverseId { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("number")]
		public string Number { get; set; }

		[JsonProperty("originalText")]
		public string OriginalText { get; set; }

		[JsonProperty("originalType")]
		public string OriginalType { get; set; }

		[JsonProperty("power")]
		public string Power { get; set; }

		[JsonProperty("printings")]
		public IList<string> Printings { get; set; }

		[JsonProperty("rarity")]
		public string Rarity { get; set; }

		[JsonProperty("rulings")]
		public IList<Ruling> Rulings { get; set; }

		[JsonProperty("scryfallId")]
		public string ScryfallId { get; set; }

		[JsonProperty("subtypes")]
		public IList<string> Subtypes { get; set; }

		[JsonProperty("supertypes")]
		public IList<string> Supertypes { get; set; }

		[JsonProperty("tcgplayerProductId")]
		public int TcgplayerProductId { get; set; }

		[JsonProperty("text")]
		public string Text { get; set; }

		[JsonProperty("toughness")]
		public string Toughness { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("types")]
		public IList<string> Types { get; set; }

		[JsonProperty("uuid")]
		public string Uuid { get; set; }

		[JsonProperty("flavorText")]
		public string FlavorText { get; set; }

		[JsonProperty("watermark")]
		public string Watermark { get; set; }

		[JsonProperty("faceConvertedManaCost")]
		public double? FaceConvertedManaCost { get; set; }

		[JsonProperty("frameEffect")]
		public string FrameEffect { get; set; }

		[JsonProperty("names")]
		public IList<string> Names { get; set; }

		[JsonProperty("side")]
		public string Side { get; set; }

		[JsonProperty("loyalty")]
		public string Loyalty { get; set; }

		[JsonProperty("variations")]
		public IList<string> Variations { get; set; }

		[JsonProperty("starter")]
		public bool? Starter { get; set; }
		
		public string SetCode { get; set; }
	}
}