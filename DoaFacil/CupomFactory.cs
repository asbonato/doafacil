using System;

namespace DoaFacil
{
	public class CupomFactory
	{
		public static Cupom cupom (string chave)
		{
			try {
				if (chave.Contains ("nfce.fazenda.sp.gov.br")) {
					const int CHAVE = 0;
					const int CPF = 3;
					const int DATA = 4;
					const int VALOR = 5;

					int[] inicio = new int [10];
					int[] fim = new int [10];
					int k = 0;

					for (int i = 0; i < chave.Length && k < inicio.Length; i++) {
					
						if (chave.Substring (i, 1).Equals ("=")) {
							inicio [k] = i + 1;
						}
						if (chave.Substring (i, 1).Equals ("&")) {
							fim [k++] = i - 1;
						}
					}
					fim [k] = chave.Length - 1;

					Cupom cupom = new CupomNFCE ();
					cupom.Chave = chave.Substring (inicio [CHAVE], 1 + fim [CHAVE] - inicio [CHAVE]);
					cupom.CPF = chave.Substring (inicio [CPF], 1 + fim [CPF] - inicio [CPF]);
					cupom.Data = chave.Substring (inicio [DATA], 1 + fim [DATA] - inicio [DATA]);
					cupom.Valor = chave.Substring (inicio [VALOR], 1 + fim [VALOR] - inicio [VALOR]);
					return cupom;
				} else {
					const int CHAVE = 0;
					const int CPF = 3;
					const int DATA = 1;
					const int VALOR = 2;

					int[] inicio = new int [5];
					int[] fim = new int [5];
					int k = 0;
					inicio [k] = 0;
					for (int i = 0; i < chave.Length && k < fim.Length; i++) {

						if (chave.Substring (i, 1).Equals ("|")) {
							fim [k++] = i - 1;
							inicio [k] = i + 1;
						}
					}
					if (k < 4)
						return null;
					fim [k] = chave.Length - 1;

					Cupom cupom = new CupomSAT ();
					cupom.Chave = chave.Substring (inicio [CHAVE], 1 + fim [CHAVE] - inicio [CHAVE]);
					cupom.CPF = chave.Substring (inicio [CPF], 1 + fim [CPF] - inicio [CPF]);
					cupom.Data = chave.Substring (inicio [DATA], 1 + fim [DATA] - inicio [DATA]);
					cupom.Valor = chave.Substring (inicio [VALOR], 1 + fim [VALOR] - inicio [VALOR]);
					return cupom;
				}
			} catch {
				return null;
			}
		}
	}
}

