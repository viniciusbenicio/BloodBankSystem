using BloodBankSystem.Application.Models;
using MediatR;

namespace BloodBankSystem.Application.Queries.BloodStocks.GetByIdBloodStocks
{
    public class GetByIdBloodStocksQuery : IRequest<ResultViewModel<BloodStockViewModel>>
    {
        public GetByIdBloodStocksQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
