using AppRpgEtec.ViewModels.Armas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace AppRpgEtec.Views.Armas
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CadastroArmaView : ContentPage
    {
        private CadastroArmaViewModel cadViewModel;
        public CadastroArmaView()
        {
            InitializeComponent();

            cadViewModel = new CadastroArmaViewModel();
            BindingContext = cadViewModel;
            Title = "Nova Arma";
        }        

    }
}

