using AppRpgEtec.Views.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRpgEtec.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenu : Shell
    {
        public FlyoutMenu()
        {
            InitializeComponent();

            Routing.RegisterRoute("cadPersonagemView", typeof(CadastroPersonagemView));

            if (Application.Current.Properties.ContainsKey("UsuarioUsername"))
                lblLogin.Text = "Login: " + Application.Current.Properties["UsuarioUsername"].ToString();
        }
    }
}