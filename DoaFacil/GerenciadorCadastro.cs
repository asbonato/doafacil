using ModernHttpClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
//using System.Linq;
using System.Diagnostics;

namespace DoaFacil
{
	public class GerenciadorCadastro
	{
		public static Entidade Selecionada {get; set;}
		public static IList<Entidade> ListaDeEntidades{ get; set;}
		public static Cupom Cupom { get; set; }

		const string UrlEntidades = "http://jbossews-doafacil.rhcloud.com/entidades.do";
		const string UrlCupom = "http://jbossews-doafacil.rhcloud.com/cupons.do";

		private static HttpClient GetClient()
		{
			HttpClient client = new HttpClient(new NativeMessageHandler());
			client.DefaultRequestHeaders.Add("Accept", "application/json");
			return client;
		}

		public static async Task<IList<Entidade>> GetAll(){
			
			HttpClient client = GetClient();
			string result = await client.GetStringAsync(UrlEntidades);
			return JsonConvert.DeserializeObject<IList<Entidade>>(result);
		}

		public static async Task<String> Add()
		{
			Cupom.CNPJEntidade = Selecionada.CNPJ;

			HttpClient client = GetClient();
			var response = await client.PostAsync(UrlCupom,
				new StringContent(
					JsonConvert.SerializeObject(Cupom),
					Encoding.UTF8, "application/json"));
			Debug.WriteLine ("response " + response.ToString ());
			return response.StatusCode.ToString ();
		}

//		public static IList<Entidade> listaDeEntidades(){
//
//			IList<Entidade> entidades = new List<Entidade> ();
//
//			Entidade entidade = new Entidade ();
//			entidade.Nome = "Instituto do Deficiente Visual de Votuporanga";
//			entidade.Cidade = "Votuporanga";
//			entidade.CNPJ = "02.197.503/0001-24";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "Casa da Sopa Francisco de Assis";
//			entidade.Cidade = "Presidente Prudente";
//			entidade.CNPJ = "68.163.666/0001-02";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "Associação Pro Excepcional Kodomo No Sono";
//			entidade.Cidade = "São Paulo";
//			entidade.CNPJ = "60.927.530/0001-01";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "AMA Associação de Amigos do Autista";
//			entidade.Cidade = "São Paulo";
//			entidade.CNPJ = "52.802.295/0001-13";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "APAE de São Paulo";
//			entidade.Cidade = "São Paulo";
//			entidade.CNPJ = "60.502.242/0001-05";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "AACD - Associação de Assistência à Criança Deficiente";
//			entidade.Cidade = "São Paulo";
//			entidade.CNPJ = "60.979.457/0001-11";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "Sociedade dos Amigos da Cultura de Garça";
//			entidade.Cidade = "Garça";
//			entidade.CNPJ = "02.162.011/0001-01";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "Amigos da Santa Casa";
//			entidade.Cidade = "Ibitinga";
//			entidade.CNPJ = "04.807.835/0001-09";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "APAE de Dourado";
//			entidade.Cidade = "Dourado";
//			entidade.CNPJ = "48.526.867/0001-01";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "Sociedade Beneficente a Serviço do Amor - ASA";
//			entidade.Cidade = "Espírito Santo do Pinhal";
//			entidade.CNPJ = "01.563.400/0001-78";
//			entidades.Add (entidade);
//
//			entidade = new Entidade ();
//			entidade.Nome = "Associação de Mutirantes";
//			entidade.Cidade = "Guarulhos";
//			entidade.CNPJ = "03.584.835/0001-24";
//			entidades.Add (entidade);
//			//retorna ordenada
//			return entidades.OrderBy(o=>o.Nome).ToList();;
//		}
	}


		
}

