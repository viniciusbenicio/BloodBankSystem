﻿namespace BloodBankSystem.Infrastructure.ExternalServices.ViaCep.DTO
{
    public class ViaCepResponseDTO
    {
        public string cep { get; set; }
        public string logradouro { get; set; }
        public string complemento { get; set; }
        public string unidade { get; set; }
        public string bairro { get; set; }
        public string localidade { get; set; }
        public string uf { get; set; }
        public string estado { get; set; }
        public string regiao { get; set; }
        public string ibge { get; set; }
        public string gia { get; set; }
        public string ddd { get; set; }
        public string siafi { get; set; }

    }
}
