using System;
using System.Collections.Generic;
using System.Linq;
using BJIoM.MTG.CardData.Model;

namespace BJIoM.MTG.CardData {
	/// <summary>
	/// Search filter
	/// </summary>
	public class SearchFilter {
		/// <summary>
		/// Adds set filter
		/// </summary>
		/// <param name="setCode"></param>
		/// <returns></returns>
		public SearchFilter AddSetFilter(string setCode) {
			SetFilters.Add(setCode);
			return this;
		}

		/// <summary>
		/// Adds card filter
		/// </summary>
		/// <param name="filter"></param>
		/// <returns></returns>
		public SearchFilter AddCardFilter(Func<Card, bool> filter) {
			_cardFilters.Add(filter);
			return this;
		}

		/// <summary>
		/// Checks card to match all filters
		/// </summary>
		/// <param name="card">Card to check</param>
		internal bool MatchCard(Card card) => _cardFilters.All(filter => filter.Invoke(card));

		public IList<string> SetFilters { get; } = new List<string>();
		private readonly IList<Func<Card, bool>> _cardFilters = new List<Func<Card, bool>>();
	}
}