using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using System.Collections.Generic;
using System.Diagnostics;

namespace DoaFacil.iOS
{
	partial class EntidadeTableViewController : UITableViewController
	{
		
		IList<Entidade> entidades = GerenciadorCadastro.ListaDeEntidades;

		const string CellId = "EntidadeCell";
			
		public EntidadeTableViewController (IntPtr handle) : base (handle)
		{

		}

		public override nint RowsInSection(UITableView tableView, nint section){
			return entidades.Count;
		}

		public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath){

			UITableViewCell cell = tableView.DequeueReusableCell (CellId);

			if (cell == null) {
				cell = new UITableViewCell (UITableViewCellStyle.Subtitle, CellId);

				cell.DetailTextLabel.TextColor = UIColor.Gray;
				cell.TextLabel.TextColor = UIColor.Blue;

				cell.Accessory = UITableViewCellAccessory.None;

			}
			var item = entidades[indexPath.Row];

			cell.TextLabel.Text = item.Nome;
			cell.DetailTextLabel.Text = item.Cidade;

			Debug.WriteLine ("Celula" + item.Nome);

			return cell;

		}

		public override void RowSelected (UITableView tableView, NSIndexPath indexPath)
		{
			GerenciadorCadastro.Selecionada = entidades[indexPath.Row];
			var navCon = this.NavigationController;
			navCon.PopViewController(animated:true);
		}


	}
}
