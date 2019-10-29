using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Distance_Measuring.Mapping
{
    public class UserMap:Profile
    {
        public UserMap()
        {
            CreateMap<ViewModel.UserViewModel, Model.User>().
                ReverseMap();

            CreateMap<ViewModel.RequestHistoryViewModel, Model.RequestHistory>().
              ReverseMap();

            CreateMap<ViewModel.RequestHistoryViewModel, Model.RequestHistory>().
            ReverseMap();
        }
    }
}
