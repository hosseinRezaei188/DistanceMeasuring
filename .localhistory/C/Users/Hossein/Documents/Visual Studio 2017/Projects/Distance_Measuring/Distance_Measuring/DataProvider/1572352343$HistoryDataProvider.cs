using Distance_Measuring.DataContextProvider;
using Distance_Measuring.IDataProvider;
using Distance_Measuring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.DataProvider
{
    public class HistoryDataProvider : IHistoryDataProvider
    {
        public HistoryDataProvider(SqlDataContextcs sqlDataContextcs)
        {

        }
        public Task<IEnumerable<RequestHistory>> GetUserHistory(int UserID)
        {
           
        }
    }
}
