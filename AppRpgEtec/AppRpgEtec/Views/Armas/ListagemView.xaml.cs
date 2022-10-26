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
    public partial class ListagemView : ContentPage
    {
        private ListagemArmaViewModel viewModel;
        public ListagemView()
        {
            InitializeComponent();

            viewModel = new ListagemArmaViewModel();
            BindingContext = viewModel;
            Title = "Armas";
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            viewModel.ObterArmas();
        }
    }
}