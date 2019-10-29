using Distance_Measuring.Model;
using Distance_Measuring.ResponseModel;
using Distance_Measuring.ViewModel;
using System.Threading.Tasks;

namespace Distance_Measuring.IDataProvider
{
    public interface IUserDataProvider
    {
        Task<Response> Register(UserViewModel userViewModel);
        Task<Response> Login(UserViewModel userViewModel);
        bool CheckUserExist(string userName);
        User GetOne(int id);
        User GetUserIfExist(int id);
    }
}
