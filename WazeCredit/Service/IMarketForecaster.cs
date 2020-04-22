using WazeCredit.Models;

namespace WazeCredit.Service
{
    public interface IMarketForecaster
    {
        MarketResult GetMarketPrediction();
    }
}