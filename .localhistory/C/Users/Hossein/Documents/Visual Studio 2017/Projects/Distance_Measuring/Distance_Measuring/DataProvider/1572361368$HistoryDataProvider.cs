using Distance_Measuring.DataContextProvider;
using Distance_Measuring.IDataProvider;
using Distance_Measuring.Model;
using Distance_Measuring.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.DataProvider
{
    public class HistoryDataProvider : IHistoryDataProvider
    {
        private readonly SqlDataContextcs sqlDataContextcs;

        public HistoryDataProvider(SqlDataContextcs sqlDataContextcs)
        {
            this.sqlDataContextcs = sqlDataContextcs;
        }
        public async Task<IEnumerable<RequestHistoryViewModel>> GetUserHistory(int UserID)
        {
            return sqlDataContextcs.RequestHistory.
               AsEnumerable().Where(x => x.User.ID == UserID);
        }

        public async Task InsertHistory(RequestHistory requestHistory)
        {
            await sqlDataContextcs.AddAsync(requestHistory);
            await sqlDataContextcs.SaveChangesAsync();
        }
    }
}
