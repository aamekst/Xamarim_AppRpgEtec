using AppRpgEtec.ViewModels.Personagens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRpgEtec.Views.Personagens
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroPersonagemView : ContentPage
    {
        private CadastroPersonagemViewModel cadViewModel;
        public CadastroPersonagemView()
        {
            InitializeComponent();

            cadViewModel = new CadastroPersonagemViewModel();
            BindingContext = cadViewModel;
            Title = "Novo personagem";
        }
    }
}