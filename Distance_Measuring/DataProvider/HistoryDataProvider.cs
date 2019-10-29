﻿using AutoMapper;
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
        private readonly IMapper mapper;

        public HistoryDataProvider(SqlDataContextcs sqlDataContextcs,IMapper mapper)
        {
            this.sqlDataContextcs = sqlDataContextcs;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<RequestHistoryViewModel>> GetUserHistory(int UserID)
        {
            //Map RequestHistory to RequestHistoryViewModel because hidden User Property Data 
            List<RequestHistory> histories =  sqlDataContextcs.RequestHistory.
               AsEnumerable().Where(x => x.User!=null && x.User.ID == UserID).ToList();

            IEnumerable<RequestHistoryViewModel> historiesVMs =
                mapper.Map<IEnumerable<RequestHistory>, IEnumerable<RequestHistoryViewModel>>(histories);

            return historiesVMs;
        }

        public async Task InsertHistory(RequestHistory requestHistory)
        {
            //insert successfull measuringHistory to database
            await sqlDataContextcs.AddAsync(requestHistory);
            await sqlDataContextcs.SaveChangesAsync();
        }
    }
}
