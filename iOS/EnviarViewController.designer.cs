// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace DoaFacil.iOS
{
    [Register ("EnviarViewController")]
    partial class EnviarViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BotaoEntidades { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton BotaoEnviar { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblChave { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblData { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDetalhe { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblNomeEntidade { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblValor { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIActivityIndicatorView Timer { get; set; }

        [Action ("BotaoEnviar_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void BotaoEnviar_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (BotaoEntidades != null) {
                BotaoEntidades.Dispose ();
                BotaoEntidades = null;
            }

            if (BotaoEnviar != null) {
                BotaoEnviar.Dispose ();
                BotaoEnviar = null;
            }

            if (lblChave != null) {
                lblChave.Dispose ();
                lblChave = null;
            }

            if (lblData != null) {
                lblData.Dispose ();
                lblData = null;
            }

            if (lblDetalhe != null) {
                lblDetalhe.Dispose ();
                lblDetalhe = null;
            }

            if (lblNomeEntidade != null) {
                lblNomeEntidade.Dispose ();
                lblNomeEntidade = null;
            }

            if (lblValor != null) {
                lblValor.Dispose ();
                lblValor = null;
            }

            if (Timer != null) {
                Timer.Dispose ();
                Timer = null;
            }
        }
    }
}