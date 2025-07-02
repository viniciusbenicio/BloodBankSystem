namespace BloodBankSystem.Core.Services
{
    public interface IReportGenerator
    {
        /// <summary>
        /// Gera um relatório Excel a partir dos dados genéricos informados e retorna o arquivo como array de bytes.
        /// </summary>
        /// <typeparam name="T">Tipo dos dados</typeparam>
        /// <param name="data">Coleção de dados</param>
        /// <returns>Arquivo Excel em bytes</returns>
        Task<byte[]> GenerateReportAsync<T>(IEnumerable<T> data);
    }
}
