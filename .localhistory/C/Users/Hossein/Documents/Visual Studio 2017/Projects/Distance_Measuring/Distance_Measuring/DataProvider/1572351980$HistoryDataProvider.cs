using Distance_Measuring.IDataProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.DataProvider
{
    public class HistoryDataProvider
    {
        private readonly IHistoryDataProvider historyDataProvider;

        public HistoryDataProvider(IHistoryDataProvider historyDataProvider)
        {
            this.historyDataProvider = historyDataProvider;
        }
    }
}
