using AppRpgEtec.Models;
using AppRpgEtec.Services.Armas;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRpgEtec.ViewModels.Armas
{
    public class ListagemArmaViewModel : BaseViewModel
    {
        private ArmaService aService;

        public ListagemArmaViewModel()
        {
            string token = Application.Current.Properties["UsuarioToken"].ToString();
            aService = new ArmaService(token);

            Armas = new ObservableCollection<Arma>();
            ObterArmas();

            NovaArmaCommand = new Command(ExibirCadastroArma);
            RemoverArmaCommand =
                new Command<Arma>(async(Arma a) => { await RemoverArma(a); });
        }

        public ICommand NovaArmaCommand { get; } //using System.Windows.Input
        public ICommand RemoverArmaCommand { get; }

        public ObservableCollection<Arma> Armas { get; set; }

        public async void ObterArmas()
        {
            try //Junto com o Cacth evitará que erros fechem o aplicativo
            {
                Armas = await aService.GetArmasAsync();
                OnPropertyChanged(nameof(Armas)); //Informará a View que houve carregamento                       
            }
            catch (Exception ex)
            {
                //Captará o erro para exibir em tela
                await Application.Current.MainPage.DisplayAlert("Ops", ex.Message, "Ok");
            }

        }
        public async void ExibirCadastroArma()
        {
            try
            {
                await Shell.Current.GoToAsync("cadArmaView");
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Ops", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }

        }

        private Arma armaSelecionada;
        public Arma ArmaSelecionada
        {
            get { return armaSelecionada; }
            set
            {
                if (value != null)
                {
                    armaSelecionada = value;
                    
                    Shell.Current
                        .GoToAsync($"cadArmaView?aId={armaSelecionada.Id}");

                }
            }
        }

        public async Task RemoverArma(Arma a)
        {

            if (await Application.Current.MainPage
                    .DisplayAlert("Confirmação", $"Confirma a remoção da arma {a.Nome}?", "Sim", "Não"))
            {
                await aService.DeleteArmaAsync(a.Id);
                await Application.Current.MainPage.DisplayAlert("Mensagem",
                    "Arma removida com sucesso!", "Ok");

                ObterArmas();
            }

        }

    }
}
