using Distance_Measuring.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.IDataProvider
{
    public interface IHistoryDataProvider
    {
        Task<IEnumerable<RequestHistory>> GetUserHistory(int UserID);

        Task InsertHistory(RequestHistory);
    }
}
