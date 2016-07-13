using System;
using System.Text;
using System.Globalization;

namespace DoaFacil
{
	public class CupomSAT:Cupom
	{
		public override string Data { get { return data; } set { data = ConverteData(value); }

		}

		public CupomSAT ()
		{
			Tipo = "SAT";
		}

		public string ConverteData(string dataString)
		{
			int ano = Convert.ToInt32 (dataString.Substring (0, 4));
			int mes = Convert.ToInt32 (dataString.Substring (4, 2));
			int dia = Convert.ToInt32 (dataString.Substring (6, 2));
			int hora = Convert.ToInt32 (dataString.Substring (8, 2));
			int minuto = Convert.ToInt32 (dataString.Substring (10, 2));
			int segundo = Convert.ToInt32 (dataString.Substring (12, 2));
			 
		
			DateTime convertedDate = new DateTime (ano, mes, dia, hora, minuto, segundo);

			CultureInfo culture = new CultureInfo("pt-BR"); 

			return convertedDate.ToString("d", culture) + " " + convertedDate.ToString("T", culture);
		}
			
	}
}

