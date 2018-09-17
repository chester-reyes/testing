using System.Threading.Tasks;
using StockDividendDownloader.Model.Messages;

namespace StockDividendDownloader.Model.Interfaces
{
    public interface IStockDataHandler
    {
        Task<GetStockDataHandlerResponse> Handle(GetStockDataHandlerRequest request);
    }
}
