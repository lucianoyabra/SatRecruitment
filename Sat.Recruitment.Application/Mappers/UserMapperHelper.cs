using Sat.Recruitment.Common;
using Sat.Recruitment.Data.Factory;
using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sat.Recruitment.Data.Mappers
{
    public static class UserMapperHelper
    {
        public static async Task<List<User>> MapToUsers(List<string> csvData)
        {
            List<User> retList = new List<User>();
            var res = csvData.ToArray();
            foreach(var user in res)
            {
                retList.Add(GetUserDeserializer(user));
            }
            return retList;
        }

        private static User GetUserDeserializer(string user)
        {
            
                string[] fields = user.Split(',');
                UserModel userModel = new UserModel();
                userModel.Name = fields[0];
                userModel.Email = fields[1];
                userModel.Phone = fields[2];
                userModel.Address = fields[3];
                userModel.UserType = fields[4];
                userModel.Money = decimal.Parse(fields[5]);

                return UserFactory.CreateUser(userModel);
            
        }

        public static string[] GetUserToString(User user)
        {
            string[] arrUser =
            {
                user.Name,
                user.Email,
                user.Address,
                user.Phone,
                user.UserType.ToString(),
                user.Money.ToString()
            };

            return arrUser;

        }
    }
}
