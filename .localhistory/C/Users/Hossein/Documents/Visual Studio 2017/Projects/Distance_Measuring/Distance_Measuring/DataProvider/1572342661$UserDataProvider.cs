using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Distance_Measuring.DataContextProvider;
using Distance_Measuring.Model;
using Distance_Measuring.ResponseModel;
using Distance_Measuring.Statics;
using Distance_Measuring.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Distance_Measuring.DataProvider
{
    public class UserDataProvider : IDataProvider.IUserDataProvider
    {
        private readonly SqlDataContextcs sqlDataContextcs;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public UserDataProvider(SqlDataContextcs sqlDataContextcs,
            IMapper mapper
            , IOptions<AppSettings> appSettings)
        {
            this.sqlDataContextcs = sqlDataContextcs;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }


        public async Task<object> Register(UserViewModel userViewModel)
        {
            object result = null;

            try
            {


                User user = mapper.Map<User>(userViewModel);

                //if user by this username Not exist continue 
                if (!CheckUserExist(userViewModel.UserName))
                {
                    #region password hash
                    byte[] passwordHash, passwordSalt;

                    Utils.CreatePasswordHash(userViewModel.Password, out passwordHash, out passwordSalt);

                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    #endregion



                    sqlDataContextcs.User.Add(user);

                    await sqlDataContextcs.SaveChangesAsync();
                    result = new UserResponse
                    {
                        Message = "Ok",
                        Code = StatusCodes.Status200OK,
                        UserName = userViewModel.UserName,
                        Token = GenerateToken(userViewModel.UserName)
                    };

                }
                else
                {
                    result = new UserResponse { Message = "Duplicated", Code = StatusCodes.Status302Found };
                }
            }
            catch (Exception ex)
            {
                result = new UserResponse
                {
                    Message = ex.Message,
                    Code = StatusCodes.Status500InternalServerError
                };
            }
            return result;

        }

        public Task<object> Login(UserViewModel userViewModel)
        {
            User user = GetUserIfExist(userViewModel.UserName);
            //check if user is exist
            if (user != null)
            {

                bool passwordVerify = Utils.VerifyPasswordHash(userViewModel.Password,
                    user.PasswordHash, user.PasswordSalt);
                if (passwordVerify)
                {

                }



            }
        }
        public bool CheckUserExist(string userName)
        {
            //check if user is exist with this username
            return sqlDataContextcs.User.
                Any(x => x.UserName == userName);

        }

        User GetUserIfExist(string userName)
        {
            //check if user is exist with this username
            return sqlDataContextcs.User.
               FirstOrDefault(x => x.UserName == userName);

        }

        public User GetOne(int id)
        {
            return sqlDataContextcs.User.
                FirstOrDefault(x => x.ID == id);
        }

        string GenerateToken(string userName)
        {
            #region tokenGenerator
            //generate Token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userName.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
            #endregion
        }



    }
}
