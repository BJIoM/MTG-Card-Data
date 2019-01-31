using System.Linq;
using BJIoM.MTG.CardData;
using BJIoM.MTG.CardData.Exceptions;
using NUnit.Framework;

namespace Tests {
	public class Tests {
		[SetUp]
		public void Setup() {
		}

		[Test]
		public void SetLoadTest() {
			Assert.AreEqual(new SetLoader().LoadSet("xln").Name, "Ixalan");
			Assert.AreEqual(new SetLoader{AllowCaching = false }.LoadSet("dom").Name, "Dominaria");
			Assert.Catch(typeof(SetNotFoundException), () => new SetLoader().LoadSet("ABC"));
		}

		[Test]
		public void CardFindTest() {
			var searcher = new CardSearcher();

			var opt = searcher.FindCard(new SearchFilter().AddSetFilter("DOM")
				.AddCardFilter(card => card.Name == "Opt")).FirstOrDefault();
			Assert.AreEqual(opt.Number, "60");

			var nullCard = searcher.FindCard(new SearchFilter().AddSetFilter("M19")
				.AddCardFilter(card => card.Name == "shock")).FirstOrDefault();
			Assert.AreEqual(nullCard, null);

			var rusCard = searcher.FindCard(new SearchFilter().AddSetFilter("M19")
				.AddCardFilter(card => card.ForeignData.Any(tranlation => tranlation.Name == "Ўок"))).FirstOrDefault();
			Assert.AreEqual(rusCard?.Name, "Shock");
		}
	}
}