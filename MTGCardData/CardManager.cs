using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BJIoM.MTG.PriceChecker.Model.CardsData.Model;

namespace BJIoM.MTG.PriceChecker.Model.CardsData {
	/// <summary>
	/// Card Manager
	/// </summary>
	public class CardManager {
		private readonly IDictionary<string, Set> _sets;
		private readonly SetDataLoader _dataLoader;

		public CardManager() {
			_sets = new Dictionary<string, Set>();

			if (_dataLoader == null) {
				_dataLoader = new SetDataLoader();
			}
		}
		
		public Task<Card> FindCardAsync(CardSearchFilter searchFilter) =>
			Task.Run(() => FindCard(searchFilter));

		public Card FindCard(CardSearchFilter searchFilter) {
			if (searchFilter.Sets == null || !searchFilter.Sets.Any()) return null;

			if (searchFilter.Sets.Count() == 1) {
				if (!_sets.ContainsKey(searchFilter.Sets.First())) {
					LoadSet(searchFilter.Sets.First());
				}

				return searchFilter.CardNumber != null 
					? _sets[searchFilter.Sets.First()].FindCardByNumber(searchFilter.CardNumber) 
					: _sets[searchFilter.Sets.First()].FindCardByName(searchFilter.CardName, searchFilter.Language);
			}

			if (searchFilter.Sets.Count() <= 1) return null;

			foreach (var setName in searchFilter.Sets) {
				if (!_sets.ContainsKey(setName)) {
					LoadSet(setName);
				}

				var card = _sets[setName].FindCardByName(searchFilter.CardName, searchFilter.Language);
				if (card != null) {
					return card;
				}
			}

			return null;
		}

		public string GetSetName(string setCode) => _sets[setCode].Name;

		public void LoadSet(string setName) {
			var set = _dataLoader.LoadSet(setName);
			_sets.Add(setName, set);
		}
	}
}