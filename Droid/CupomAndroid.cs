using System;
using Java.IO;
using Object = Java.Lang.Object;

namespace DoaFacil.Droid
{
	public class CupomAndroid:Object, ISerializable
	{
		public Cupom cupom { get; }

		public CupomAndroid(Cupom c)
		{
			cupom = c;
		}

	}
}

