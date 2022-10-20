using Sat.Recruitment.Common;
using Sat.Recruitment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sat.Recruitment.Api.Models
{
    public static class UserFactory
    {
        public static User CreateUser(UserModel user)
        {
            switch (Enum.Parse(typeof(UserTypes),(user.UserType)))
            {
                case UserTypes.Premium:
                    return _ = new PremiumUser(user.Name, user.Email, user.Address, user.Phone, UserTypes.Premium, user.Money);
                case UserTypes.SuperUser:
                    return _ = new SuperUser(user.Name, user.Email, user.Address, user.Phone, UserTypes.SuperUser, user.Money);
                default:
                    return _ = new NormalUser(user.Name, user.Email, user.Address, user.Phone, UserTypes.Normal, user.Money);
            }
        }
    }
}
