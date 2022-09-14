using AppRpgEtec.Models;
using AppRpgEtec.Services.Usuarios;
using AppRpgEtec.Views;
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

        public UsuarioViewModel()
        { 
            this.Usuario  = new Usuario();
            uService = new UsuarioService();
            RegistrarCommands();
        }

        public void RegistrarCommands()
        {
            EntrarCommand = new Command(async () => { await ConsultarUsuario(); }); 
        }

        public async Task ConsultarUsuario()
        {
            try
            {
                Usuario u = null;
                u = await uService.PostLoginUsuarioAsync(Usuario);

                if(!string.IsNullOrEmpty(u.Token))
                {
                    Application.Current.Properties["UsuarioId"] = u.Id;
                    Application.Current.Properties["UsuarioUsername"] = u.Username;
                    Application.Current.Properties["UsuarioPerfil"] = u.Perfil;
                    Application.Current.Properties["UsuarioToken"] = u.Token;

                    string mensagem = string.Format("Bne-vindo {0}", u.Username);
                    await Application
                        .Current.MainPage.DisplayAlert("Informação", mensagem, "Ok");


                    Application.Current.MainPage = new FlyoutMenu();





                }


            }
            catch (Exception ex)
            {

                await Application.Current.MainPage
                    .DisplayAlert("Informação", ex.Message + "Detalhes:" + ex.InnerException, "Ok");
            }
        }


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


















    }


}
