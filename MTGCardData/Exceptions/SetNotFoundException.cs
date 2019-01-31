using System;

namespace BJIoM.MTG.CardData.Exceptions {
	public class SetNotFoundException : Exception {
		public string SetCode { get; }

		public SetNotFoundException(string setCode) : base($"Set not found. Set Code: {setCode}") {
			SetCode = setCode;
		}
	}
}
