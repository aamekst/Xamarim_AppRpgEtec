using AppRpgEtec.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace AppRpgEtec.Services.Armas
{
    public class ArmaService : Request
    {
        private readonly Request _request = null;
        private string _token;
        private const string ApiUrlBase = "http://lzsouza.somee.com/RpgApi/Armas";

        public ArmaService(string token)
        {
            _token = token;
            _request = new Request();
        }

        public async Task<ObservableCollection<Arma>> GetArmasAsync()
        {
            string urlComplementar = string.Format("{0}", "/GetAll");
            ObservableCollection<Models.Arma> listaArmas = await
                _request.GetAsync<ObservableCollection<Models.Arma>>(ApiUrlBase + urlComplementar, _token);

            return listaArmas;
        }        
        public async Task<Arma> GetArmaAsync(int armaId)
        {
            string urlComplementar = string.Format("/{0}", armaId);

            var arma = await
                _request.GetAsync<Models.Arma>(ApiUrlBase + urlComplementar, _token);

            return arma;            
        }

        public async Task<Arma> PostArmaAsync(Arma a)
        {
            return await _request.PostAsync(ApiUrlBase, a, _token);
        }
        public async Task<Arma> PutArmaAsync(Arma a)
        {
            var result = await _request.PutAsync(ApiUrlBase, a, _token);
            return result;
        }
        public async Task<Arma> DeleteArmaAsync(int ArmaId)
        {
            string urlComplementar = string.Format("/{0}", ArmaId);
            await _request.DeleteAsync(ApiUrlBase + urlComplementar, _token);
            return new Arma() { Id = ArmaId };
        }
    }
}
