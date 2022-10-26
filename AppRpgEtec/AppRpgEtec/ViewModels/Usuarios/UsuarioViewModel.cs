using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using AppRpgEtec.Views;
using Plugin.Geolocator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace AppRpgEtec.ViewModels.Usuarios
{
    public class UsuarioViewModel : BaseViewModel
    {
        private UsuarioService uService;
        private Usuario Usuario;
        public ICommand EntrarCommand { get; set; }

        //ctor + TAB + TAB: atalho para criar o construtor
        public UsuarioViewModel()
        {
            this.Usuario = new Usuario();
            uService = new UsuarioService();
            RegistrarCommands();
        }
        public void RegistrarCommands()
        {
            EntrarCommand = new Command(async () => { await ConsultarUsuario();});
        }

        public async Task ConsultarUsuario()//Método para buscar um usuário     
        {
            try
            {
                Usuario u = null;
                u = await uService.PostLoginUsuarioAsync(Usuario);

                if (!string.IsNullOrEmpty(u.Token))
                {
                    //Guardando dados do usuário para uso futuro
                    Application.Current.Properties["UsuarioId"] = u.Id;
                    Application.Current.Properties["UsuarioUsername"] = u.Username;
                    Application.Current.Properties["UsuarioPerfil"] = u.Perfil;
                    Application.Current.Properties["UsuarioToken"] = u.Token;

                    UsuarioService uServiceLoc = new UsuarioService(u.Token);
                    Usuario uLoc = await uServiceLoc.GetUsuarioAsync(u.Username);

                    var locator = CrossGeolocator.Current;
                    locator.DesiredAccuracy = 50;
                    var position = await locator.GetPositionAsync(TimeSpan.FromSeconds(10));

                    uLoc.Latitude = String.Format("{0:0.0000000}", position.Latitude);
                    uLoc.Longitude = String.Format("{0:0.0000000}", position.Longitude);









                    string mensagem = string.Format("Bem-vindo {0}", u.Username);
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", mensagem, "Ok");

                    /*FlyoutMenu menu = new FlyoutMenu();
                    var page = (Page)Activator.CreateInstance(typeof(MainPage));
                    page.Title = "Main Page";*/
                                        
                    

                    Application.Current.MainPage = new FlyoutMenu();
                }
                else
                {
                    await Application.Current.MainPage
                        .DisplayAlert("Informação", "Dados incorretos :(", "Ok");
                }
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + " Detalhes: " + ex.InnerException, "Ok");
            }
        }

        

        #region Propriedades
        public string Login
        {
            get { return this.Usuario.Username; }
            set
            {
                this.Usuario.Username = value;
                OnPropertyChanged();
            }
        }

        public string Senha
        {
            get { return this.Usuario.PasswordString; }
            set
            {
                this.Usuario.PasswordString = value;
                OnPropertyChanged();
            }
        }

        #endregion






    }
}
