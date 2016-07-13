
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace DoaFacil.Droid
{
	[Activity(Theme = "@android:style/Theme.Material.Light.DarkActionBar", Label = "Escolher Entidade")]
	public class ListaEntidadesActivity : Activity
	{
		ListView listView;
		IList<Entidade> entidades = GerenciadorCadastro.ListaDeEntidades;
		String[] lista = null;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Create your application here

			SetContentView(Resource.Layout.ListaEntidadesLayout);

			listView = (ListView)FindViewById(Resource.Id.view_lista_entidade);
			lista = new String[entidades.Count];
			for (int i = 0; i < lista.Length; i++)
			{
				lista[i] = entidades[i].Nome;
			}

			BaseAdapter adapter = new ArrayAdapter<String>(this, Android.Resource.Layout.SimpleListItem1, lista);
			listView.Adapter = adapter;
			listView.ItemClick += OnItemClick; 
		}

		void OnItemClick(object sender, AdapterView.ItemClickEventArgs e)
		{
			var posicao = e.Position;
			GerenciadorCadastro.Selecionada = entidades[posicao];
			base.StartActivity(typeof(EnviarActivity));
		}
	}
}
