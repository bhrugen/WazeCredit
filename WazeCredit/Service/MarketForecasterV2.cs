using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WazeCredit.Models;

namespace WazeCredit.Service
{
    public class MarketForecasterV2
    {
        public MarketResult GetMarketPrediction()
        {
            //Call API to do some complex calculations and current stock market forecast
            //For course purpose we will hard code the result

            return new MarketResult
            {
                MarketCondition = MarketCondition.Volatile
            };
        }
    }

    
}
