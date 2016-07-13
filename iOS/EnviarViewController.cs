using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Diagnostics;

namespace DoaFacil.iOS
{
	public partial class EnviarViewController : UIViewController

	{
		public Cupom Cupom { get; set; }

		public EnviarViewController (IntPtr handle) : base (handle)
		{
		}

//		public override void ViewWillAppear (bool animated)
//		{
//			base.ViewWillAppear (animated);
//			Debug.WriteLine ("Chamou o ViewWillAppear");
//
//			if (Cupom != null) {
//				lblChave.Text = Cupom.Chave;
//				lblData.Text = Cupom.Data;
//				lblCPF.Text = Cupom.CPF;
//				lblValor.Text = Cupom.Valor;
//				Debug.WriteLine ("Configurou o cupom no ViewWillAppear");
//			} else {
//				Debug.WriteLine ("O cupom e' nulo no ViewWillAppear");
//
//			}
//		}

		public override void ViewDidAppear (bool animated)
		{
			base.ViewDidAppear (animated);
			Timer.Hidden = true;
			Debug.WriteLine ("Chamou o ViewDidAppear");
			if (GerenciadorCadastro.Selecionada != null && (
				!GerenciadorCadastro.Selecionada.Nome.Equals(lblNomeEntidade.Text) ||
				!GerenciadorCadastro.Selecionada.Cidade.Equals(lblDetalhe.Text))) {
				lblNomeEntidade.Text = GerenciadorCadastro.Selecionada.Nome;
				lblDetalhe.Text = GerenciadorCadastro.Selecionada.Cidade;
			}
			if (GerenciadorCadastro.Selecionada != null) {
				BotaoEnviar.Enabled = true;
			} else {
				BotaoEnviar.Enabled = false;
			}

		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			Timer.Hidden = true;
			Debug.WriteLine ("Chamou o ViewDidLoad");
			if (Cupom != null) {
				lblChave.Text = Cupom.Chave;
				lblData.Text = Cupom.Data;
				//lblCPF.Text = Cupom.CPF;
				lblValor.Text += Cupom.Valor;
				Debug.WriteLine ("Configurou o cupom no ViewDidLoad");
			} else {
				Debug.WriteLine ("O cupom e' nulo no ViewDidLoad");
			}
			if (GerenciadorCadastro.Selecionada != null &&
				(!GerenciadorCadastro.Selecionada.Nome.Equals(lblNomeEntidade.Text) ||
					!GerenciadorCadastro.Selecionada.Cidade.Equals(lblDetalhe.Text))) {
				lblNomeEntidade.Text = GerenciadorCadastro.Selecionada.Nome;
				lblDetalhe.Text = GerenciadorCadastro.Selecionada.Cidade;
			}

			BotaoEnviar.TouchUpInside += async (sender, e) => {
				if(Reachability.InternetConnectionStatus()!= NetworkStatus.NotReachable){
					var retorno = await GerenciadorCadastro.Add();
					Debug.WriteLine("BotaoEnviar" + retorno.ToString());
					var av = new UIAlertView ("Envio do Cupom", "Cupom enviado com sucesso!", null, "OK", null);
					av.Show ();
					var navCon = this.NavigationController;
					navCon.PopToRootViewController(animated:true);
				} else {
					var av = new UIAlertView ("Envio do Cupom", "Rede indisponível, tente enviar mais tarde.", null, "OK", null);
					av.Show ();
				}
			    
			};

			if (GerenciadorCadastro.Selecionada != null) {
				BotaoEnviar.Enabled = true;
			} else {
				BotaoEnviar.Enabled = false;
			}

			BotaoEntidades.TouchUpInside += async (sender, e) => {
				if(Reachability.InternetConnectionStatus()!= NetworkStatus.NotReachable){
					//carrega a lista de entidades
					if(GerenciadorCadastro.ListaDeEntidades == null){
						Timer.Hidden = false;
						Timer.StartAnimating();
						GerenciadorCadastro.ListaDeEntidades = await GerenciadorCadastro.GetAll();
						Debug.WriteLine("Botao Entidades, chamou o json de entidades");
						Timer.StopAnimating();
						Timer.Hidden = true;
					}
					var navCon = this.NavigationController;
					EntidadeTableViewController etvc = (EntidadeTableViewController)
						this.Storyboard.InstantiateViewController ("EntidadeTableViewController");
					navCon.PushViewController (etvc, animated: true);
				} else {
					var av = new UIAlertView ("Mudar Entidade", "Rede indisponível, tente mudar mais tarde.", null, "OK", null);
					av.Show ();
				}
			};



		}
	}
}
