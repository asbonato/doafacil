using System;

namespace DoaFacil
{
	abstract public class Cupom
	{
		protected string data;
		public string Chave { get; set; }
	    abstract public string Data { get; set; }
		public string Valor { get; set; }
		public string CPF { get; set; }
		public string Tipo { get; protected set; }
		public string CNPJEntidade { get; set; }

		public Cupom ()
		{
		}

		public bool Doavel(){
			return (CPF == null || CPF.Length == 0);
		}
	}
}

