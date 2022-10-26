using AppRpgEtec.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace AppRpgEtec.Services.Usuarios
{
    public class UsuarioService : Request
    {
        private readonly Request _request;

        private const string apiUrlBase = "https://bsite.net/luizfernando987/Usuarios";


        // private const string apiUrlBase = "http://lzsouza.somee.com/RpgApi/Usuarios";


        private string _token;
        public UsuarioService(string token)
        {
            _request = new Request();
            _token = _token;
        }

        public UsuarioService()
        {
            _request = new Request();
        }

        public async Task<Usuario> PostLoginUsuarioAsync(Usuario u)
        {
            string urlComplementar = "/Autenticar";
            u.Token = await _request.PostReturnStringAsync(apiUrlBase + urlComplementar, u);

            return u;
        }

        public async Task<Usuario> PutAtualizarLocalizacaoAsync(Usuario u)
        {
            string urlComplementar = "/AtualizarLocalizacao";
            var result = await _request.PutAsync(apiUrlBase + urlComplementar, u, _token);
            return result;
        }
        public async Task<Usuario> GetUsuarioAsync(string login)
        {
            string urlComplementar = string.Format("/GetByLogin/{0}", login);
            var usuario = await
            _request.GetAsync<Models.Usuario>(apiUrlBase + urlComplementar, _token);
            return usuario;
        }
        //using System.Collections.ObjectModel
        public async Task<ObservableCollection<Usuario>> GetUsuariosAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Usuario> listaUsuarios = await
            _request.GetAsync<ObservableCollection<Models.Usuario>>(apiUrlBase + urlComplementar,
            _token);
            return listaUsuarios;
        }
    }
}
