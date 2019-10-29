using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Distance_Measuring.DataContextProvider;
using Distance_Measuring.IDataProvider;
using Distance_Measuring.Model;
using Distance_Measuring.ResponseModel;
using Distance_Measuring.Statics;
using Distance_Measuring.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Distance_Measuring.DataProvider
{
    public class UserDataProvider : IUserDataProvider
    {
        private readonly SqlDataContextcs sqlDataContextcs;
        private readonly IHistoryDataProvider historyDataProvider;
        private readonly IMapper mapper;
        private readonly AppSettings appSettings;

        public UserDataProvider(SqlDataContextcs sqlDataContextcs,
            IHistoryDataProvider historyDataProvider,
            IMapper mapper
            ,IOptions<AppSettings> appSettings)
        {
            this.sqlDataContextcs = sqlDataContextcs;
            this.historyDataProvider = historyDataProvider;
            this.mapper = mapper;
            this.appSettings = appSettings.Value;
        }


        public async Task<Response> Register(UserViewModel userViewModel)
        {
            Response result = null;

            try
            {
                //Map viewModelUser To User Because we must set PasswordHash and PasswordSalt
                User user = mapper.Map<User>(userViewModel);

                //if user by this username Not exist continue 
                if (! await CheckUserExist(userViewModel.UserName))
                {
                    #region password hash
                    //Create hash passsword an then store hashed password in data base
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
                    result = new Response
                    {
                        Message = "Duplicated", Code = StatusCodes.Status302Found
                    };
                }
            }
            catch (Exception ex)
            {
                result = new Response
                {
                    Message = ex.Message,
                    Code = StatusCodes.Status500InternalServerError
                };
            }
            return result;

        }

        public async Task<Response> Login(UserViewModel userViewModel)
        {
            User user = await GetUserIfExist(userViewModel.UserName);
            //check if user is exist
            if (user == null)
            {
                return new Response()
                {
                    Message = "Not Find this User, Please register and try again to login",
                    Code = StatusCodes.Status404NotFound
                };
            }

            bool passwordVerify = Utils.VerifyPasswordHash(userViewModel.Password,
                  user.PasswordHash, user.PasswordSalt);
            if (!passwordVerify)
            {
                return new Response()
                {
                    Message = "Password Or UserName Incorrect",
                    Code = StatusCodes.Status401Unauthorized
                };
            }

            string token = GenerateToken(user.UserName);
            return new UserResponse()
            {
                UserName = user.UserName,
                Token = token,
                Code = StatusCodes.Status200OK,
                Message = "Ok",
                requestHistories= await historyDataProvider.GetUserHistory(user.ID)
            };


        }


            //check if user is exist with this username
        public async Task<User> GetUserIfExist(string userName)
        {
            return await sqlDataContextcs.User.
               FirstOrDefaultAsync(x => x.UserName == userName);
        }

        //get user Instance by username
        public async Task<bool> CheckUserExist(string userName)
        {
            return await sqlDataContextcs.User.
                AnyAsync(x => x.UserName == userName);
        }




        //generate token by username
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
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
            #endregion
        }


       
    }
}
