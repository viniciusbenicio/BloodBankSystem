using BloodBankSystem.Core.DTOs;
using BloodBankSystem.Core.Services;
using BloodBankSystem.Infrastructure.ExternalServices.ViaCep.DTO;
using Newtonsoft.Json;

namespace BloodBankSystem.Infrastructure.ExternalServices.ViaCep
{
    public class ViaCepService : ICEPService
    {
        private readonly HttpClient _httpClient;

        public ViaCepService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<CEPResult> GetByCepAsync(string zipCode)
        {
            var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{zipCode}/json/");

            if (!response.IsSuccessStatusCode)
            {
                return new CEPResult();
            }

            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<ViaCepResponseDTO>(content);

            var cepResult = new CEPResult
            {
                cep = json.cep,
                bairro = json.bairro,
                complemento = json.complemento,
                ddd = json.ddd,
                estado = json.estado,
                gia = json.gia,
                ibge = json.ibge,
                localidade = json.localidade,
                logradouro = json.logradouro,
                regiao = json.regiao,
                siafi = json.siafi,
                uf = json.uf,
                unidade = json.unidade,
            };

            return cepResult;
        }
    }
}
