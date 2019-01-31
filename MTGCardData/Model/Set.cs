using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace BJIoM.MTG.PriceChecker.Model.CardsData.Model {
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

		public Card FindCardByName(string cardName, string language) {
			foreach (var card in Cards) {
				if (language == "English") {
					if (string.Equals(card.Name, cardName, StringComparison.CurrentCultureIgnoreCase) 
					    || card.Name.Contains(cardName + ',')
					    || card.Name.Contains(cardName + ' ')) {
						return card;
					}
				}
				else {
					if (card.ForeignData.Any(cardForeignData => cardForeignData.Language == language && 
					     string.Equals(cardForeignData.Name, cardName, StringComparison.CurrentCultureIgnoreCase)
						 || cardForeignData.Name.Contains(cardName + ',')
					     || cardForeignData.Name.Contains(cardName + ' '))) {
						return card;
					}
				}
			}

			return null;
		}

		public Card FindCardByNumber(string number) => Cards.FirstOrDefault(card => card.Number == number);
	}
}