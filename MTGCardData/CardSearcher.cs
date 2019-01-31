using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BJIoM.MTG.CardData.Model;

namespace BJIoM.MTG.CardData {
	/// <summary>
	/// Card Searcher
	/// </summary>
	public class CardSearcher {
		/// <summary>
		/// Card Searcher
		/// </summary>
		/// <param name="dataLoader">Data Loader</param>
		public CardSearcher(SetLoader dataLoader = null) {
			_cachedSets = new Dictionary<string, Set>();
			_loader = dataLoader ?? new SetLoader();
		}
		
		/// <summary>
		/// Async find card by filter
		/// </summary>
		/// <param name="filter">Search filter</param>
		/// <returns>Matched cards</returns>
		public Task<IList<Card>> FindCardAsync(SearchFilter filter) =>
			Task.Run(() => FindCard(filter));

		/// <summary>
		/// Find card by filter
		/// </summary>
		/// <param name="filter">Search filter</param>
		/// <returns>Matched cards</returns>
		public IList<Card> FindCard(SearchFilter filter) {
			var result = new List<Card>();

			foreach (var set in filter.SetFilters) {
				if (!_cachedSets.ContainsKey(set)) {
					LoadSet(set);
				}

				result.AddRange(_cachedSets[set].Cards.Where(filter.MatchCard));
			}

			return result;
		}

		/// <summary>
		/// Get set name by set code
		/// </summary>
		/// <param name="setColde">Set code</param>
		public string GetSetName(string setColde) => _cachedSets[setColde].Name;

		private readonly IDictionary<string, Set> _cachedSets;
		private readonly SetLoader _loader;

		private void LoadSet(string setName) {
			var set = _loader.LoadSet(setName);
			_cachedSets.Add(setName, set);
		}
	}
}