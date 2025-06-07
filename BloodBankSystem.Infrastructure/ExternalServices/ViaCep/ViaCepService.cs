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
            response.EnsureSuccessStatusCode();
            var content = await response.Content.ReadAsStringAsync();
            var json = JsonConvert.DeserializeObject<ViaCepResponseDTO>(content);

            return new CEPResult()
            {
                cep = json.cep,
            };
        }
    }
}
