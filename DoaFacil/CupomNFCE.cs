using System;
using System.Text;
using System.Globalization;

namespace DoaFacil
{
	public class CupomNFCE:Cupom
	{
		public override string Data { get { return data; } set { data = ConverteDataHexa(value);}

		}

		public CupomNFCE ()
		{
			Tipo = "NFCe";
		}

		public string ConverteDataHexa(string hexString)
		{
			StringBuilder sb = new StringBuilder();

			for (int i = 0; i < hexString.Length; i += 2)
			{
				string hs = hexString.Substring(i, 2);
				sb.Append(Convert.ToChar(Convert.ToUInt32(hs, 16)));
			}
			DateTime convertedDate = DateTime.Parse(sb.ToString());

			CultureInfo culture = new CultureInfo("pt-BR"); 

			return convertedDate.ToString("d", culture) + " " + convertedDate.ToString("T", culture);
		}
			
	}


}

