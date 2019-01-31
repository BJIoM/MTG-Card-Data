using System.Collections.Generic;

namespace BJIoM.MTG.PriceChecker.Model.CardsData {
	public class CardSearchFilter {
		/// <summary>
		/// Requred card name. If you want to search non-English card you must set <see cref="Language">Language</see> property.
		/// </summary>
		public string CardName { get; set; }

		public string CardNumber { get; set; }

		/// <summary>
		/// Sets to search card.
		/// </summary>
		public IEnumerable<string> Sets { get; set; }

		/// <summary>
		/// Language to search.
		/// </summary>
		public string Language { get; set; } = "English";
	}
}
