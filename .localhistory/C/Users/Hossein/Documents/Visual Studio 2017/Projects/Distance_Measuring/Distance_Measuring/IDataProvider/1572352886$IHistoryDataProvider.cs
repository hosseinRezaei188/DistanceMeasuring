using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.IDataProvider
{
    public interface IHistoryDataProvider
    {
        Task<IEnumerable<Model.RequestHistory>> GetUserHistory(int UserID);

    }
}
